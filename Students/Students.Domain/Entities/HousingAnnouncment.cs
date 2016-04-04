using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{ 
    public class HousingAnnouncment
    {
        [Key]
        public int HousingAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // announcment owners

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<HousingAnnouncmentLang> HousingAnnouncmentLangs { get; set; }

        public virtual ICollection<HousingComment> HousingComments { get; set; }

        public virtual ICollection<HousingAnnouncmentImage> HousingAnnouncmentImages { get; set; }

        public HousingAnnouncment() : base()
        {
            this.AddedDate = DateTime.Now; // default value for added time is the time when announcment was added
            this.HousingComments = new List<HousingComment>();
            this.HousingAnnouncmentLangs = new List<HousingAnnouncmentLang>();
            this.HousingAnnouncmentImages = new List<HousingAnnouncmentImage>();
        }
    }
}
