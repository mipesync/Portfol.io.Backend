using AutoMapper;
using Portfol.io.Application.Aggregate.Photos.Commands.AddImage;
using Portfol.io.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Portfol.io.WebAPI.Models
{
    public class AddToAlbumDto : IMapWith<AddImageCommand>
    {
        [Required]
        public ICollection<IFormFile> Files { get; set; } = null!;
        public string? WebRootPath { get; set; }
        [Required]
        public Guid AlbumId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddToAlbumDto, AddImageCommand>()
                .ForMember(command => command.Files, opt => opt.MapFrom(dto => dto.Files))
                .ForMember(command => command.WebRootPath, opt => opt.MapFrom(dto => dto.WebRootPath))
                .ForMember(command => command.AlbumId, opt => opt.MapFrom(dto => dto.AlbumId));
        }
    }
}
