namespace SubscriberIFC.Infrastructure.MassTransit.Files.EventHandlers;

using global::MassTransit;
using Microsoft.Extensions.Logging;
using RabbitPublishSubscribe.Shared.Messages;
using SubscriberIFC.Application.Files.Events;

internal class PreparedThumbnailHandler : INotificationHandler<PreparedThumbnail>
{
    private readonly ILogger<PreparedThumbnailHandler> logger;
    private readonly IPublishEndpoint publishEndpoint;

    public PreparedThumbnailHandler(ILogger<PreparedThumbnailHandler> logger, IPublishEndpoint publishEndpoint)
        => (this.logger, this.publishEndpoint) = (logger, publishEndpoint);

    public Task Handle(PreparedThumbnail notification, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("{handlerName} started", nameof(PreparedThumbnailHandler));

        var message = new Result
        {
            FileExtension = notification.Thumbnail,
        };

        this.publishEndpoint.Publish(message, cancellationToken);

        return Task.CompletedTask;
    }
}
