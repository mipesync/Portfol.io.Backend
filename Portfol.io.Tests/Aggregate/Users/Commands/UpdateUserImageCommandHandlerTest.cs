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

namespace Portfol.io.Tests.Aggregate.Users.Commands
{
    [Collection(nameof(CommandCollection))]
    public class UpdateUserImageCommandHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IImageUploader Uploader;
        private readonly IFormFile ImadeFile;

        public UpdateUserImageCommandHandlerTest(CommandTestFixture fixture)
        {
            Context = fixture.Context;
            Uploader = fixture.Uploader;
            ImadeFile = fixture.ImageFile;
        }

        [Fact]
        public async void UpdateUserImageCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new UpdateUserImageCommandHandler(Context, Uploader);
            var webRootPath = "E:/Documents/VisualStudio/Portfol.io.Backend/Portfol.io.WebAPI/wwwroot";

            //Act
            var result = await handler.Handle(new UpdateUserImageCommand
            {
                ImageFile = ImadeFile,
                WebRootPath = webRootPath,
                HostUrl = "host_url",
                UserId = PortfolioContextFactory.UserAId
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
                        ImageFile = new Mock<IFormFile>().Object,
                        WebRootPath = "some WRP",
                        HostUrl = "some HU",
                        UserId = wrongUserId
                    }, CancellationToken.None);
            });
        }
    }
}
