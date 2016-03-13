using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class MarketAnnouncment : Announcment
    {
        [Key]
        public int MarketAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // announcment owner

        public virtual User User { get; set; }

        public virtual ICollection<MarketComment> MarketComments { get; set; }

        public MarketAnnouncment() : base()
        {
            this.MarketComments = new List<MarketComment>();
        }
    }
}
