using Portfol.io.Persistence;

namespace Portfol.io.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly PortfolioDbContext Context;

        protected TestCommandBase()
        {
            Context = PortfolioContextFactory.Create();
        }

        public void Dispose()
        {
            PortfolioContextFactory.Destroy(Context);
        }
    }
}
