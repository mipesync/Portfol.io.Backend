using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Credentials.Commands.CreateCredential;
using Portfol.io.Application.Aggregate.Credentials.Commands.ResetPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Asd()
        {

        }
    }
}
