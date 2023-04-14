namespace SubscriberIFC.WebApi.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController, Route("[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected ISender Mediator => this.mediator ??= HttpContext.RequestServices.GetService<ISender>();
    private ISender mediator;
}
