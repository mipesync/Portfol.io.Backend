using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Albums.Commands
{
    public class UpdateAlbumCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task UpdateAlbumCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new UpdateAlbumCommandHandler(Context);
            var newName = "new name";

            //Act
            await handler.Handle(
                new UpdateAlbumCommand
                {
                    Id = PortfolioContextFactory.Album1,
                    Name = newName
                }, CancellationToken.None);

            //Assert
            var result = await Context.Albums.FirstOrDefaultAsync(u => u.Id == PortfolioContextFactory.Album1, CancellationToken.None);
            result!.Name.ShouldBe(newName);
        }

        [Fact]
        public async Task UpdateAlbumCommandHandlerTest_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateAlbumCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateAlbumCommand
                    {
                        Id = Guid.Empty,
                        Name = "New name"
                    }, CancellationToken.None);
            });
        }
    }
}
