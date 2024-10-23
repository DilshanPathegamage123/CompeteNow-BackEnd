
using CompeteNow.Profile.Application.Services;
using CompeteNow.Profile.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text;

//using CompeteNow.Auth.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
//builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddDbContext<profileDbContext>(options =>
{
    options.UseSqlServer("Server=tcp:competenewserver.database.windows.net,1433;Initial Catalog=competenew;Persist Security Info=False;User ID=tharusha;Password=dinuth@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",

   sqlServerOptions =>
   {
       sqlServerOptions.EnableRetryOnFailure();
   }
           );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://localhost:5173", "http://localhost:5174", "http://localhost:5175", "http://localhost:5176")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowLocalhost");
app.MapControllers();

app.Run();