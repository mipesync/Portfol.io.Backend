using AutoMapper;
using Portfol.io.Application.Aggregate.Photos.Commands.AddImage;
using Portfol.io.Application.Common.Mappings;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Portfol.io.WebAPI.Models
{
    public class AddToAlbumDto : IMapWith<AddImageCommand>
    {
        [Required]
        public ICollection<IFormFile> Files { get; set; } = null!;
        [Required]
        public Guid AlbumId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddToAlbumDto, AddImageCommand>()
                .ForMember(command => command.Files, opt => opt.MapFrom(dto => dto.Files))
                .ForMember(command => command.AlbumId, opt => opt.MapFrom(dto => dto.AlbumId));
        }
    }
}
