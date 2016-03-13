using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class TravelAnnouncment : Announcment
    {
        [Key]
        public int TravelAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // announcment owner

        public virtual User User { get; set; }

        public virtual ICollection<TravelComment> TravelComments { get; set; }

        public TravelAnnouncment() : base()
        {
            this.TravelComments = new List<TravelComment>();
        }
    }
}
