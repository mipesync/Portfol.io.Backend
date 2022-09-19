using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Photos.Commands.AddImage;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Persistence;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Photos.Commands
{
    [Collection(nameof(CommandCollection))]
    public class AddImageCommandHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IImageUploader Uploader;
        private readonly IFormFile ImageFile;

        public AddImageCommandHandlerTest(CommandTestFixture fixture)
        {
            Context = fixture.Context;
            Uploader = fixture.Uploader;
            ImageFile = fixture.ImageFile;
        }

        [Fact]
        public async Task AddImageCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new AddImageCommandHandler(Context, Uploader);
            var webRootPath = "E:/Documents/VisualStudio/Portfol.io.Backend/Portfol.io.WebAPI/wwwroot";

            //Act
            var result = await handler.Handle(
                new AddImageCommand
                {
                    AlbumId = PortfolioContextFactory.Album1,
                    Files = new List<IFormFile> { ImageFile },
                    WebRootPath = webRootPath
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Photos.FirstOrDefaultAsync(u => u.Id == result.First(), CancellationToken.None));
        }

        [Fact]
        public async Task AddImageCommandHandlerTest_FailOnWrongAlbumId()
        {
            //Arrange
            var handler = new AddImageCommandHandler(Context, Uploader);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new AddImageCommand
                    {
                        AlbumId = Guid.Empty,
                        Files = new List<IFormFile> { ImageFile },
                        WebRootPath = "some_wrp"
                    }, CancellationToken.None);
            });
        }
    }
}
