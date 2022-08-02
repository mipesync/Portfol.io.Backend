using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Aggregate.Users.Commands.UpdateUserImage
{
    public class UpdateUserImageCommand : IRequest<Unit>
    {
        public IFormFile ImageFile { get; set; } = null!;
        public string WebRootPath { get; set; } = null!;
        public string HostUrl { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
