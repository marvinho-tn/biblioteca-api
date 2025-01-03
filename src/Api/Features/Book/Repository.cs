using Common;

namespace Api.Features.Book;

internal interface IRepository
{
    Task InsertAsync(Common.Book book, CancellationToken ct);
}

internal sealed class Repository(IMongoDbContext dbContext, ILogger<Repository> logger) : IRepository
{
    public async Task InsertAsync(Common.Book book, CancellationToken ct)
    {
        logger.LogInformation("Inserting book with id {Id}", book.Id);

        await dbContext.Books.InsertOneAsync(book, null, ct);

        logger.LogInformation("Book inserted successfully with id {Id}", book.Id);
    }
}