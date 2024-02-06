using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
       ValidIssuer = config["JwtSettings:Issuer"],
       ValidAudience = config["JwtSettings:Audience"],
       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
       ValidateIssuer = true,
       ValidateAudience = true,
       ValidateLifetime = true,
       ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(IdentityData.AdminUserPolicyName, p => p.RequireClaim(IdentityData.AdminUserClaimName, "true"));
});

// Add services to the container.
AddCors();
AddDbContext();
AddServices();

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

app.MapControllers();

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
                .AllowAnyMethod();
        });
    });
}
void AddDbContext()
{
    builder.Services.AddDbContext<WikiDbContext>();
}

void AddServices()
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddTransient<IWikiPageRepository, WikiPageRepository>();
    builder.Services.AddTransient<IParagraphRepository, ParagraphRepository>();
    builder.Services.AddTransient<IStyleRepository, StyleRepository>();
}