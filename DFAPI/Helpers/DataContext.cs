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
        #region Registration
        public DbSet<Users> Users => Set<Users>();
        public DbSet<LoginUser> LoginUser => Set<LoginUser>();
        public DbSet<UserCount> UserCount => Set<UserCount>();
        #endregion

        #region Admin
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
        public DbSet<DesignTypeByProductID> DesignTypeByProductID => Set<DesignTypeByProductID>(); 
        public DbSet<DesignType> DesignType => Set<DesignType>();
        public DbSet<PostNewDesignMaster> PostNewDesignMaster => Set<PostNewDesignMaster>();
        public DbSet<PostNewDesign> PostNewDesign => Set<PostNewDesign>();
        #endregion

        #region Dealers
        public DbSet<DealerServiceMapping> DealerServiceMapping => Set<DealerServiceMapping>();
        public DbSet<DealerServiceList> DealerServiceList => Set<DealerServiceList>();
        
        public DbSet<BuyerCategoryMaster> BuyerCategoryMaster => Set<BuyerCategoryMaster>();
        public DbSet<BrandMaster> BrandMaster => Set<BrandMaster>();
        public DbSet<DealerBrands> DealerBrands => Set<DealerBrands>();
        public DbSet<DealerBrandResponse> DealerBrandResponse => Set<DealerBrandResponse>();
        public DbSet<ShowBrandResponse> ShowBrandResponse => Set<ShowBrandResponse>(); 

        public DbSet<DealerProductMapping> DealerProductMapping => Set<DealerProductMapping>();
        public DbSet<DealerProduct> DealerProduct => Set<DealerProduct>();
        
        #endregion

        public DbSet<RowsAffectedResponse> RowsAffected => Set<RowsAffectedResponse>();
    }
}
