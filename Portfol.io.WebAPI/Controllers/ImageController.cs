using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Photos.Commands.AddImage;
using Portfol.io.Application.Aggregate.Photos.Queries.GetImageByAlbumId;
using Portfol.io.Application.Aggregate.Photos.Queries.GetImageById;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.WebAPI.Models;

namespace Portfol.io.WebAPI.Controllers
{
    //[Authorize]
    public class ImageController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public ImageController(IMapper mapper, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _environment = environment;
        }

        //ERROR: Исключение при маппинге
        [HttpGet("get_by_albumId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByAlbumId(Guid albumId)
        {
            try
            {
                var result = await Mediator.Send(new GetImagesByAlbumIdQuery { AlbumId = albumId });

                foreach(var photo in result.Images!)
                {
                    photo.Path = $"{_environment.WebRootPath}{photo.Path}";
                }

                return Ok(result);
            }
            catch(NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        //ERROR: Исключение при маппинге
        [HttpGet("get_by_id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid PhotoId)
        {
            try
            {
                var photo = await Mediator.Send(new GetImageByIdQuery { Id = PhotoId });
                photo.Path = $"{_environment.WebRootPath}{photo.Path}";
                return Ok(photo);
            }
            catch(NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost("addToAlbum")]
        public async Task<IActionResult> AddToAlbum([FromForm] AddToAlbumDto addToAlbumDto)
        {
            try
            {
                var command = _mapper.Map<AddImageCommand>(addToAlbumDto);
                command.WebRootPath = _environment.WebRootPath;

                var guid = await Mediator.Send(command);
                return Ok(new { photoId = guid });
            }
            catch(NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
