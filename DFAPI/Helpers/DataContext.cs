﻿using DFAPI.Entities;
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
        public DbSet<UserProfile> UserProfile => Set<UserProfile>();

        public DbSet<GeneralUserProfileResponse> GeneralUserProfileResponse => Set<GeneralUserProfileResponse>();

        public DbSet<LoginUser> LoginUser => Set<LoginUser>();
        public DbSet<UserCount> UserCount => Set<UserCount>();
        #endregion

        #region Admin
        public DbSet<ActivityMaster> ActivityMaster => Set<ActivityMaster>();
        public DbSet<ServiceMaster> ServiceMaster => Set<ServiceMaster>();
        public DbSet<UnitOfSalesMaster> UnitOfSalesMaster => Set<UnitOfSalesMaster>();
        public DbSet<UnitOfProduct> UnitOfProduct => Set<UnitOfProduct>();
        public DbSet<CategoryMaster> CategoryMaster => Set<CategoryMaster>();
        public DbSet<CategoryMasterResponse> CategoryMasterResponse => Set<CategoryMasterResponse>(); 
        public DbSet<CategoryByService> CategoryByService => Set<CategoryByService>();
        public DbSet<ProductMaster> ProductMaster => Set<ProductMaster>();
        public DbSet<Products> Products => Set<Products>();

        public DbSet<ProductResponse> ProductResponse => Set<ProductResponse>();
        public DbSet<ProductsByCategory> ProductsByCategory => Set<ProductsByCategory>();
        public DbSet<RateCardProductsByCategory> RateCardProductsByCategory => Set<RateCardProductsByCategory>();
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
        public DbSet<ProductsByProductID> ProductsByProductID => Set<ProductsByProductID>();
        public DbSet<BrandsByProductID> BrandsByProductID => Set<BrandsByProductID>();
        public DbSet<MaterialSetupMaster> MaterialSetupMaster => Set<MaterialSetupMaster>();
        public DbSet<MaterialProductMapping> MaterialProductMapping => Set<MaterialProductMapping>();
        public DbSet<MaterialSetupMasterGet> MaterialSetupMasterGet => Set<MaterialSetupMasterGet>();
        public DbSet<MaterialProductMappingGet> MaterialProductMappingGet => Set<MaterialProductMappingGet>();
        public DbSet<PostNewDesign> PostNewDesign => Set<PostNewDesign>();

        public DbSet<UserDepartmentMapping> UserDepartmentMapping => Set<UserDepartmentMapping>();
        public DbSet<UserDepartmentMappingList> UserDepartmentMappingList => Set<UserDepartmentMappingList>();

        public DbSet<UserDesignationMapping> UserDesignationMapping => Set<UserDesignationMapping>();
        public DbSet<UserDesignationMappingList> UserDesignationMappingList => Set<UserDesignationMappingList>();

        public DbSet<UserEmployeeListResponse> UserEmployeeListResponse => Set<UserEmployeeListResponse>();
        public DbSet<UserEmployeeSearchResponse> UserEmployeeSearchResponse => Set<UserEmployeeSearchResponse>();
        public DbSet<UsersList> UsersList => Set<UsersList>();
        public DbSet<UserReportingEmployeeResponse> UserReportingEmployeeResponse => Set<UserReportingEmployeeResponse>();
        public DbSet<UserBranchForEmployeeResponse> UserBranchForEmployeeResponse => Set<UserBranchForEmployeeResponse>();
        public DbSet<UserEmployeeList> UserEmployeeList => Set<UserEmployeeList>();
        public DbSet<EmployeeMaster> EmployeeMaster => Set<EmployeeMaster>();
        public DbSet<BranchMaster> BranchMaster => Set<BranchMaster>();
        public DbSet<Companies> Companies => Set<Companies>();
        public DbSet<CompanyList> CompanyList => Set<CompanyList>();
        public DbSet<UserBranchList> UserBranchList => Set<UserBranchList>();

        public DbSet<EmployeeReportingAuthorityResponse> EmployeeReportingAuthorityResponse => Set<EmployeeReportingAuthorityResponse>();


        #endregion

        #region Dealers
        public DbSet<DealerServiceMapping> DealerServiceMapping => Set<DealerServiceMapping>();
        public DbSet<DealerServiceList> DealerServiceList => Set<DealerServiceList>();
        
        public DbSet<BuyerCategoryMaster> BuyerCategoryMaster => Set<BuyerCategoryMaster>();
        public DbSet<BrandMaster> BrandMaster => Set<BrandMaster>();
        public DbSet<DealerBrands> DealerBrands => Set<DealerBrands>();
        public DbSet<DealerBrandResponse> DealerBrandResponse => Set<DealerBrandResponse>();
        public DbSet<DealerBuyerCategoryDiscountMapping> DealerBuyerCategoryDiscountMapping => Set<DealerBuyerCategoryDiscountMapping>();
        public DbSet<DealerBuyerCategoryDiscountMappingGet> DealerBuyerCategoryDiscountMappingGet => Set<DealerBuyerCategoryDiscountMappingGet>(); 
        public DbSet<ShowBrandResponse> ShowBrandResponse => Set<ShowBrandResponse>(); 

        public DbSet<DealerProductMapping> DealerProductMapping => Set<DealerProductMapping>();
        public DbSet<DealerProduct> DealerProduct => Set<DealerProduct>();

        #endregion

        #region General Users
        public DbSet<ImageGallery> ImageGallery => Set<ImageGallery>();
        public DbSet<UserEstimationEnquiries> UserEstimationEnquiries => Set<UserEstimationEnquiries>();
        public DbSet<UserEstimationEnquiriesGet> UserEstimationEnquiriesGet => Set<UserEstimationEnquiriesGet>();
        public DbSet<UserEstimationEnquiriesForMaterialSetup> UserEstimationEnquiriesForMaterialSetup => Set<UserEstimationEnquiriesForMaterialSetup>();
        public DbSet<UserAllEstimationGet> UserAllEstimationGet => Set<UserAllEstimationGet>(); 
        #endregion

        #region Contractor
        public DbSet<ContractorServiceList> ContractorServiceList => Set<ContractorServiceList>();

        public DbSet<ContractorActiveServiceList> ContractorActiveServiceList => Set<ContractorActiveServiceList>();
        public DbSet<ContractorServiceMapping> ContractorServiceMapping => Set<ContractorServiceMapping>();
        public DbSet<Client> Client => Set<Client>();
        public DbSet<ClientGet> ClientGet => Set<ClientGet>();
        public DbSet<ContractorAllEstimationGet> ContractorAllEstimationGet => Set<ContractorAllEstimationGet>();
        public DbSet<ApprovedEstimations> ApprovedEstimations => Set<ApprovedEstimations>(); 
        #endregion

        public DbSet<RowsAffectedResponse> RowsAffected => Set<RowsAffectedResponse>();

        public DbSet<EmployeeReportingAuthority> EmployeeReportingAuthority => Set<EmployeeReportingAuthority>();
        public DbSet<BankDetails> BankDetails => Set<BankDetails>();
        public DbSet<ContractorRateCardList> ContractorRateCardList => Set<ContractorRateCardList>();
        public DbSet<ContractorRateCard> ContractorRateCard => Set<ContractorRateCard>();
        public DbSet<BranchCompanyDetails> BranchCompanyDetails => Set<BranchCompanyDetails>();
        public DbSet<BranchTypes> BranchTypes => Set<BranchTypes>();
        public DbSet<BranchRegionalOfficeList> BranchRegionalOfficeList => Set<BranchRegionalOfficeList>();
        public DbSet<ClientList> ClientList => Set<ClientList>();
        public DbSet<ContractorRateCardMapping> ContractorRateCardMapping => Set<ContractorRateCardMapping>();
        public DbSet<ContractorRateCardMappingItems> ContractorRateCardMappingItems => Set<ContractorRateCardMappingItems>();
        public DbSet<ContractorRateCardSentList> ContractorRateCardSentList => Set<ContractorRateCardSentList>();
        public DbSet<SentQuotationStatusList> SentQuotationStatusList => Set<SentQuotationStatusList>();
        public DbSet<QuotationWiseEstimation> QuotationWiseEstimation => Set<QuotationWiseEstimation>();

        public DbSet<QuotationWiseEstimationList> QuotationWiseEstimationList => Set<QuotationWiseEstimationList>();
        public DbSet<QuotationWiseEstimationItems> QuotationWiseEstimationItems => Set<QuotationWiseEstimationItems>();

        public DbSet<QuotationEstimationProducts> QuotationEstimationProducts => Set<QuotationEstimationProducts>();

    }
}
