namespace Portfol.io.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(PortfolioDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
