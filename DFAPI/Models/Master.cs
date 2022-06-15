using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class ActivityRoles
    {
        [Key]
        public long RoleID { get; set; }
        public string? ActivityRoleName { get; set; }
        public bool Display { get; set; }
    }

    public class Services
    {
        [Key]
        public long ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public bool Display { get; set; }
    }

    public class UnitOfSales
    {
        [Key]
        public long UnitOfSalesID { get; set; }
        public string? UnitName { get; set; }
        public bool Display { get; set; }
    }
}
