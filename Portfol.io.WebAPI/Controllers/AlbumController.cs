using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.LikeAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.WebAPI.Models;
using CreateAlbumDto = Portfol.io.Application.CreateAlbumDto;

namespace Portfol.io.WebAPI.Controllers
{
    /// <summary>
    /// The album controller, which contains all the logic for working with albums.
    /// </summary>
    //[Authorize]
    public class AlbumController : BaseController
    {
        private readonly IMapper _mapper;

        public AlbumController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //TODO: Валидация на лайк. Если альбом принадлежит данному юзеру, то запретить лайк
        [HttpGet("get_all")]
        //[Authorize(Roles = "admin, support")]
        public async Task<IActionResult> GetAlbums()
        {
            try
            {
                var result = await Mediator.Send(new GetAllAlbumsQuery());

                foreach (var album in result.Albums)
                {
                    foreach(var photo in album.Photos!)
                    {
                        photo.Path = $"{UrlRaw}{photo.Path}";
                    }
                }

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet("get_by_id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid albumId)
        {
            try
            {
                var album = await Mediator.Send(new GetAlbumByIdQuery { Id = albumId });

                foreach (var photo in album.Photos!)
                {
                    photo.Path = $"{UrlRaw}{photo.Path}";
                }

                return Ok(album);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet("get_by_userId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            try
            {
                var result = await Mediator.Send(new GetAlbumsByUserIdQuery { UserId = userId });

                foreach (var album in result.Albums)
                {
                    foreach (var photo in album.Photos!)
                    {
                        photo.Path = $"{UrlRaw}{photo.Path}";
                    }
                }

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet("get_by_tags")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTags([FromQuery] IEnumerable<Guid> tagIds)
        {
            try
            {
                var result = await Mediator.Send(new GetAlbumsByTagsQuery { TagIds = tagIds });

                foreach (var album in result.Albums)
                {
                    foreach (var photo in album.Photos!)
                    {
                        photo.Path = $"{UrlRaw}{photo.Path}";
                    }
                }

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateAlbumDto createAlbumDto)
        {
            if (!ModelState.IsValid) return BadRequest(new {message = "Model is not valid."});

            //if (UserId != createAlbumDto.UserId) return BadRequest(new {message = "Wrong user."});

            try
            {
                var guid = await Mediator.Send(_mapper.Map<CreateAlbumCommand>(createAlbumDto));
                return Ok(new {albumId = guid });
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateAlbumDto updateAlbumDto)
        {
            if (!ModelState.IsValid) return BadRequest(new { message = "Model is not valid." });

            try
            {
                await Mediator.Send(_mapper.Map<UpdateAlbumCommand>(updateAlbumDto));
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid albumId)
        {
            try
            {
                await Mediator.Send(new RemoveAlbumCommand { Id = albumId });
                return Ok();
            }
            catch(NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost("like")]
        public async Task<IActionResult> Like(Guid albumId, Guid userId)
        {
            //if (UserId != userId) return BadRequest(new { message = "Wrong user." });

            try
            {
                await Mediator.Send(new LikeAlbumCommand { UserId = userId, AlbumId = albumId });
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        /*[HttpPost("dislike")]
        public async Task<IActionResult> Disike(Guid albumId, Guid userId)
        {
            //if (UserId != userId) return BadRequest(new { message = "Wrong user." });

            try
            {
                await Mediator.Send(new DislikeAlbumCommand { UserId = userId, AlbumId = albumId });
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }*/
    }
}
