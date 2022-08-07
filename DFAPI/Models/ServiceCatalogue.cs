using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class WorkFloorMaster
    {
        [Key]
        public long ID { get; set; }
        public string? WorkFloorName { get; set; }
        public bool? Display { get; set; }
    }

    public class WorkLocationMaster
    {
        [Key]
        public long ID { get; set; }
        public string? WorkLocationName { get; set; }
        public bool? Display { get; set; }
    }

    public class DesignTypeMaster
    {
        [Key]
        public long ID { get; set; }
        public string? DesignTypeName { get; set; }
        public long? ServiceID { get; set; }
        public long? CategoryID { get; set; }
        public long? ProductID { get; set; }
        public bool? Display { get; set; }
    }

    public class DesignTypeByProductID
    {
        [Key]
        public long ID { get; set; }
        public string? DesignTypeName { get; set; }
        public bool? Display { get; set; }
    }

    public class DesignType
    {
        [Key]
        public long ID { get; set; }
        public string? DesignTypeName { get; set; }
        public long? ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public long? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public long? ProductID { get; set; }
        public string? ProductName { get; set; }
        public bool? Display { get; set; }
    }

    public class PostNewDesignMaster
    {
        [Key]
        public long ID { get; set; }
        public decimal? LabourCost { get; set; }
        public long? ServiceID { get; set; }
        public long? CategoryID { get; set; }
        public long? ProductID { get; set; }
        public long? DesignTypeID { get; set; }
        public long? WorkLocationID { get; set; }
        public string? DesignNumber { get; set; }
        public string? DesignImage { get; set; }
        public bool? Display { get; set; }
    }

    public class PostNewDesign
    {
        [Key]
        public long ID { get; set; }
        public decimal? LabourCost { get; set; }
        public long? ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public long? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public long? ProductID { get; set; }
        public string? ProductName { get; set; }
        public long? DesignTypeID { get; set; }
        public string? DesignTypeName { get; set; }
        public long? WorkLocationID { get; set; }
        public string? WorkLocationName { get; set; }
        public string? DesignNumber { get; set; }
        public string? DesignImage { get; set; }
        public bool? Display { get; set; }
    }

    [Keyless]
    public class ProductsRequest
    {
        public string? ProductID { get; set; }
    }

    [Keyless]
    public class ProductBarndRequest
    {
        public long ProductID { get; set; }
        public long BrandID { get; set; }
    }

    public class ProductsByProductID
    {
        [Key]
        public long ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
    }

    public class BrandsByProductID
    {
        [Key]
        public long BrandID { get; set; }
        public string? BrandName { get; set; }
    }
}
