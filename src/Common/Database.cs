using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Common;

public interface IMongoDbContext
{
    IMongoCollection<Book> Books { get; }
}

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;
    
    public MongoDbContext(MongoDbconfig config)
    {
        var client = new MongoClient(config.ConnectionString);
        
        _database = client.GetDatabase(config.Database);
    }

    public IMongoCollection<Book> Books => _database.GetCollection<Book>(Constants.BooksCollectionName);
}

public class MongoDbconfig
{
    public string ConnectionString { get; set; }
    public string Database { get; set; }
}