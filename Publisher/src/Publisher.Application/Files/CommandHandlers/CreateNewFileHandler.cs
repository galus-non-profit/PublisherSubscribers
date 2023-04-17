namespace Publisher.Application.Files.CommandHandlers;

using Microsoft.Extensions.Logging;
using Publisher.Application.Files.Commands;
using Publisher.Application.Files.Events;

internal sealed class CreateNewFileHandler : IRequestHandler<CreateNewFile>
{
    private readonly ILogger<CreateNewFileHandler> logger;
    private readonly IPublisher mediator;

    public CreateNewFileHandler(ILogger<CreateNewFileHandler> logger, IPublisher mediator)
        => (this.logger, this.mediator) = (logger, mediator);

    public async Task Handle(CreateNewFile request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("{CreateNewFileHandler} started", nameof(CreateNewFileHandler));

        var @event = new CreatedNewFile
        {
            FileExtension = request.FileExtension,
        };

        await this.mediator.Publish(@event, cancellationToken);
    }
}
