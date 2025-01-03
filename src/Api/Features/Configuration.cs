using Api.Features.Book;
using Common;
using Confluent.Kafka;

namespace Api.Features;

public static class Extensions
{
    public static void AddFeatures(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<MongoDbconfig>(configuration.GetSection("MongoDb").Get<MongoDbconfig>());
        services.AddSingleton<ProducerConfig>(configuration.GetSection("Kafka:Producer").Get<ProducerConfig>());
        
        services.AddTransient<IMongoDbContext, MongoDbContext>();
        
        services.AddBook();
    }
}