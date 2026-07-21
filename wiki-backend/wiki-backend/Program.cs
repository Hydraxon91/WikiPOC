using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Identity;
using wiki_backend.Models;
using wiki_backend.Services;
using wiki_backend.Services.Authentication;
using wiki_backend.Services.Settings;
using Serilog;
using Microsoft.Extensions.Caching.Memory;
using wiki_backend.Middleware;
using wiki_backend.Controllers;
using wiki_backend.Services.Database;
using wiki_backend.Services.Storage;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

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

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddMemoryCache();

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
    options.AddFixedWindowLimiter("EmbedPolicy", opt =>
    {
        opt.PermitLimit = 30;
        opt.Window = TimeSpan.FromMinutes(1);
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 0;
    });
});

builder.Services.AddHealthChecks();

builder.Services.AddHostedService<DbInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseMiddleware<ScraperEmbedMiddleware>();

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

app.UseStaticFiles();

app.UseCors();

app.UseRateLimiter();

app.UseAuthentication();

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/api/Users/RefreshToken"))
    {
        await next();
        return;
    }

    if (context.User.Identity?.IsAuthenticated == true)
    {
        var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var dbRoles = await userManager.GetRolesAsync(user);
                var tokenRole = context.User.FindFirstValue(ClaimTypes.Role);
                if (tokenRole != null && !dbRoles.Contains(tokenRole))
                {
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsJsonAsync(new { reason = "role_changed" });
                    return;
                }
            }
        }
    }
    await next();
});

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");
app.MapFallbackToFile("index.html");

app.Run();

void AddCors()
{
    var allowedOrigins = builder.Configuration["AllowedOrigins"] ?? "http://localhost:3000;http://localhost:3001";
    var origins = allowedOrigins.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy
                .WithOrigins(origins)
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
        options.UseSqlServer(Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING")!, sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
        });
        options.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        if (builder.Environment.IsDevelopment())
        {
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        }
    });
}

void AddServices()
{
    builder.Services.AddScoped<IWikiPageRepository, WikiPageRepository>();
    builder.Services.AddScoped<IStyleRepository, StyleRepository>();
    builder.Services.AddScoped<ISiteSettingsRepository, SiteSettingsRepository>();
    builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
    builder.Services.AddScoped<IUserCommentRepository, UserCommentRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<IForumPostRepository, ForumPostRepository>();
    builder.Services.AddScoped<IForumTopicRepository, ForumTopicRepository>();
    builder.Services.AddScoped<IForumCommentRepository, ForumCommentRepository>();
    builder.Services.AddScoped<ICommentFlagRepository, CommentFlagRepository>();
    builder.Services.AddScoped<IImageStorageService, ImageStorageService>();
    builder.Services.AddScoped<IUserAuthorizationService, UserAuthorizationService>();
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
        options.AddPolicy(IdentityData.AdminUserPolicyName, p => p.RequireClaim(ClaimTypes.Role, IdentityData.AdminUserClaimName, IdentityData.OwnerClaimName));
        options.AddPolicy(IdentityData.UserPolicyName, p => p.RequireClaim(ClaimTypes.Role, IdentityData.UserClaimName, IdentityData.ModeratorClaimName, IdentityData.OwnerClaimName));
        options.AddPolicy(IdentityData.ModeratorPolicyName, p => p.RequireAssertion(context =>
            context.User.HasClaim(ClaimTypes.Role, IdentityData.AdminUserClaimName) ||
            context.User.HasClaim(ClaimTypes.Role, IdentityData.ModeratorClaimName) ||
            context.User.HasClaim(ClaimTypes.Role, IdentityData.OwnerClaimName)));
        options.AddPolicy(IdentityData.OwnerPolicyName, p => p.RequireClaim(ClaimTypes.Role, IdentityData.OwnerClaimName));
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
        option.SwaggerDoc("v1", new() { Title = "WikiPOC API", Version = "v1" });

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
