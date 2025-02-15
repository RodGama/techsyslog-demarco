using API.TechsysLog;
using API.TechsysLog.DTOs;
using API.TechsysLog.Repositories;
using API.TechsysLog.Repositories.Interfaces;
using API.TechsysLog.Services;
using API.TechsysLog.Services.Interfaces;
using API.TechsysLog.Validations;
using API.TechsysLog.ViewModel;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using System.Net.Mime;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(Mapping));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});



builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IDeliveryRepository, DeliveryRepository>();

builder.Services.AddSingleton<IValidator<UserViewModel>, UserValidation>();
builder.Services.AddSingleton<IValidator<OrderViewModel>, OrderValidation>();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IOrderService, OrderService>();



var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("ASPNETCORE_AUTO_RELOAD_WS_KEY"));


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddHealthChecks().AddSqlServer(
            connectionString: "Server=localhost,1433;" +
                "Database=techsyslog;" +
                "User Id=sa;" +
                "Password=Abc1023123;" +
                "TrustServerCertificate=True",
            healthQuery: "SELECT 1 ",
            name: "sql",
            failureStatus: HealthStatus.Unhealthy,
            tags: new string[] { "db" })
            .AddProcessAllocatedMemoryHealthCheck(
                512,
                name: "Memoria",
                failureStatus: HealthStatus.Unhealthy,
                tags: new string[] { "Memoria" });

var app = builder.Build();

app.UseHealthChecks("/status",
    new HealthCheckOptions()
    {
        ResponseWriter = async (context, report) =>
        {
            var result = JsonSerializer.Serialize(
                    new
                    {
                        currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        statusApplication = report.Status.ToString(),
                        monitors = report.Entries.Select(e => new { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status) })
                    });

            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(result);
        }
    });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
        .WithTheme(ScalarTheme.BluePlanet)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}
else
{
    app.UseExceptionHandler("/error");
}
//app.UseHttpsRedirection();
    
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
