using MovieDatabase.Application;
using MovieDatabase.Infrastructure;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

await app.UseInfrastructureAsync();
app.Run();