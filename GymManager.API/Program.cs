using GymManager.API.Extensions;
using GymManager.Infrastructure;
using GymManager.Application;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddConfiguration();

builder.Services
    .AddInfrastructure()
    .AddApplication();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
