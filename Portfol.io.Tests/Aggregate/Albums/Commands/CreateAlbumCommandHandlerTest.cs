using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum;
using Portfol.io.Domain;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Albums.Commands
{
    public class CreateAlbumCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateAlbumCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new CreateAlbumCommandHandler(Context);

            //Act
            var result = await handler.Handle(
                new CreateAlbumCommand
                {
                    Name = "Album1",
                    Description = "Album1 has been created",
                    UserId = PortfolioContextFactory.UserAId,
                    Tags = new List<Tag> 
                    { 
                        new Tag { Name = "tag_1" }, 
                        new Tag { Name = "tag_2" }, 
                        new Tag { Name = "tag_3" }, 
                    }
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Albums.FirstOrDefaultAsync(u => u.Id == result, CancellationToken.None));
        }
    }
}
