using FoodStoreApi.Implementations;
using Microsoft.EntityFrameworkCore;
using Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Implementations
RepositoryImplementations.ImplementRepositories(builder.Services);
ManagerImplementations.ImplementManagers(builder.Services);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbEntity>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn-string")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
