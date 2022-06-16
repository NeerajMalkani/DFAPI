using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{

    public class ActivityMaster
    {
        [Key]
        public long RoleID { get; set; }
        public string? ActivityRoleName { get; set; }
        public bool Display { get; set; }
    }

    public class ServiceMaster
    {
        [Key]
        public long ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public bool Display { get; set; }
    }

    public class UnitOfSalesMaster
    {
        [Key]
        public long UnitOfSalesID { get; set; }
        public string? UnitName { get; set; }
        public bool Display { get; set; }
    }
}
