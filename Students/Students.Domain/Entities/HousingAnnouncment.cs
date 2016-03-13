using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{ 
    public class HousingAnnouncment : Announcment
    {
        [Key]
        public int HousingAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // announcment owner

        public virtual User User { get; set; }

        public virtual ICollection<HousingComment> HousingComments { get; set; }

        public HousingAnnouncment()
        {
            this.HousingComments = new List<HousingComment>();
        }
    }
}
