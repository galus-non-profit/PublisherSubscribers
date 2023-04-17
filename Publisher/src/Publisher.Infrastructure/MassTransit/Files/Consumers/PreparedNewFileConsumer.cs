namespace Publisher.Infrastructure.MassTransit.Files.Consumers;

using global::MassTransit;
using Microsoft.Extensions.Logging;
using RabbitPublishSubscribe.Shared.Messages;

internal sealed class PreparedNewFileConsumer : IConsumer<Result>
{
    private readonly ILogger<PreparedNewFileConsumer> logger;

    public PreparedNewFileConsumer(ILogger<PreparedNewFileConsumer> logger)
        => (this.logger) = (logger);

    public Task Consume(ConsumeContext<Result> context)
    {
        this.logger.LogInformation("Processing file type: {fileType}", context.Message.FileExtension);

        return Task.CompletedTask;
    }
}
