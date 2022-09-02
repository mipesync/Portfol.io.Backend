using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums;
using Portfol.io.Application.Common.Exceptions;

namespace Portfol.io.WebAPI.Controllers
{
    public class AlbumController : BaseController
    {
        [HttpGet("get_all")]
        public async Task<IActionResult> GetAlbums()
        {
            try
            {
                var albums = await Mediator.Send(new GetAllAlbumsQuery());
                return Ok(albums);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet("get_by_id")]
        public async Task<IActionResult> GetById(Guid albumId)
        {
            try
            {
                var album = await Mediator.Send(new GetAlbumByIdQuery { Id = albumId });
                return Ok(album);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
