﻿using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Photos.Commands.DeleteImage;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Tests.Common;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Photos.Commands
{
    public class DeleteImageCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task DeleteImageCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new DeleteImageCommandHandler(Context);
            var webRootPath = "E:/Documents/VisualStudio/Portfol.io.Backend/Portfol.io.WebAPI/wwwroot";

            //Act
            await handler.Handle(
                new DeleteImageCommand
                {
                    AlbumId = 1,
                    PhotoId = 1,
                    WebRootPath = webRootPath
                }, CancellationToken.None);

            //Assert
            Assert.Null(await Context.Photos.FirstOrDefaultAsync(u => u.Id == 1, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteImageCommandHandlerTest_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteImageCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new DeleteImageCommand
                    {
                        AlbumId = 1,
                        PhotoId = 0,
                        WebRootPath = "some_path"
                    }, CancellationToken.None);
            });
        }
    }
}
