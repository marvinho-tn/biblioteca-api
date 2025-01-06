using FastEndpoints;

namespace Api.Features.Author.Search;

public class Endpoint(IAuthorService service) : Endpoint<Request, Response[], Mapper>
{
    public override void Configure()
    {
        Get("authors/search");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var authors = await service.SearchAsync(req.Query);
        var response = Map.FromEntity(authors);

        await SendAsync(response);
    }
}