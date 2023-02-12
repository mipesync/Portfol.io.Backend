using AutoMapper;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Domain;

namespace Portfol.io.Application.Common.Services.LikeCheck
{
    /// <summary>
    /// Check the user's like album
    /// </summary>
    /// <typeparam name="T">The list type to be returned</typeparam>
    public class UserLikeChecker<T> where T : GetAlbumLookupDto
    {
        private readonly IMapper _mapper;

        public UserLikeChecker(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<T> Check(Guid userId, List<Album> entities)
        {
            var response = new List<T>();

            foreach (var album in entities)
            {
                var dto = _mapper.Map<T>(album);

                if (album.AlbumLikes!.Any(u => u.UserId == userId))
                    dto.IsLiked = true;

                response.Add(dto);
            }

            return response;
        }
    }
}
