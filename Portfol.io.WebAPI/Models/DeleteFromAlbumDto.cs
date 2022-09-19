using AutoMapper;
using Portfol.io.Application.Aggregate.Photos.Commands.DeleteImage;
using Portfol.io.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Portfol.io.WebAPI.Models
{
    public class DeleteFromAlbumDto : IMapWith<DeleteImageCommand>
    {
        [Required]
        public Guid AlbumId { get; set; }
        [Required]
        public Guid ImageId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteFromAlbumDto, DeleteImageCommand>()
                .ForMember(command => command.AlbumId, opt => opt.MapFrom(dto => dto.AlbumId))
                .ForMember(command => command.ImageId, opt => opt.MapFrom(dto => dto.ImageId));
        }
    }
}
