using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Albums.Commands
{
    public class RemoveAlbumCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task RemoveAlbumCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new RemoveAlbumCommandHandler(Context);

            //Act
            await handler.Handle(
                new RemoveAlbumCommand
                {
                    Id = PortfolioContextFactory.Album1
                }, CancellationToken.None);

            //Assert
            Assert.Null(await Context.Albums.FirstOrDefaultAsync(u => u.Id == PortfolioContextFactory.Album1, CancellationToken.None));
        }

        [Fact]
        public async Task RemoveAlbumCommandHandlerTest_FailOnWrongId()
        {
            //Arrange
            var handler = new RemoveAlbumCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new RemoveAlbumCommand
                    {
                        Id = Guid.Empty
                    }, CancellationToken.None);
            });
        }
    }
}
