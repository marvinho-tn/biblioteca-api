using FastEndpoints;
using FluentValidation;

namespace Api.Features.Book.Create;

public sealed record Request(
    string Title,
    string Author,
    string ISBN,
    string Publisher,
    DateTime PublishedDate,
    int Pages,
    int AvailableCopies,
    int TotalCopies,
    string Genre
);

public sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Author).NotEmpty();
        RuleFor(x => x.ISBN).NotEmpty();
        RuleFor(x => x.Publisher).NotEmpty();
        RuleFor(x => x.PublishedDate).NotEmpty();
        RuleFor(x => x.Pages).GreaterThan(0);
        RuleFor(x => x.Genre).NotEmpty();
    }
}

public sealed record Response(
    string Id
);