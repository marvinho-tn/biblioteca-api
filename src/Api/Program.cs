using Api.Features;
using Common;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(lb =>
{
    lb.AddConsole();
    lb.SetMinimumLevel(LogLevel.Information);
});

builder.Services.AddFeatures(builder.Configuration);
builder.Services.AddFastEndpoints();

var app = builder.Build();

app.UseFastEndpoints();

app.Run();