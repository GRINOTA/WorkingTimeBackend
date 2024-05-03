using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WorkingTime.Domain.Models;
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

        internal int EmployeeId => !User.Identity.IsAuthenticated ? 0 : int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

    }
}
