using FastEndpoints;

namespace Api.Features.Book.Create;

internal sealed class Endpoint(IRepository repository, ILogger<Endpoint> logger) : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        logger.LogInformation("Request received for book creation");
        
        var book = Map.ToEntity(req);
        
        book.Id = Guid.NewGuid().ToString();

        await repository.InsertAsync(book, ct);
        
        var @event = new Event
        {
            BookId = book.Id
        };

        await PublishAsync(@event, Mode.WaitForAll, ct);

        var res = Map.FromEntity(book);

        await SendAsync(res, 201, ct);
    }
}