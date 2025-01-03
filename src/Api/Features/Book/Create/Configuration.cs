using FastEndpoints;

namespace Api.Features.Book.Create;

public static class Extensions
{
    public static void AddCreate(this IServiceCollection services)
    {
        services.AddTransient<IEventHandler<Event>, EventHandler>();
    }
}