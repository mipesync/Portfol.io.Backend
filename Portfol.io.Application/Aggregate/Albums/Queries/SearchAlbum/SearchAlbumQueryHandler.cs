using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.LikeCheck;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.SearchAlbum
{
    public class SearchAlbumQueryHandler : IRequestHandler<SearchAlbumQuery, AlbumsViewModel>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchAlbumQueryHandler(IMapper mapper, IPortfolioDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Task<AlbumsViewModel> Handle(SearchAlbumQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Album> albums = _dbContext.Albums.Include(u => u.AlbumLikes);
            var queries = request.Query!.Split(' ');

            foreach(var query in queries)
            {
                var condition = albums.Where(p => p.Name.ToLower().Contains(query!) || p.Description!.ToLower().Contains(query!)).ToList();

                albums = condition.Count() != 0 ? condition : albums ;
            }

            if (albums.Count() == 0) throw new NotFoundException(nameof(Album), request.Query);

            var lookUps = new UserLikeChecker<AlbumLookupDto>(_mapper).Check(request.UserId, albums.ToList());

            return Task.FromResult(new AlbumsViewModel { Albums = lookUps });
        }
    }
}
