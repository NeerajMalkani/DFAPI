using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class DealerProductMapping
    {
        [Key]
        public long ID { get; set; }
        public long DealerID { get; set; }
        public long BrandID { get; set; }
        public long ProductID { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public decimal UnitValue { get; set; }
        public string? Description { get; set; }
        public bool Display { get; set; }
    }

    public class DealerProduct
    {
        [Key]
        public long ID { get; set; }
        public long BrandID { get; set; }
        public string? BrandName { get; set; }
        public long ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public decimal? UnitValue { get; set; }
        public string? Description { get; set; }
        public bool Display { get; set; }
    }
}
