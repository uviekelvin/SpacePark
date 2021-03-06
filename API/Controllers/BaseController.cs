
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


[Route("api/v1/[controller]/[action]")]
public class BaseController: ControllerBase{

  private  IMediator _mediator;

  protected IMediator Mediator=> _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}