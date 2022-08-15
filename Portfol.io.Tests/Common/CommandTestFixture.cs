using Microsoft.AspNetCore.Http;
using Moq;
using Portfol.io.Application.Interfaces;
using Portfol.io.Persistence;
using Portfol.io.Persistence.Services;
using Xunit;

namespace Portfol.io.Tests.Common
{
    public class CommandTestFixture : IDisposable
    {
        public PortfolioDbContext Context;
        public IImageUploader Uploader;
        public IFormFile ImageFile;

        public CommandTestFixture()
        {
            Context = PortfolioContextFactory.Create();
            Uploader = new ImageUploader();


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

            ImageFile = file.Object;
        }

        public void Dispose()
        {
            PortfolioContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition(nameof(CommandCollection))]
    public class CommandCollection : ICollectionFixture<CommandTestFixture> { }
}
