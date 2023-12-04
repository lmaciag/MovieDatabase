using MovieDatabase.Application;
using MovieDatabase.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

await app.UseInfrastructureAsync();
app.Run();