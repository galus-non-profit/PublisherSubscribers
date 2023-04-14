namespace Publisher.Application.Files.Commands;

public sealed record CreateNewFile : IRequest
{
    public string FileExtension { get; init; } = string.Empty;
}
