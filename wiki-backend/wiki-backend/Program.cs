using wiki_backend.DatabaseServices;

var builder = WebApplication.CreateBuilder(args);

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
}