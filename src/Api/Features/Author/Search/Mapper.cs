using FastEndpoints;

namespace Api.Features.Author.Search;

public class Mapper : Mapper<Request, Response[], AuthorSearchResponse>
{
    public override Response[] FromEntity(AuthorSearchResponse e)
    {
        var response = new List<Response>();
        
        foreach (var doc in e.Docs)
        {
            response.Add(new Response (doc.Key, doc.Name));
        }

        return response.ToArray();
    }
}