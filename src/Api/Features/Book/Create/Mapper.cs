using FastEndpoints;

namespace Api.Features.Book.Create;

internal sealed class Mapper : Mapper<Request, Response, Common.Book>
{
    public override Response FromEntity(Common.Book e)
    {
        return new Response
        (
            e.Id
        );
    }

    public override Common.Book ToEntity(Request r)
    {
        return new Common.Book
        {
            Title = r.Title,
            Author = r.Author,
            ISBN = r.ISBN,
            Publisher = r.Publisher,
            PublishedDate = r.PublishedDate,
            Pages = r.Pages,
            AvailableCopies = r.AvailableCopies,
            TotalCopies = r.TotalCopies,
            Genre = r.Genre
        };
    }
}