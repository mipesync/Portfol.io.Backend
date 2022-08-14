using AutoMapper;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Application.Interfaces;
using Portfol.io.Persistence;
using Xunit;

namespace Portfol.io.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public PortfolioDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = PortfolioContextFactory.Create();
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IPortfolioDbContext).Assembly));
            });
            Mapper = mapperConfig.CreateMapper();

        }

        public void Dispose()
        {
            PortfolioContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition(nameof(QueryCollection))]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
