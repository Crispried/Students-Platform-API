using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class MarketAnnouncment
    {
        [Key]
        public int MarketAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // announcment owner

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<MarketAnnouncmentLang> MarketAnnouncmentLangs { get; set; }

        public virtual ICollection<MarketComment> MarketComments { get; set; }

        public virtual ICollection<MarketAnnouncmentImage> MarketAnnouncmentImages { get; set; }

        public MarketAnnouncment() : base()
        {
            this.AddedDate = DateTime.Now; // default value for added time is the time when announcment was added
            this.MarketComments = new List<MarketComment>();
            this.MarketAnnouncmentLangs = new List<MarketAnnouncmentLang>();
            this.MarketAnnouncmentImages = new List<MarketAnnouncmentImage>();
        }
    }
}
