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

        public CommandTestFixture()
        {
            Context = PortfolioContextFactory.Create();
            Uploader = new ImageUploader();
        }

        public void Dispose()
        {
            PortfolioContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition(nameof(CommandCollection))]
    public class CommandCollection : ICollectionFixture<CommandTestFixture> { }
}
