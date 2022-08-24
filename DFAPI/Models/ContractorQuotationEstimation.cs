using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class ClientMaster
    {
        [Key]
        public long ID { get; set; }
        public long? UserID { get; set; }
        public long? CompanyID { get; set; }
        public int? ServiceType { get; set; }
        public bool? Display { get; set; }
    }

    public class Client
    {
        [Key]
        public long ID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactMobileNumber { get; set; }
        public string? Address1 { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }
        public int? Pincode { get; set; }
        public string? GSTNumber { get; set; }
        public string? PAN { get; set; }
        public int? ServiceType { get; set; }
        public bool? Display { get; set; }
    }

    public class ClientGet
    {
        [Key]
        public long ID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactMobileNumber { get; set; }
        public string? Address1 { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public int? Pincode { get; set; }
        public string? GSTNumber { get; set; }
        public string? PAN { get; set; }
        public byte? ServiceType { get; set; }
        public bool? Display { get; set; }
    }
}
