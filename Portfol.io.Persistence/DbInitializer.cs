using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
