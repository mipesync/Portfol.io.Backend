using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.DeleteAlbumCover;
using Portfol.io.Application.Aggregate.Albums.Commands.LikeAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.MarkAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbumCover;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums;
using Portfol.io.Application.Aggregate.Albums.Queries.GetMarkedAlbums;
using Portfol.io.Application.Aggregate.Albums.Queries.SearchAlbum;
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
        private readonly IWebHostEnvironment _environment;

        public AlbumController(IMapper mapper, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet("getAll")]
        //[Authorize(Roles = "admin, support")]
        public async Task<IActionResult> GetAlbums()
        {
            try
            {
                var result = await Mediator.Send(new GetAllAlbumsQuery { UserId = UserId });
                
                foreach (var album in result.Albums)
                {
                    album.Cover = UrlRaw + album.Cover;
                }

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid albumId)
        {
            try
            {
                var query = new GetAlbumByIdQuery { Id = albumId };
                query.UserId = UserId;

                var album = await Mediator.Send(query);
                album.Cover = UrlRaw + album.Cover;

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

        [HttpGet("getByUserId")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            try
            {
                var query = new GetAlbumsByUserIdQuery { UserId = userId };
                query.AUserId = UserId;

                var result = await Mediator.Send(query);

                foreach (var album in result.Albums)
                {
                    album.Cover = UrlRaw + album.Cover;
                }

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet("getByTags")]
        public async Task<IActionResult> GetByTags([FromQuery] IEnumerable<Guid> tagIds)
        {
            try
            {
                var query = new GetAlbumsByTagsQuery { TagIds = tagIds };
                query.UserId = UserId;

                var result = await Mediator.Send(query);

                foreach (var album in result.Albums)
                {
                    album.Cover = UrlRaw + album.Cover;
                }

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet("getMarked")]
        public async Task<IActionResult> GetMarked()
        {
            try
            {
                var result = await Mediator.Send(new GetMarkedAlbumsQuery { UserId = UserId });

                foreach (var album in result.Albums)
                {
                    album.Cover = UrlRaw + album.Cover;
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

            try
            {
                var command = _mapper.Map<CreateAlbumCommand>(createAlbumDto);
                command.UserId = UserId;

                var guid = await Mediator.Send(command);
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
        public async Task<IActionResult> Like(Guid albumId)
        {
            try
            {
                await Mediator.Send(new LikeAlbumCommand { UserId = UserId, AlbumId = albumId });
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(string query)
        {
            var result = await Mediator.Send(new SearchAlbumQuery
            {
                Query = query.ToLower(),
                UserId = UserId
            });

            foreach (var album in result.Albums)
            {
                album.Cover = UrlRaw + album.Cover;
            }

            return Ok(result);
        }

        [HttpPut("updateCover")]
        public async Task<IActionResult> UpdateCover(IFormFile file, Guid AlbumId)
        {
            try
            {
                var command = new UpdateAlbumCoverCommand
                {
                    AlbumId = AlbumId,
                    Image = file,
                    WebRootPath = _environment.WebRootPath,
                    UserId = UserId
                };

                await Mediator.Send(command);

                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete("deleteCover")]
        public async Task<IActionResult> DeleteCover(Guid AlbumId)
        {
            try
            {
                var command = new DeleteAlbumCoverCommand
                {
                    AlbumId = AlbumId,
                    WebRootPath = _environment.WebRootPath,
                    UserId = UserId
                };

                await Mediator.Send(command);

                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("markAlbum")]
        public async Task<IActionResult> MarkAlbum(Guid AlbumId)
        {
            try
            {
                var command = new MarkAlbumCommand
                {
                    AlbumId = AlbumId,
                    UserId = UserId
                };

                await Mediator.Send(command);

                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
