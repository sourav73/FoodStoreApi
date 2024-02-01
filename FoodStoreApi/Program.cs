using FoodStoreApi.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;


var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "foodStorePolicy";

// Add services to the container.

builder.Services.AddControllers();
// Implementations
RepositoryImplementations.ImplementRepositories(builder.Services);
ManagerImplementations.ImplementManagers(builder.Services);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbEntity>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn-string")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Food Store api v1", Version = "v1", Description = "API Version 1.0" });
    c.EnableAnnotations();
});

// Cors
string[] corsOrigins = builder.Configuration.GetSection("CorsOrigins:AllowedOrigins").Get<string[]>() ?? [];

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
                      policy =>
                      {
                          policy.WithOrigins(corsOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
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

app.UseCors(corsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
