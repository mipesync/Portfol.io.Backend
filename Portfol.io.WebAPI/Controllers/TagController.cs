using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Tags.Commands.AddTag;
using Portfol.io.Application.Aggregate.Tags.Commands.DeleteTag;
using Portfol.io.Application.Aggregate.Tags.Queries.GetTags;
using Portfol.io.Application.Common.Exceptions;

namespace Portfol.io.WebAPI.Controllers
{
    [Authorize(Roles = "employee, admin, support")]
    public class TagController : BaseController
    {
        [HttpGet("getTags")]
        public async Task<IActionResult> GetTags()
        {
            try
            {
                var tags = await Mediator.Send(new GetTagsQuery());

                return Ok(tags);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost("addTag")]
        public async Task<IActionResult> AddTag(string name)
        {
            var result = await Mediator.Send(new AddTagCommand { Name = name });

            return Ok(new {tagId = result});
        }

        [HttpDelete("deleteTag")]
        public async Task<IActionResult> DeleteTag(Guid tagId)
        {
            try
            {
                await Mediator.Send(new DeleteTagCommand { Id = tagId });

                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(new {message = e.Message});
            }
        }
    }
}
