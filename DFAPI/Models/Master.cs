using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{

    public class ActivityMaster
    {
        [Key]
        public long ID { get; set; }
        public string? ActivityRoleName { get; set; }
        public bool Display { get; set; }
    }

    public class ServiceMaster
    {
        [Key]
        public long ID { get; set; }
        public string? ServiceName { get; set; }
        public bool Display { get; set; }
    }

    public class UnitOfSalesMaster
    {
        [Key]
        public long ID { get; set; }
        public string? UnitName { get; set; }
        public bool Display { get; set; }
    }

    public class CategoryMaster
    {
        [Key]
        public long ID { get; set; }
        public long RoleID { get; set; }
        public string? ActivityRoleName { get; set; }
        public long ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public string? CategoryName { get; set; }
        public string? HSNSACCode { get; set; }
        public decimal GSTRate { get; set; }
        public string? UnitOfSalesID { get; set; }
        public bool Display { get; set; }
        public string? UnitID { get; set; }
    }

    [Keyless]
    public class RowsAffectedResponse
    {
        public long rowsAffected { get; set; }
    }
}
