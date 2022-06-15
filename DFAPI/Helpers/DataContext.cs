using DFAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
        {
        }
        public DbSet<ActivityRoles> ActivityRoles => Set<ActivityRoles>();
        public DbSet<Services> Services => Set<Services>();
        public DbSet<UnitOfSales> UnitOfSales => Set<UnitOfSales>();
    }
}
