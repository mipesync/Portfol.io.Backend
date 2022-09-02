using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.Commands.DislikeAlbum;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Albums.Commands
{
    public class DislikeAlbumCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task DislikeAlbumCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new DislikeAlbumCommandHandler(Context);

            //Act
            await handler.Handle(
                new DislikeAlbumCommand
                {
                    AlbumId = PortfolioContextFactory.Album1,
                    UserId = PortfolioContextFactory.UserAId
                }, CancellationToken.None);

            //Assert
            Assert.Null(await Context.AlbumLikes.FirstOrDefaultAsync(u => u.AlbumId == PortfolioContextFactory.Album1 && u.UserId == PortfolioContextFactory.UserAId, CancellationToken.None));
        }

        [Fact]
        public async Task DislikeAlbumCommandHandlerTest_FailOnEntityNotExists()
        {
            //Arrange
            var handler = new DislikeAlbumCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new DislikeAlbumCommand
                    {
                        AlbumId = Guid.Empty,
                        UserId = PortfolioContextFactory.UserBId
                    }, CancellationToken.None);
            });
        }
    }
}
