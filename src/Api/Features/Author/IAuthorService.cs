using Refit;

namespace Api.Features.Author;

public record AuthorDocResponse(string Key, string Name);
public record AuthorSearchResponse(int NumFound, List<AuthorDocResponse> Docs);
public record AuthorResponse(string Key, string Name, string Bio, List<string> Works);

public interface IAuthorService
{
    [Get("/authors/{key}.json")]
    Task<AuthorResponse> GetByKeyAsync(string key);
    
    [Get("/search/authors.json?q={query}")]
    Task<AuthorSearchResponse> SearchAsync(string query);
}