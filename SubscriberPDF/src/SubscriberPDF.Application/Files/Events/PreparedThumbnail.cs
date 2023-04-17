namespace SubscriberPDF.Application.Files.Events;

public sealed class PreparedThumbnail : INotification
{
    public string Thumbnail { get; init; } = string.Empty;
}
