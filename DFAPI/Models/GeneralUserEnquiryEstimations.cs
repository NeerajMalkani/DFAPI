using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DFAPI.Entities
{
    public class ImageGallery
    {
        [Key]
        public long ID { get; set; }
        public long ServiceID { get; set; }
        public long CategoryID { get; set; }
        public long ProductID { get; set; }
        public long DesignTypeID { get; set; }
        public long WorkLocationID { get; set; }
        public string? ServiceName { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? DesignTypeName { get; set; }
        public string? WorkLocationName { get; set; }
        public string? DesignNumber { get; set; }
        public string? DesignImage { get; set; }
    }

    [Keyless]
    public class ImageGalleryRequest
    {
        public long CategoryID { get; set; }
    }
}
