using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class ContractorServiceMapping
    {
        [Key]
        public long ID { get; set; }
        public long ContractorID { get; set; }
        public long ServiceID { get; set; }
        public bool Display { get; set; }
    }

    public class ContractorServiceList
    {
        [Key]
        public long ID { get; set; }
        public long? ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public bool Display { get; set; }
    }
}
