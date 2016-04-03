using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class ServiceAnnouncment
    {
        [Key]
        public int ServiceAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // announcment owner

        [DataType(DataType.DateTime)]
        public DateTime AddedTime { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<ServiceAnnouncmentLang> ServiceAnnouncmentLangs { get; set; }

        public virtual ICollection<ServiceComment> ServiceComments { get; set; }

        public ServiceAnnouncment() : base()
        {
            this.AddedTime = DateTime.Now; // default value for added time is the time when announcment was added
            this.ServiceComments = new List<ServiceComment>();
            this.ServiceAnnouncmentLangs = new List<ServiceAnnouncmentLang>();
        }
    }
}
