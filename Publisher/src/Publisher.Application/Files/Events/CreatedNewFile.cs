namespace Publisher.Application.Files.Events;

public sealed record CreatedNewFile : INotification
{
    public string FileExtension { get; init; } = string.Empty;
}
