using AutoMapper;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.DTO
{
    public class GetAlbumLookupDto : IMapWith<Album>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserId { get; set; }
        public bool IsLiked { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, GetAlbumLookupDto>()
                .ForMember(albumLookup => albumLookup.Id, opt => opt.MapFrom(album => album.Id))
                .ForMember(albumLookup => albumLookup.Name, opt => opt.MapFrom(album => album.Name))
                .ForMember(albumLookup => albumLookup.Description, opt => opt.MapFrom(album => album.Description))
                .ForMember(albumLookup => albumLookup.Cover, opt => opt.MapFrom(album => album.Cover))
                .ForMember(albumLookup => albumLookup.CreationDate, opt => opt.MapFrom(album => album.CreationDate))
                .ForMember(albumLookup => albumLookup.UserId, opt => opt.MapFrom(album => album.UserId))
                .ForMember(albumLookup => albumLookup.Likes, opt => opt.MapFrom(album => album.AlbumLikes!.Count))
                .ForMember(albumLookup => albumLookup.Views, opt => opt.MapFrom(album => album.Views));

        }
    }
}
