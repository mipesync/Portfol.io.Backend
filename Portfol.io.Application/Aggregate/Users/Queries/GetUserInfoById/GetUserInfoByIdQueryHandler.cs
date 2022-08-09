using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserInfoById
{
    public class GetUserInfoByIdQueryHandler : IRequestHandler<GetUserInfoByIdQuery, UserDetailsViewModel>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserInfoByIdQueryHandler(IPortfolioDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (entity == null || entity.Id != request.UserId) throw new NotFoundException(nameof(User), request.UserId);

            return _mapper.Map<UserDetailsViewModel>(entity);
        }
    }
}
