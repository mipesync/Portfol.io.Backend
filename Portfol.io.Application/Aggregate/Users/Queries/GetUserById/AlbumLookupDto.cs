using AutoMapper;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Users.Queries.GetUserById
{
    public class AlbumLookupDto : IMapWith<Album>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Likes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, AlbumLookupDto>()
                .ForMember(albumLD => albumLD.Id, opt => opt.MapFrom(album => album.Id))
                .ForMember(albumLD => albumLD.Name, opt => opt.MapFrom(album => album.Name))
                .ForMember(albumLD => albumLD.Description, opt => opt.MapFrom(album => album.Description))
                .ForMember(albumLD => albumLD.CreationDate, opt => opt.MapFrom(album => album.CreationDate))
                .ForMember(albumLD => albumLD.Likes, opt => opt.MapFrom(album => album.AlbumLikes!.Count));
        }
    }
}
