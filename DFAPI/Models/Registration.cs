using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class Users
    {
        [Required]
        [Key]
        public long UserID { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public byte RoleID { get; set; }
        public int? OTP { get; set; }
        public bool IsVerified { get; set; }
        public string? AddressLine { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }
        public int? Pincode { get; set; }
        public string? GSTNumber { get; set; }
        public string? PAN { get; set; }
        public byte Status { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserProfile
    {
        [Required]
        [Key]
        public long UserID { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyLogo { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonNumber { get; set; }
        public string? AddressLine { get; set; }
        public string? LocationName { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }
        public int? Pincode { get; set; }
        public string? GSTNumber { get; set; }
        public string? PAN { get; set; }
        public long? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? IFSCCode { get; set; }
        public string? CompanyNamePrefix { get; set; }
        public string? QuotationBudgetPrefix { get; set; }
        public string? EmployeeCodePrefix { get; set; }
        public string? PurchaseOrderPrefix { get; set; }
        public string? SalesOrderPrefix { get; set; }
        public bool? ShowBrand { get; set; }
    }

    public class UserStatusRequest
    {
        [Required]
        [Key]
        public long UserID { get; set; }
        public byte? Status { get; set; }
    }

    public class UpadteGeneralUser
    {
        [Required]
        [Key]
        public long UserID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonNumber { get; set; }
        public string? AddressLine { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }
        public int? Pincode { get; set; }
        public string? GSTNumber { get; set; }
        public string? PAN { get; set; }

    }

    public class GeneralUserProfileResponse
    {
        [Key]
        public long UserID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonNumber { get; set; }
        public string? AddressLine { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }
        public int? Pincode { get; set; }
        public string? GSTNumber { get; set; }
        public string? PAN { get; set; }

    }
    public class LoginUser
    {
        [Key]
        public long UserID { get; set; }
        public byte RoleID { get; set; }
        public string? RoleName { get; set; }
        public string? FullName { get; set; }
    }

    [Keyless]
    public class UserCount
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public int? RoleCount { get; set; }
    }
}