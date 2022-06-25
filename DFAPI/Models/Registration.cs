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
        public int OTP { get; set; }
        public bool IsVerified { get; set; }
        [Key]
        public long PhoneNumber { get; set; }
        public string? AddressLine { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int Pincode { get; set; }
        public string? GSTNumber { get; set; }
        public string? PAN { get; set; }
        public byte Status { get; set; }

    }
}