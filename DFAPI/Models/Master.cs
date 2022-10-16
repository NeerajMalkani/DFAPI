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

    public class UnitOfProduct
    {
        [Key]
        public int ID { get; set; }
        public Int32? UnitID { get; set; }
        public string? UnitName { get; set; }
        public decimal ConversionRate { get; set; }
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

    public class ProductResponse
    {
        [Key]
        public long ProductID { get; set; }
        public long? SelectedUnitID { get; set; }
        public string? ProductName { get; set; }
        public string? SelectedUnitName { get; set; }
        public long? ActivityID { get; set; }
        public string? ActivityRoleName { get; set; }
        public long? ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public long? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? HSNSACCode { get; set; }
        public decimal? GSTRate { get; set; }
        public long? UnitOfSalesID { get; set; }
        public bool? Display { get; set; }
        public decimal? RateWithMaterials { get; set; }
        public decimal? RateWithoutMaterials { get; set; }
        public decimal? AlternateUnitOfSales { get; set; }
        public bool? ServiceDisplay { get; set; }
        public decimal? ConversionRate { get; set; }
        public string? ShortSpecification { get; set; }
        public string? Specification { get; set; }
    }

    public class ProductsByCategory
    {
        [Key]
        public long ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ServiceName { get; set; }
        public string? CategoryName { get; set; }
        public decimal? RateWithMaterials { get; set; }
        public decimal? RateWithoutMaterials { get; set; }
        public long? SelectedUnitID { get; set; }
        public bool? Display { get; set; }
        public string? ShortSpecification { get; set; }
        public string? Specification { get; set; }
    }

    public class RateCardProductsByCategory
    {
        [Key]
        public long ProductID { get; set; }
        public long ServiceID { get; set; }
        public long CategoryID { get; set; }
        public string? ProductName { get; set; }
        public string? ServiceName { get; set; }
        public string? CategoryName { get; set; }
        public decimal? FootRate { get; set; }
        public decimal? MeterRate { get; set; }
        public long? SelectedUnitID { get; set; }
        public long? UnitOfSalesID { get; set; }
        public bool? Display { get; set; }
        public string? ShortSpecification { get; set; }
        public string? Specification { get; set; }
        public Int32 Unit1ID { get; set; }
        public string? Unit1Name { get; set; }
        public Int32 Unit2ID { get; set; }
        public string? Unit2Name { get; set; }
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
        public long? AddedByUserID { get; set; }
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
        public long? AddedByUserID { get; set; }
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

    public class BranchTypes
    {
        [Key]
        public long ID { get; set; }
        public string? BranchType { get; set; }
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

    public class EmpoyeeMappingRequest
    {
        public long? AddedByUserID { get; set; }
    }

    public class UserEmployeeVerifyRequest
    {
        public long? AddedByUserID { get; set; }
        public long? EmployeeID { get; set; }
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
        public int? OTP { get; set; }

    }

    public class UserBranchForEmployeeResponse
    {
        public long? ID { get; set; }
        public string? LocationName { get; set; }
    }

    public class EmployeeResponse
    {
        public List<EmployeeMaster>? Employee { get; set; }
        public List<EmployeeReportingAuthority>? EmployeeReportingAuthority { get; set; }
        public List<BankDetails>? BankDetails { get; set; }
    }

    public class UserEmployeeRequest
    {
        public long? AddedByUserID { get; set; }
        public string? EmployeeName { get; set; }
        public string? MobileNo { get; set; }
        public string? AadharNo { get; set; }
    }

    public class EmployeeVerificationRequest
    {
        public int? OTP { get; set; }
        public long? EmployeeID { get; set; }
    }

    public class UserEmployeeList
    {
        [Key]
        public long ID { get; set; }
        public string? EmployeeName { get; set; }
        public string? MobileNo { get; set; }
        public string? AadharNo { get; set; }
    }

    public class UserEmployeeSearchResponse
    {
        public long ID { get; set; }
        public string? EmployeeName { get; set; }
        public string? MobileNo { get; set; }
        public string? AadharNo { get; set; }
        public string? CompanyName { get; set; }
        public long? CompanyID { get; set; }
    }

    public class UsersList
    {
        [Key]
        public long UserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ActivityRoleName { get; set; }
        public string? Company { get; set; }
        public string? Department { get; set; }
        public string? Designation { get; set; }
    }

    public class UserReportingEmployeeResponse
    {
        public long ID { get; set; }
        public string? Employee { get; set; }
    }

    public class EmployeeMaster
    {
        [Key]
        public long ID { get; set; }
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
        public byte? WagesType { get; set; }
        public decimal? Salary { get; set; }
        public bool? IsActive { get; set; }
        public bool? profileStatus { get; set; }
        public bool? loginStatus { get; set; }
        public bool? verifyStatus { get; set; }
        public long? AddedByUserID { get; set; }
    }

    public class UserEmployeeSearchRequest
    {
        public long? AddedByUserID { get; set; }
        public string? MobileNo { get; set; }
        public string? AadharNo { get; set; }
    }
    public class BranchMaster
    {
        [Key]
        public long? ID { get; set; }
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
        public long? AddedByUserID { get; set; }
        public long? RegionalOfficeID { get; set; }
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
        public long? RegionalOfficeID { get; set; }
        public int? BranchAdminID { get; set; }
        public string? ContactPersonNo { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }
        public int? Pincode { get; set; }
        public string? AccountNo { get; set; }
        public string? BankName { get; set; }
        public string? BankBranchName { get; set; }
        public string? IFSCCode { get; set; }


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
        public bool? IsActive { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonNumber { get; set; }
    }

    public class CompanyList
    {
        [Key]
        public long CompanyID { get; set; }
        public string? CompanyName { get; set; }
    }

    public class UserDepartmentForBranchEmployeeResponse
    {
        public int? DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
    }

    public class UserDesignationForBranchEmployeeResponse
    {
        public int? DesignationID { get; set; }
        public string? DesignationName { get; set; }
    }

    public class EmployeeReportingAuthority
    {
        [Key]
        public long ID { get; set; }
        public long? EmployeeID { get; set; }
        public long? AddedByUserID { get; set; }
        public int? ReportingAuthorityID { get; set; }
    }

    public class BankDetails
    {
        [Key]
        public long BankID { get; set; }
        public long? CompanyID { get; set; }
        public long? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? IFSCCode { get; set; }
        public string? AccountHolderName { get; set; }
        public long? UserID { get; set; }
    }

    public class EmployeeIDRequest
    {
        [Key]
        public long ID { get; set; }
        public long? AddedByUserID { get; set; }
    }

    public class EmployeeReportingAuthorityRequest
    {
        public long? EmployeeID { get; set; }
        public long? AddedByUserID { get; set; }
    }

    [Keyless]
    public class EmployeeReportingAuthorityResponse
    {
        public int ReportingAuthorityID { get; set; }
    }

    [Keyless]
    public class UpdateEmployeeRequest
    {
        public long ID { get; set; }
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
        public byte? WagesType { get; set; }
        public decimal? Salary { get; set; }
        public string? AccountHolderName { get; set; }
        public long? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? IFSCCode { get; set; }

    }

    public class EmployeeReportingAuthorityUpdateRequest
    {
        public long? EmployeeID { get; set; }
        public long? AddedByUserID { get; set; }
        public string? ReportingAuthorityID { get; set; }
    }

    public class NewEmployeeRequest
    {
        public long? EmployeeID { get; set; }
        public long? AddedByUserID { get; set; }
    }

    public class ContractorActiveServiceList
    {
        [Key]
        public long ID { get; set; }
        public long? ServiceID { get; set; }
        public string? ServiceName { get; set; }
        
    }

    public class ContractorRateCard
    {
        [Key]
        public long RateCardID { get; set; }
        public long ProductID { get; set; }
        public long? ActivityID { get; set; }
        public long? ServiceID { get; set; }
        public long? CategoryID { get; set; }
        public long? SelectedUnitID { get; set; }
        public long? UnitOfSalesID { get; set; }
        public decimal? RateWithMaterials { get; set; }
        public decimal? RateWithoutMaterials { get; set; }
        public decimal? AltRateWithMaterials { get; set; }
        public decimal? AltRateWithoutMaterials { get; set; }
        public decimal? AlternateUnitOfSales { get; set; }
        public string? ShortSpecification { get; set; }
        public string? Specification { get; set; }
        public bool? Display { get; set; }
        public DateTime? CreationTStamp { get; set; }
        public bool? IsActive { get; set; }
        public long? ContractorID { get; set; }

    }

    public class ContractorRateCardList
    {
        [Key]
        public long ID { get; set; }
        public long ProductID { get; set; }
        public long? ActivityID { get; set; }
        public long? ServiceID { get; set; }
        public long? CategoryID { get; set; }
        public long? SelectedUnitID { get; set; }
        public long? UnitOfSalesID { get; set; }
        public decimal? RateWithMaterials { get; set; }
        public decimal? RateWithoutMaterials { get; set; }
        public decimal? AltRateWithMaterials { get; set; }
        public decimal? AltRateWithoutMaterials { get; set; }
        public decimal? AlternateUnitOfSales { get; set; }
        public string? ShortSpecification { get; set; }
        public string? Specification { get; set; }
        public bool? Display { get; set; }
        public DateTime? CreationTStamp { get; set; }
        public bool? IsActive { get; set; }
        public long? ContractorID { get; set; }
        public string? ServiceName { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? SelectedUnitName { get; set; }
        public string? Unit1Name { get; set; }
        public string? Unit2Name { get; set; }
        public int? Unit1ID { get; set; }
        public int? Unit2ID { get; set; }
        public decimal? ConversionRate { get; set; }


    }

    public class BranchCompanyDetails
    {
        [Key]
        public long CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public string? PAN { get; set; }
    }

    public class ActivityRequest
    {
        public long? ActivityID { get; set; }
    }

    public class BranchRegionalOfficeList
    {
        [Key]
        public long? ID { get; set; }
        public string? LocationName { get; set; }
        
    }

    public class ClientList
    {
        [Key]
        public long ID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactMobileNumber { get; set; }
        public string? ContactPerson { get; set; }

    }

    public class ContractorRateCardProductRequest
    {
        [Key]
        public long? ActivityID { get; set; }
        public long? ServiceID { get; set; }
        public long? CategoryID { get; set; }
        public long? ContractorID { get; set; }
        public bool? InclusiveMaterial { get; set; }
    }


    public class ContractorRateCardMapping
    {
        [Key]
        public long ID { get; set; }
        public long? ClientID { get; set; }
        public long? SelectedUnitID { get; set; }
        public long? UnitOfSalesID { get; set; }
        public bool? InclusiveMaterials { get; set; }
        public bool? SendStatus { get; set; }
        public bool? IsActive { get; set; }
        public long? AddedByUserID { get; set; }
        public DateTime? CreationTStamp { get; set; }
    }

    public class ContractorRateCardMappingItems
    {
        [Key]
        public long ID { get; set; }
        public long? RateCardMappingID { get; set; }
        public long? ProductID { get; set; }
        public long? ServiceID { get; set; }
        public long? CategoryID { get; set; }
        public long? SelectedUnitID { get; set; }
        public long? UnitOfSalesID { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? CreationTStamp { get; set; }
    }

    public class ContractorRateCardMappingRequest
    {
        public List<ContractorRateCardMapping>? contractorRateCardMapping { get; set; }
        public List<ContractorRateCardMappingItems>? contractorRateCardMappingItems { get; set; }
    }

    public class ContractorRateCardSentList
    {
        [Key]
        public long ID { get; set; }
        public string? ClientName { get; set; }
        public string? ContactNo { get; set; }
        public string? Unit { get; set; }
        public bool? InclusiveMaterials { get; set; }
        public bool? SendStatus { get; set; }

    }
}
