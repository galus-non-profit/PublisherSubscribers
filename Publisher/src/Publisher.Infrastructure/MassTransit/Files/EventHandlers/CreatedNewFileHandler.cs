namespace Publisher.Infrastructure.MassTransit.Files.EventHandlers;

using global::MassTransit;
using Microsoft.Extensions.Logging;
using Publisher.Application.Files.Events;
using RabbitPublishSubscribe.Shared.Messages;

internal sealed class CreatedNewFileHandler : INotificationHandler<CreatedNewFile>
{
    private readonly ILogger<CreatedNewFileHandler> logger;
    private readonly IPublishEndpoint publishEndpoint;

    public CreatedNewFileHandler(ILogger<CreatedNewFileHandler> logger, IPublishEndpoint publishEndpoint)
        => (this.logger, this.publishEndpoint) = (logger, publishEndpoint);

    public async Task Handle(CreatedNewFile notification, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("{CreatedNewFileHandler}", nameof(CreatedNewFileHandler));

        var message = new Request
        {
            FileExtension = notification.FileExtension,
        };

        await this.publishEndpoint.Publish<Request>(message, cancellationToken);
    }
}
