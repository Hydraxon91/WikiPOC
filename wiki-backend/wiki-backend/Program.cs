using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;
using wiki_backend.Services.Authentication;
using wiki_backend.Services.Profile;

var builder = WebApplication.CreateBuilder(args);

// Get the path for storing profile images from environment variables
// var profilePicturesPath = Environment.GetEnvironmentVariable("PROFILE_PICTURES_PATH");
var picturesPath = Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER");

// Ensure the path is not null or empty //Comment these lines when running migrations
if (string.IsNullOrEmpty(picturesPath))
{
    throw new Exception($"PROFILE_PICTURES_PATH environment variable is not set. {picturesPath}");
}


// Add services to the container.
AddCors();
AddDbContext();
AddServices();
AddAuthentication();
AddIdentity();
ConfigureSwagger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

if (Environment.GetEnvironmentVariable("Environment") != "Testing")
{
    AddRoles();
    AddAdmin();
    AddUser();
    SeedComments();
}

app.Run();

void AddCors()
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        options.AddPolicy("AllowLocalhost", policy =>
        {
            policy
                .WithOrigins("http://localhost:3000", "http://localhost:3001") // Allow requests from your client's origin
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
        options.UseSqlServer(Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING"));
        options.EnableSensitiveDataLogging(); // Enable logging for debugging
        options.EnableDetailedErrors();       // Enable detailed errors for debugging
    });
}

void AddServices()
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddTransient<IWikiPageRepository, WikiPageRepository>();
    builder.Services.AddTransient<IParagraphRepository, ParagraphRepository>();
    builder.Services.AddTransient<IStyleRepository, StyleRepository>();
    builder.Services.AddTransient<IUserProfileRepository, UserProfileRepository>();
    builder.Services.AddTransient<IUserCommentRepository, UserCommentRepository>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<ITokenServices, TokenServices>();
    builder.Services.AddSingleton(new ProfileImageSettings(picturesPath));
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
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
    });
}

void AddRoles()
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!roleManager.RoleExistsAsync("Admin").Result)
    {
        var tAdmin = CreateAdminRole(roleManager);
        tAdmin.Wait();
    }

    if (!roleManager.RoleExistsAsync("User").Result)
    {
        var tUser = CreateUserRole(roleManager);
        tUser.Wait();
    }
}

async Task CreateAdminRole(RoleManager<IdentityRole> roleManager)
{
    await roleManager.CreateAsync(new IdentityRole("Admin"));
}

async Task CreateUserRole(RoleManager<IdentityRole> roleManager)
{
    await roleManager.CreateAsync(new IdentityRole("User"));
}

void AddAdmin()
{
    var tAdmin = CreateAdminIfNotExists();
    tAdmin.Wait();
}

async Task CreateAdminIfNotExists()
{
    using var scope = app.Services.CreateScope();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
    var adminInDb = await userManager.FindByEmailAsync("admin@admin.com");
    if (adminInDb == null)
    {
        // Console.WriteLine(Environment.GetEnvironmentVariable("ADMINUSER_PASSWORD"));
        var adminName = Environment.GetEnvironmentVariable("ADMINUSER_USERNAME");
        
        var adminProfile = new UserProfile()
        {
            UserName = adminName,
            DisplayName = "Hydraxon",
            ProfilePicture = "admin_base.gif"
        };
        // Save UserProfile to the database
        dbContext.UserProfiles.Add(adminProfile);
        await dbContext.SaveChangesAsync();
        
        var admin = new ApplicationUser
        {
            UserName = adminName,
            Email = Environment.GetEnvironmentVariable("ADMINUSER_EMAIL"),
            ProfileId = adminProfile.Id
        };
        
        var adminCreated = await userManager.CreateAsync(admin, Environment.GetEnvironmentVariable("ADMINUSER_PASSWORD"));

        if (adminCreated.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Admin");
            
            // Set the UserId of adminProfile
            adminProfile.UserId = admin.Id;

            // Update UserProfile in the database
            dbContext.UserProfiles.Update(adminProfile);
            await dbContext.SaveChangesAsync();
        }
    }
}

void AddUser()
{
    var tUser = CreateUserIfNotExists();
    tUser.Wait();
}

async Task CreateUserIfNotExists()
{
    using var scope = app.Services.CreateScope();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
    var userInDb = await userManager.FindByEmailAsync("test@test.com");
    if (userInDb == null)
    {
        // Console.WriteLine(Environment.GetEnvironmentVariable("TESTUSER_PASSWORD"));
        var testUsername = Environment.GetEnvironmentVariable("TESTUSER_USERNAME");
        
        var testUserProfile = new UserProfile()
        {
            UserName = testUsername,
            DisplayName = "Peter Griffin",
            ProfilePicture = "tester_base.gif"
        };
        // Save UserProfile to the database
        dbContext.UserProfiles.Add(testUserProfile);
        
        await dbContext.SaveChangesAsync();
        var testUser = new ApplicationUser
        {
            UserName = testUsername,
            Email = Environment.GetEnvironmentVariable("TESTUSER_EMAIL"),
            ProfileId = testUserProfile.Id
        };
        
        var userCreated = await userManager.CreateAsync(testUser, Environment.GetEnvironmentVariable("TESTUSER_PASSWORD"));

        if (userCreated.Succeeded)
        {
            await userManager.AddToRoleAsync(testUser, "User");
            // Set the UserId of adminProfile
            testUserProfile.UserId = testUser.Id;

            // Update UserProfile in the database
            dbContext.UserProfiles.Update(testUserProfile);
            await dbContext.SaveChangesAsync();
        }
    }
}

void SeedComments()
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Ensure that user profiles exist for the users you created
    var adminUser = userManager.FindByEmailAsync("admin@admin.com").Result;
    var testUser = userManager.FindByEmailAsync("test@test.com").Result;

    if (adminUser != null && testUser != null)
    {
        var wikiPage = dbContext.WikiPages.FirstOrDefault(wp => wp.Title == "Example Page 1");
        if (wikiPage != null)
        {
            var comments = new List<UserComment>
            {
                new UserComment
                {
                    UserProfileId = adminUser.ProfileId,
                    UserProfile = adminUser.Profile,
                    Content = "Test comment from Admin",
                    WikiPageId = wikiPage.Id,
                    PostDate = DateTime.Now,
                    IsReply = false,
                    IsEdited = false
                },
                new UserComment
                {
                    UserProfileId = testUser.ProfileId,
                    UserProfile = testUser.Profile,
                    Content = "Test comment from Tester",
                    WikiPageId = wikiPage.Id,
                    PostDate = DateTime.Now,
                    IsReply = false,
                    IsEdited = false
                },
                new UserComment
                {
                    UserProfileId = testUser.ProfileId,
                    UserProfile = testUser.Profile,
                    Content = "Test comment 2 from Tester",
                    WikiPageId = wikiPage.Id,
                    PostDate = DateTime.Now,
                    IsReply = false,
                    IsEdited = true
                }
            };
            dbContext.UserComments.AddRange(comments);
            dbContext.SaveChanges();
        }
    }
}
