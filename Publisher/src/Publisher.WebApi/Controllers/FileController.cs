namespace Publisher.WebApi.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Publisher.Application.Files.Commands;

[Route("[controller]/[action]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly ISender mediator;

    public FileController(ISender mediator)
        => (this.mediator) = (mediator);

    [HttpPost(Name = "ConvertNewFile")]
    public async Task<IActionResult> ConvertNewFileAsync(CreateNewFile request, CancellationToken cancellationToken = default)
    {
        await this.mediator.Send(request, cancellationToken);

        return await Task.FromResult(base.Ok());
    }
}
