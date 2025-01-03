using Common;
using Confluent.Kafka;
using FastEndpoints;

namespace Api.Features.Book.Create;

internal sealed class Event
{
    public string BookId { get; set; }
}

internal sealed class EventHandler(ProducerConfig producerConfig, ILogger<EventHandler> logger) : IEventHandler<Event>
{
    private readonly IProducer<string, Event> _producer =  new ProducerBuilder<string, Event>(producerConfig)
        .SetValueSerializer(new CustomJsonSerializer<Event>())
        .Build();
    
    public async Task HandleAsync(Event eventModel, CancellationToken ct)
    {
        logger.LogInformation("Handling event for book created {BookId}", eventModel.BookId);
        
        var message = new Message<string, Event>
        {
            Key = Guid.NewGuid().ToString(),
            Value = eventModel
        };
        
        await _producer.ProduceAsync(Constants.BookCreatedTopicName, message, ct);
    }
}