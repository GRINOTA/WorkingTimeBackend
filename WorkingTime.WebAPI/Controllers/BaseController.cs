using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Claims;

namespace WorkingTime.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => 
            _mediator ??=HttpContext.RequestServices.GetService<IMediator>();

    }
}
