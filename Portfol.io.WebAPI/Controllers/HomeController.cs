using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Credentials.Commands.CreateCredential;
using Portfol.io.WebAPI.Models;

namespace Portfol.io.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HomeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        //TODO: Посмотреть тутор
        [HttpPost("sign_up")]
        public async Task<IActionResult> Index([FromBody] CreateCredentialDto createCredentialDto)
        {
            var command = _mapper.Map<CreateCredentialCommand>(createCredentialDto);

            var result = await _mediator.Send(command);

            return Json(new { username = result });
        }
    }
}
