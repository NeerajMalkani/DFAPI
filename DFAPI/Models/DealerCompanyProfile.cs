using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class DealerServiceMapping
    {
        [Key]
        public long ID { get; set; }
        public long DealerID { get; set; }
        public long ServiceID { get; set; }
        public bool Display { get; set; }
    }

    public class DealerServiceList
    {
        [Key]
        public long ID { get; set; }
        public long? ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public bool Display { get; set; }
    }
}
