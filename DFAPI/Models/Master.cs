using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class ActivityMaster
    {
        [Key]
        public long ID { get; set; }
        public string? ActivityRoleName { get; set; }
        public bool? Display { get; set; }
    }

    public class ServiceMaster
    {
        [Key]
        public long ID { get; set; }
        public string? ServiceName { get; set; }
        public bool? Display { get; set; }
    }

    public class UnitOfSalesMaster
    {
        [Key]
        public int ID { get; set; }
        public Int32 Unit1ID { get; set; }
        public string? Unit1Name { get; set; }
        public Int32 Unit2ID { get; set; }
        public string? Unit2Name { get; set; }
        public bool Display { get; set; }
        public string? DisplayUnit { get; set; }
    }

    public class CategoryMasterResponse
    {
        [Key]
        public long ID { get; set; }
        public long RoleID { get; set; }
        public string? ActivityRoleName { get; set; }
        public long? ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public string? CategoryName { get; set; }
        public string? HSNSACCode { get; set; }
        public decimal? GSTRate { get; set; }
        public bool? Display { get; set; }
        public string? UnitID { get; set; }
        public string? UnitName { get; set; }
    }


    public class CategoryMaster
    {
        [Key]
        public long ID { get; set; }
        public string? CategoryName { get; set; }
        public bool? Display { get; set; }
    }


    public class CategoryByService
    {
        [Key]
        public long ID { get; set; }
        public string? CategoryName { get; set; }
        public string? HSNSACCode { get; set; }
        public decimal? GSTRate { get; set; }
        public bool? Display { get; set; }
    }

    public class ProductMaster
    {
        [Key]
        public long ProductID { get; set; }
        public long? ActivityID { get; set; }
        public long? ServiceID { get; set; }
        public long? UnitOfSalesID { get; set; }
        public long? SelectedUnitID { get; set; }
        public long? CategoryID { get; set; }
        public string? ProductName { get; set; }
        public bool? Display { get; set; }
        public bool? ServiceDisplay { get; set; }
        public decimal? RateWithMaterials { get; set; }
        public decimal? RateWithoutMaterials { get; set; }
        public decimal? AlternateUnitOfSales { get; set; }
        public string? ShortSpecification { get; set; }
        public string? Specification { get; set; }
        public DateTime? CreationTStamp { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Products
    {
        [Key]
        public long ProductID { get; set; }
        public long? SelectedUnitID { get; set; }
        public string? ProductName { get; set; }
        public long? ActivityID { get; set; }
        public string? ActivityRoleName { get; set; }
        public long? ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public long? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? HSNSACCode { get; set; }
        public decimal? GSTRate { get; set; }
        public long? UnitOfSalesID { get; set; }
        public string? UnitName { get; set; }
        public string? Unit1Name { get; set; }
        public string? Unit2Name { get; set; }
        public Int32? Unit1ID { get; set; }
        public Int32? Unit2ID { get; set; }
        public decimal? ConversionRate { get; set; }
        public bool? Display { get; set; }
        public decimal? RateWithMaterials { get; set; }
        public decimal? RateWithoutMaterials { get; set; }
        public decimal? AlternateUnitOfSales { get; set; }
        public bool? ServiceDisplay { get; set; }
        public string? ShortSpecification { get; set; }
        public string? Specification { get; set; }
    }

    public class ProductsByCategory
    {
        [Key]
        public long ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal? RateWithoutMaterials { get; set; }
        public bool? Display { get; set; }
    }

    public class DepartmentMaster
    {
        [Key]
        public long ID { get; set; }
        public string? DepartmentName { get; set; }
        public bool? Display { get; set; }
    }

    public class UserDepartmentMapping
    {
        [Key]
        public long ID { get; set; }
        public byte? UserType { get; set; }
        public long? UserId { get; set; }
        public int? DepartmentID { get; set; }
        public bool? Display { get; set; }
    }

    public class UserDepartmentMappingList
    {
        [Key]
        public long ID { get; set; }
        public int? DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public bool? Display { get; set; }
    }


    public class DesignationMaster
    {
        [Key]
        public long ID { get; set; }
        public string? DesignationName { get; set; }
        public bool? Display { get; set; }
    }

    public class UserDesignationMapping
    {
        [Key]
        public long ID { get; set; }
        public byte? UserType { get; set; }
        public long? UserId { get; set; }
        public int? DesignationID { get; set; }
        public bool? ReportingAuthority { get; set; }
        public bool? Display { get; set; }
    }



    public class UserDesignationMappingList
    {
        [Key]
        public long ID { get; set; }
        public int? DesignationID { get; set; }
        public string? DesignationName { get; set; }
        public bool? ReportingAuthority { get; set; }
        public bool? Display { get; set; }
    }


    public class LocationTypeMaster
    {
        [Key]
        public long ID { get; set; }
        public string? BranchType { get; set; }
        public bool? Display { get; set; }
    }

    public class LocationTypeMasterMapped
    {
        [Key]
        public long ID { get; set; }
        public string? BranchType { get; set; }
        public bool? Display { get; set; }
        public string? ActivityName { get; set; }
        public string? ServiceName { get; set; }
    }

    public class LocationType
    {
        [Key]
        public long ID { get; set; }
        public string? BranchType { get; set; }
        public string? ActivityID { get; set; }
        public string? ServiceID { get; set; }
        public bool? Display { get; set; }
    }

    public class EWayBillMaster
    {
        [Key]
        public long ID { get; set; }
        public int? StateID { get; set; }
        public decimal? InStateLimit { get; set; }
        public decimal? InterStateLimit { get; set; }
        public bool? Display { get; set; }
    }

    public class EWayBills
    {
        [Key]
        public long ID { get; set; }
        public string? StateName { get; set; }
        public decimal? InStateLimit { get; set; }
        public decimal? InterStateLimit { get; set; }
        public bool? Display { get; set; }
    }

    public class StateMaster
    {
        [Key]
        public int ID { get; set; }
        public string? StateName { get; set; }
        public bool? IsUT { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CityMaster
    {
        [Key]
        public int ID { get; set; }
        public string? CityName { get; set; }
        public int? StateID { get; set; }
        public bool? IsActive { get; set; }

    }

    [Keyless]
    public class RowsAffectedResponse
    {
        public long rowsAffected { get; set; }
    }

    public class UserMappingRequest
    {
        public byte? UserType { get; set; }
        public long? UserId { get; set; }
    }

    public class UserEmployeeListResponse
    {
        [Key]
        public long ID { get; set; }
        public string? EmployeeName { get; set; }
        public string? MobileNo { get; set; }
        public string? DepartmentName { get; set; }
        public string? DesignationName { get; set; }
        public bool? profileStatus { get; set; }
        public bool? loginStatus { get; set; }
        public bool? verifyStatus { get; set; }
    }

    public class UserEmployeeRequest
    {
        public byte? UserType { get; set; }
        public long? UserId { get; set; }
        public string? EmployeeName { get; set; }
        public string? MobileNo { get; set; }
        public string? AadharNo { get; set; }
    }

    public class UserEmployeeList
    {
        [Key]
        public long ID { get; set; }
        public string? EmployeeName { get; set; }
        public string? MobileNo { get; set; }
        public string? AadharNo { get; set; }
    }

    public class EmployeeMaster
    {
        [Key]
        public long ID { get; set; }
        public byte? UserType { get; set; }
        public long? UserID { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeCode { get; set; }
        public string? MobileNo { get; set; }
        public string? AadharNo { get; set; }
        public string? FatherName { get; set; }
        public string? Address { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }
        public int? Pincode { get; set; }
        public string? ProfilePhoto { get; set; }
        public byte? BloodGroup { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOJ { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactNo { get; set; }
        public DateTime? IDCardValidity { get; set; }
        public bool? LoginActiveStatus { get; set; }
        public long? BranchID { get; set; }
        public long? DepartmentID { get; set; }
        public long? DesignationID { get; set; }
        public byte? EmployeeType { get; set; }
        public DateTime? LastWorkDate { get; set; }
        public bool? WagesType { get; set; }
        public decimal? Salary { get; set; }
        public bool? IsActive { get; set; }
        public bool? profileStatus { get; set; }
        public bool? loginStatus { get; set; }
        public bool? verifyStatus { get; set; }
    }

    public class BranchMaster
    {
        [Key]
        public string? ID { get; set; }
        public byte? UserType { get; set; }
        public long? UserID { get; set; }
        public int? CompanyID { get; set; }
        public int? BranchTypeID { get; set; }
        public int? BranchAdminID { get; set; }
        public string? ContactPersonNo { get; set; }
        public string? GSTNo { get; set; }
        public string? PANNo { get; set; }
        public bool? Display { get; set; }
        public string? LocationName { get; set; }
        public string? Address { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }
        public int? Pincode { get; set; }
        public string? AccountNo { get; set; }
        public string? BankName { get; set; }
        public string? BankBranchName { get; set; }
        public string? IFSCCode { get; set; }
    }

    public class UserBranchList
    {
        [Key]
        public long ID { get; set; }
        public int? BranchTypeID { get; set; }
        public string? BranchType { get; set; }
        public string? LocationName { get; set; }
        public string? BranchAdmin { get; set; }
        public string? Address { get; set; }
        public string? GSTNo { get; set; }
        public string? PANNo { get; set; }
        public bool? Display { get; set; }
    }

    public class Companies
    {
        [Key]
        public long CompanyID { get; set; }
        public long? UserID { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyNamePrefix { get; set; }
        public string? EmpoyeeCodePrefix { get; set; }
        public string? QuotationNumberPrefix { get; set; }
        public string? CompanyLogo { get; set; }
        public string? IsActive { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonNumber { get; set; }
    }

    public class CompanyList
    {
        [Key]
        public long CompanyID { get; set; }
        public string? CompanyName { get; set; }
    }
}
