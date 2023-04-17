namespace SubscriberIFC.Application.Files.Commands;

public sealed class PrepareThumbnail : IRequest
{
    public string FileExtension { get; init; } = string.Empty;
}
