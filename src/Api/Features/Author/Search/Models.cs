namespace Api.Features.Author.Search;

public sealed record Request(string Query);

public sealed record Response(string Id, string Name);