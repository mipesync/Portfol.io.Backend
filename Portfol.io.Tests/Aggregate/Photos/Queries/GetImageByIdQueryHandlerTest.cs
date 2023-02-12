using AutoMapper;
using Portfol.io.Application.Aggregate.Photos.DTO;
using Portfol.io.Application.Aggregate.Photos.Queries.GetImageById;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Persistence;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Photos.Queries
{
    [Collection(nameof(QueryCollection))]
    public class GetImageByIdQueryHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IMapper Mapper;

        public GetImageByIdQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetImageByIdQueryHandlerTest_Success()
        {
            //Arrange
            var handler = new GetImageByIdQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetImageByIdQuery
                {
                    Id = PortfolioContextFactory.Photo1
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType(typeof(GetImageByIdDto));
        }

        [Fact]
        public async Task GetImageByIdQueryHandlerTest_FailOnWrongId()
        {
            //Arrange
            var handler = new GetImageByIdQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new GetImageByIdQuery
                    {
                        Id = Guid.Empty
                    }, CancellationToken.None);
            });
        }
    }
}
