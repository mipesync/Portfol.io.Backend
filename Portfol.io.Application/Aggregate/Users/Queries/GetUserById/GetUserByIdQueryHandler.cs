using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Interfaces;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IMapper mapper, IPortfolioDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            //FIXME: Возможно неправильно. Если да, то надо разобраться с AlbumLookupDto списком в UserViewModel
            //NOTE: Посмотреть на лайки, мб добавить
            var entity = await _dbContext.Users.Include(u => u.UserAlbums).FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            return _mapper.Map<UserViewModel>(entity);
        }
    }
}
