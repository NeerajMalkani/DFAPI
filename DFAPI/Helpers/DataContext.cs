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
        public DbSet<LoginUser> LoginUser => Set<LoginUser>();
        public DbSet<UserCount> UserCount => Set<UserCount>();
        public DbSet<ActivityMaster> ActivityMaster => Set<ActivityMaster>();
        public DbSet<ServiceMaster> ServiceMaster => Set<ServiceMaster>();
        public DbSet<UnitOfSalesMaster> UnitOfSalesMaster => Set<UnitOfSalesMaster>();
        public DbSet<CategoryMaster> CategoryMaster => Set<CategoryMaster>();
        public DbSet<CategoryByService> CategoryByService => Set<CategoryByService>();
        public DbSet<ProductMaster> ProductMaster => Set<ProductMaster>();
        public DbSet<Products> Products => Set<Products>();
        public DbSet<ProductsByCategory> ProductsByCategory => Set<ProductsByCategory>();
        public DbSet<DepartmentMaster> DepartmentMaster => Set<DepartmentMaster>();
        public DbSet<LocationTypeMaster> LocationTypeMaster => Set<LocationTypeMaster>();
        public DbSet<LocationTypeMasterMapped> LocationTypeMasterMapped => Set<LocationTypeMasterMapped>();
        public DbSet<LocationType> LocationType => Set<LocationType>();
        public DbSet<DesignationMaster> DesignationMaster => Set<DesignationMaster>();
        public DbSet<EWayBillMaster> EWayBillMaster => Set<EWayBillMaster>();
        public DbSet<EWayBills> EWayBills => Set<EWayBills>(); 
        public DbSet<StateMaster> StateMaster => Set<StateMaster>();
        public DbSet<CityMaster> CityMaster => Set<CityMaster>();

        public DbSet<WorkFloorMaster> WorkFloorMaster => Set<WorkFloorMaster>();
        public DbSet<WorkLocationMaster> WorkLocationMaster => Set<WorkLocationMaster>();
        public DbSet<DesignTypeMaster> DesignTypeMaster => Set<DesignTypeMaster>();
        public DbSet<DesignType> DesignType => Set<DesignType>();

        public DbSet<RowsAffectedResponse> RowsAffected => Set<RowsAffectedResponse>();
    }
}
