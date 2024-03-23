using GymManager.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();

builder.Services.AddDatabase();

var app = builder.Build();

app.Run();
