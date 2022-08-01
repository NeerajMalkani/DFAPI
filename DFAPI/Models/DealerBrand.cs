using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class BrandMaster
    {
        [Key]
        public long ID { get; set; }
        public long DealerID { get; set; }
        public string? BrandName { get; set; }
        public bool? Display { get; set; }
    }

    public class DealerBrands
    {
        [Key]
        public long ID { get; set; }
        public long DealerID { get; set; }
        public long ServiceID { get; set; }
        public long CategoryID { get; set; }
        public long BrandID { get; set; }
        public long UnitOfSalesID { get; set; }
        public string? BrandPrefixName { get; set; }
        public decimal GeneralDiscount { get; set; }
        public decimal AppProviderDiscount { get; set; }
        public decimal ReferralPoints { get; set; }
        public decimal ContractorDiscount { get; set; }
        public bool? Display { get; set; }
    }

    public class DealerBrandResponse
    {
        [Key]
        public long ID { get; set; }
        public long ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public long CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public long BrandID { get; set; }
        public string? BrandName { get; set; }
        public long UnitOfSalesID { get; set; }
        public string? UnitName { get; set; }
        public string? BrandPrefixName { get; set; }
        public decimal GeneralDiscount { get; set; }
        public decimal AppProviderDiscount { get; set; }
        public decimal ReferralPoints { get; set; }
        public decimal ContractorDiscount { get; set; }
        public bool? Display { get; set; }
    }

    public class BuyerCategoryMaster
    {
        [Key]
        public long ID { get; set; }
        public long DealerID { get; set; }
        public string? BuyerCategoryName { get; set; }
        public bool? Display { get; set; }
    }

    [Keyless]
    public class ShowBrandResponse
    {
        public bool? ShowBrand { get; set; }
    }
}
