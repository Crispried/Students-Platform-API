using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class ServiceAnnouncmentImage : Image
    {
        [Key]
        public int ServiceAnnouncmentImageId { get; set; }

        [Required]
        [ForeignKey("ServiceAnnouncment")]
        public int ServiceAnnouncmentId { get; set; }

        public virtual ServiceAnnouncment ServiceAnnouncment { get; set; }

        public ServiceAnnouncmentImage() : base() { }
    }
}
