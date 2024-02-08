//using KonyvtarBackEnd.Service.IEmailServices;
//using KonyvtarBackEnd.Service;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("interactions", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Niggerveszedelem",
                      builder =>
                      {
                          builder.WithOrigins("http://127.0.0.1:5500","http://localhost:3000","http://localhost:3001")
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Niggerveszedelem");

app.MapControllers();

app.Run();
