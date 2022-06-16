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
        public DbSet<ActivityMaster> ActivityMaster => Set<ActivityMaster>();
        public DbSet<ServiceMaster> Services => Set<ServiceMaster>();
        public DbSet<UnitOfSalesMaster> UnitOfSales => Set<UnitOfSalesMaster>();
    }
}
