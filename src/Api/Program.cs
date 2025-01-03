using Api.Features;
using Api.Features.Book;
using Api.Features.Book.Create;
using Common;
using Confluent.Kafka;
using FastEndpoints;
using EventHandler = System.EventHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(lb =>
{
    lb.AddConsole();
    lb.SetMinimumLevel(LogLevel.Information);
});

builder.Services.AddSingleton(builder.Configuration.GetSection("MongoDb").Get<MongoDbconfig>()!);
builder.Services.AddSingleton(builder.Configuration.GetSection("Kafka:Producer").Get<ProducerConfig>()!);
        
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IEventHandler<BookCreatedEvent>, BookCreatedEventHandler>();
builder.Services.AddTransient<IMongoDbContext, MongoDbContext>();

builder.Services.AddFastEndpoints();

var app = builder.Build();

app.UseFastEndpoints();

app.Run();