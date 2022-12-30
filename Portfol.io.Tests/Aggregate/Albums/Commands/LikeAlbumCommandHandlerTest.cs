using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.Commands.LikeAlbum;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Albums.Commands
{
    public class LikeAlbumCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task LikeAlbumCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new LikeAlbumCommandHandler(Context);

            //Act
            await handler.Handle(
                new LikeAlbumCommand
                {
                    AlbumId = PortfolioContextFactory.Album1,
                    UserId = PortfolioContextFactory.UserBId
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.AlbumLikes.FirstOrDefaultAsync(u => u.UserId == PortfolioContextFactory.UserBId && 
                            u.AlbumId == PortfolioContextFactory.Album1, CancellationToken.None));
        }

        [Fact]
        public async Task LikeAlbumCommandHandlerTest_FailOnWrongAlbumId()
        {
            //Arrange
            var handler = new LikeAlbumCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new LikeAlbumCommand
                    {
                        UserId = PortfolioContextFactory.UserAId,
                        AlbumId = Guid.Empty
                    }, CancellationToken.None);
            });
        }
    }
}
