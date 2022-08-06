using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserInfoById
{
    public class GetUserInfoByIdQuery : IRequest<UserDetailsVm>
    {
        public Guid UserId { get; set; }
    }
}
