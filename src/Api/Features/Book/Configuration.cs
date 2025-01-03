using Api.Features.Book.Create;

namespace Api.Features.Book;

public static class Extensions
{
    public static void AddBook(this IServiceCollection services)
    {
        services.AddCreate();
        services.AddTransient<IRepository, Repository>();
    }
}