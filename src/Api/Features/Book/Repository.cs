using Common;

namespace Api.Features.Book;

public interface IBookRepository
{
    Task InsertAsync(Common.Book book, CancellationToken ct);
}

public sealed class BookRepository(IMongoDbContext dbContext, ILogger<BookRepository> logger) : IBookRepository
{
    public async Task InsertAsync(Common.Book book, CancellationToken ct)
    {
        logger.LogInformation("Inserting book with id {Id}", book.Id);

        await dbContext.Books.InsertOneAsync(book, null, ct);

        logger.LogInformation("Book inserted successfully with id {Id}", book.Id);
    }
}