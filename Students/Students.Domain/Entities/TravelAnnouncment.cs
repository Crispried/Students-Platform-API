using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class TravelAnnouncment
    {
        [Key]
        public int TravelAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // announcment owner

        [DataType(DataType.DateTime)]
        public DateTime AddedTime { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<TravelAnnouncmentLang> TravelAnnouncmentLangs { get; set; }

        public virtual ICollection<TravelComment> TravelComments { get; set; }

        public TravelAnnouncment() : base()
        {
            this.AddedTime = DateTime.Now; // default value for added time is the time when announcment was added
            this.TravelComments = new List<TravelComment>();
            this.TravelAnnouncmentLangs = new List<TravelAnnouncmentLang>();
        }
    }
}
