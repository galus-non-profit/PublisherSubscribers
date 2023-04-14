namespace SubscriberPDF.Infrastructure.MassTransit.Files.Consumers;

using global::MassTransit;
using Microsoft.Extensions.Logging;
using RabbitPublishSubscribe.Shared.Messages;

internal sealed class ProcessNewFileConsumer : IConsumer<Request>
{
    private readonly ILogger<ProcessNewFileConsumer> logger;

    public ProcessNewFileConsumer(ILogger<ProcessNewFileConsumer> logger)
        => (this.logger) = (logger);

    public Task Consume(ConsumeContext<Request> context)
    {
        this.logger.LogInformation("Consuming file with extenstion {extenstion}", context.Message);

        return Task.CompletedTask;
    }
}
