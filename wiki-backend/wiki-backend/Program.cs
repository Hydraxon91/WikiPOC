using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Identity;
using wiki_backend.Models;
using wiki_backend.Services.Authentication;
using wiki_backend.Services.Settings;
using wiki_backend.Services.Database;
using wiki_backend.Services.Storage;

var builder = WebApplication.CreateBuilder(args);

// Register strongly-typed settings from environment variables
builder.Services.Configure<StorageSettings>(options =>
{
    options.PicturesPath = Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER") ?? string.Empty;
});

var jwtSigningKey = Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY");
if (string.IsNullOrEmpty(jwtSigningKey) || Encoding.UTF8.GetByteCount(jwtSigningKey) < 32)
{
    throw new InvalidOperationException("JWT_ISSUER_SIGNING_KEY must be at least 32 characters long for HMAC-SHA256.");
}

builder.Services.Configure<JwtSettings>(options =>
{
    options.ValidIssuer = Environment.GetEnvironmentVariable("JWT_VALID_ISSUER") ?? string.Empty;
    options.ValidAudience = Environment.GetEnvironmentVariable("JWT_VALID_AUDIENCE") ?? string.Empty;
    options.IssuerSigningKey = jwtSigningKey ?? string.Empty;
    options.TokenTime = int.TryParse(Environment.GetEnvironmentVariable("JWT_TOKEN_TIME"), out var time) ? time : 30;
});

// Add services to the container.
AddCors();
AddDbContext();
AddServices();
AddAuthentication();
AddIdentity();
ConfigureSwagger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.AddFixedWindowLimiter("LoginPolicy", opt =>
    {
        opt.PermitLimit = 10;
        opt.Window = TimeSpan.FromMinutes(1);
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 0;
    });
});

builder.Services.AddHostedService<DbInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(new
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred while processing your request.",
            Status = StatusCodes.Status500InternalServerError
        });
    });
});

app.UseCors();

app.UseRateLimiter();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void AddCors()
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy
                .WithOrigins("http://localhost:3000", "http://localhost:3001")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
    });
}
void AddDbContext()
{
    builder.Services.AddDbContext<WikiDbContext>(options =>
    {
        options.UseSqlServer(Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING")!);
        if (builder.Environment.IsDevelopment())
        {
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        }
    });
}

void AddServices()
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddScoped<IWikiPageRepository, WikiPageRepository>();
    builder.Services.AddScoped<IParagraphRepository, ParagraphRepository>();
    builder.Services.AddScoped<IStyleRepository, StyleRepository>();
    builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
    builder.Services.AddScoped<IUserCommentRepository, UserCommentRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<IForumPostRepository, ForumPostRepository>();
    builder.Services.AddScoped<IForumTopicRepository, ForumTopicRepository>();
    builder.Services.AddScoped<IForumCommentRepository, ForumCommentRepository>();
    builder.Services.AddScoped<IImageStorageService, ImageStorageService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddSingleton<ITokenServices, TokenServices>();
}

void AddAuthentication()
{
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_VALID_ISSUER"),
            ValidAudience = Environment.GetEnvironmentVariable("JWT_VALID_AUDIENCE"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY")!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });
    
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(IdentityData.AdminUserPolicyName, p => p.RequireClaim(ClaimTypes.Role, IdentityData.AdminUserClaimName));
        options.AddPolicy(IdentityData.UserPolicyName, p => p.RequireClaim(ClaimTypes.Role, IdentityData.UserClaimName));
    });
}

void AddIdentity()
{
    builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<WikiDbContext>();
}

void ConfigureSwagger()
{
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new() { Title = "Demo API", Version = "v1" });

        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });

        option.AddSecurityRequirement(document => new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer", document)] = []
        });
    });
}
