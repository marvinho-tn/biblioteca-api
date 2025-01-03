using Common;
using Confluent.Kafka;
using FastEndpoints;

namespace Api.Features.Book.Create;

public sealed class BookCreatedEvent
{
    public string BookId { get; set; }
}

public sealed class BookCreatedEventHandler(ProducerConfig producerConfig, ILogger<BookCreatedEventHandler> logger) : IEventHandler<BookCreatedEvent>
{
    private readonly IProducer<string, BookCreatedEvent> _producer =  new ProducerBuilder<string, BookCreatedEvent>(producerConfig)
        .SetValueSerializer(new CustomJsonSerializer<BookCreatedEvent>())
        .Build();
    
    public async Task HandleAsync(BookCreatedEvent bookCreatedEventModel, CancellationToken ct)
    {
        logger.LogInformation("Handling event for book created {BookId}", bookCreatedEventModel.BookId);
        
        var message = new Message<string, BookCreatedEvent>
        {
            Key = Guid.NewGuid().ToString(),
            Value = bookCreatedEventModel
        };
        
        await _producer.ProduceAsync(Constants.BookCreatedTopicName, message, ct);
    }
}