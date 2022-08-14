using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Portfol.io.Application.Aggregate.Users.Commands.UpdateUserImage;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Persistence;
using Portfol.io.Persistence.Services;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Users.Commands
{
    [Collection(nameof(CommandCollection))]
    public class UpdateUserImageCommandHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IImageUploader Uploader;

        public UpdateUserImageCommandHandlerTest(CommandTestFixture fixture)
        {
            Context = fixture.Context;
            Uploader = fixture.Uploader;
        }

        [Fact]
        public async void UpdateUserImageCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new UpdateUserImageCommandHandler(Context, Uploader);
            var webRootPath = "E:/Documents/VisualStudio/Portfol.io.Backend/Portfol.io.WebAPI/wwwroot";

            var file = new Mock<IFormFile>();
            var sourceImg = File.OpenRead("E:/Downloads/BMqtcy1SGasFlJLuXEN5pJBXroCIXXLSwJUxjpqxrIZnZDCDktb8_9ib8KDgunYpG4QLm_LkTH6EVcGO38NLEEFE.jpg");
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(sourceImg);
            writer.Flush();
            ms.Position = 0;
            var fileName = sourceImg.Name;
            file.Setup(f => f.FileName).Returns(fileName).Verifiable();
            file.Setup(_ => _.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Returns((Stream stream, CancellationToken token) => ms.CopyToAsync(stream))
                .Verifiable();

            var inputFile = file.Object;

            //Act
            var result = await handler.Handle(new UpdateUserImageCommand
            {
                Model = new UpdateUserImageViewModel
                {
                    ImageFile = inputFile,
                    WebRootPath = webRootPath,
                    HostUrl = "host_url",
                    UserId = PortfolioContextFactory.UserAId
                }
            }, CancellationToken.None);
            
            //Assert
            Context.Users.FirstOrDefault(u => u.Id == PortfolioContextFactory.UserAId)!.ProfileImagePath.ShouldNotBe("/ProfileImages/default.png");
        }

        [Fact]
        public async Task UpdateUserImageCommandHandlerTest_FailOnWrongUserId()
        {
            //Arrange
            var handler = new UpdateUserImageCommandHandler(Context, Uploader);
            var wrongUserId = Guid.NewGuid();

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateUserImageCommand
                    {
                        Model = new UpdateUserImageViewModel
                        {
                            ImageFile = new Mock<IFormFile>().Object,
                            WebRootPath = "some WRP",
                            HostUrl = "some HU",
                            UserId = wrongUserId
                        }
                    }, CancellationToken.None);
            });
        }
    }
}
