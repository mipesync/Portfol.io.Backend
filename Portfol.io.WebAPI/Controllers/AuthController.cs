using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Credentials.Commands.CreateCredential;
using Portfol.io.WebAPI.Models;

namespace Portfol.io.WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("sign_up")]
        public async Task<IActionResult> Index([FromBody] CreateCredentialDto createCredentialDto)
        {
            var command = _mapper.Map<CreateCredentialCommand>(createCredentialDto);

            var result = await Mediator.Send(command);

            return Json(new { username = result });
        }
    }
}
