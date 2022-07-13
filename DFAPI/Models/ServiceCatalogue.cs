using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class WorkFloorMaster
    {
        [Key]
        public long ID { get; set; }
        public string? WorkFloorName { get; set; }
        public bool? Display { get; set; }
    }

    public class WorkLocationMaster
    {
        [Key]
        public long ID { get; set; }
        public string? WorkLocationName { get; set; }
        public bool? Display { get; set; }
    }
}
