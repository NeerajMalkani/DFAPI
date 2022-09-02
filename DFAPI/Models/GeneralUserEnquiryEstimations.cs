using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class ImageGallery
    {
        [Key]
        public long ID { get; set; }
        public long ServiceID { get; set; }
        public long CategoryID { get; set; }
        public long ProductID { get; set; }
        public long DesignTypeID { get; set; }
        public long WorkLocationID { get; set; }
        public string? ServiceName { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? DesignTypeName { get; set; }
        public string? WorkLocationName { get; set; }
        public string? DesignNumber { get; set; }
        public string? DesignImage { get; set; }
    }

    [Keyless]
    public class ImageGalleryRequest
    {
        public long CategoryID { get; set; }
    }

    public class UserEstimationEnquiries
    {
        [Key]
        public long ID { get; set; }
        public long UserID { get; set; }
        public long? ClientID { get; set; }
        public long DesignTypeID { get; set; }
        public long WorkLocationID { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? SubtotalAmount { get; set; }
        public decimal? LabourCost { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? Status { get; set; }
        public byte? ApprovalStatus { get; set; }
    }

    public class UserEstimationEnquiriesGet
    {
        [Key]
        public long ID { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public bool Status { get; set; }
        public decimal LabourCost { get; set; }
        public decimal MaterialCostPerSqFeet { get; set; }
    }

    public class UserAllEstimationGet
    {
        [Key]
        public long ID { get; set; }
        public long DesignTypeID { get; set; }
        public string? DesignTypeName { get; set; }
        public string? DesignTypeImage { get; set; }
        public string? ProductName { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? SubtotalAmount { get; set; }
        public decimal? LabourCost { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool Status { get; set; }
    }

    public class ContractorAllEstimationGet
    {
        [Key]
        public long ID { get; set; }
        public long DesignTypeID { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? ServiceName { get; set; }
        public string? CategoryName { get; set; }
        public string? DesignTypeName { get; set; }
        public string? DesignTypeImage { get; set; }
        public string? ProductName { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? SubtotalAmount { get; set; }
        public decimal? LabourCost { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? Status { get; set; }
        public byte? ApprovalStatus { get; set; }
    }

    [Keyless]
    public class UserEstimationEnquiriesForMaterialSetup
    {
        public long MaterialSetupID { get; set; }
        public long? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? BrandName { get; set; }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Formula { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal GeneralDiscount { get; set; }
    }

    public class UserDesignEstimation
    {
        public long UserDesignEstimationID { get; set; }
    }
}
