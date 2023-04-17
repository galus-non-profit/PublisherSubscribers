namespace SubscriberPDF.Application.Files.CommandHandlers;

using Microsoft.Extensions.Logging;
using SubscriberPDF.Application.Files.Commands;
using SubscriberPDF.Application.Files.Events;

internal sealed class PrepareThumbnailHandler : IRequestHandler<PrepareThumbnail>
{
    private readonly ILogger<PrepareThumbnailHandler> logger;
    private readonly IPublisher mediator;

    public PrepareThumbnailHandler(ILogger<PrepareThumbnailHandler> logger, IPublisher mediator)
        => (this.logger, this.mediator) = (logger, mediator);

    public Task Handle(PrepareThumbnail request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("{handlerName} started", nameof(PrepareThumbnailHandler));

        this.logger.LogInformation("File with extension {fileExtension} prepared", request.FileExtension);

        var notification = new PreparedThumbnail
        {
            Thumbnail = request.FileExtension,
        };

        this.mediator.Publish(notification, cancellationToken);

        return Task.CompletedTask;
    }
}
