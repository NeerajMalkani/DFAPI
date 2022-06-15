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
}
