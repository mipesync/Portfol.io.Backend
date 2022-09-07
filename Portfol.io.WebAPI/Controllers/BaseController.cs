using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Portfol.io.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        private IMediator _mediator = null!;
        protected HttpContext Context => HttpContext;
        protected string UrlRaw => $"{Request.Scheme}://{Request.Host}";
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
        internal Guid UserId => !User.Identity!.IsAuthenticated ? Guid.Empty : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    }
}
