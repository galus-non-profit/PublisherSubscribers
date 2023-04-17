namespace SubscriberPDF.Infrastructure.MassTransit.Files.Consumers;

using global::MassTransit;
using Microsoft.Extensions.Logging;
using RabbitPublishSubscribe.Shared.Messages;
using SubscriberPDF.Application.Files.Commands;

internal sealed class ProcessNewFileConsumer : IConsumer<Request>
{
    private readonly ILogger<ProcessNewFileConsumer> logger;
    private readonly ISender mediator;

    public ProcessNewFileConsumer(ILogger<ProcessNewFileConsumer> logger, ISender mediator)
        => (this.logger, this.mediator) = (logger, mediator);

    public Task Consume(ConsumeContext<Request> context)
    {
        this.logger.LogInformation("{consumerName}", nameof(ProcessNewFileConsumer));
        this.logger.LogInformation("Consuming file with extenstion {extenstion}", context.Message.FileExtension);

        var fileExtension = context.Message.FileExtension;

        if (fileExtension is "PDF")
        {
            var command = new PrepareThumbnail
            {
                FileExtension = fileExtension,
            };

            this.mediator.Send(command, CancellationToken.None);
        }
        else
        {
            this.logger.LogDebug("Unsupported file extension");
        }

        return Task.CompletedTask;
    }
}
