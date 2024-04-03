using GymManager.API.Extensions;
using GymManager.Infrastructure;
using GymManager.Application;
using GymManager.API.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddSwagger();

builder.Services
    .AddInfrastructure()
    .AddApplication();

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });

app.MapControllers();

app.Run();
