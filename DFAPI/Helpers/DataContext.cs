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
        public DbSet<Users> Users => Set<Users>();
        public DbSet<ActivityMaster> ActivityMaster => Set<ActivityMaster>();
        public DbSet<ServiceMaster> ServiceMaster => Set<ServiceMaster>();
        public DbSet<UnitOfSalesMaster> UnitOfSalesMaster => Set<UnitOfSalesMaster>();
        public DbSet<CategoryMaster> CategoryMaster => Set<CategoryMaster>();
        public DbSet<RowsAffectedResponse> RowsAffected => Set<RowsAffectedResponse>();
    }
}
