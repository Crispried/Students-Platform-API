using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class MarketComment : Comment
    {
        [Key]
        public int MarketCommentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // comment owner

        [Required]
        [ForeignKey("MarketAnnouncment")]
        public int MarketAnnouncmentId { get; set; } // announcment which contains comment

        public virtual User User { get; set; }

        public virtual MarketAnnouncment MarketAnnouncment { get; set; }

        public MarketComment() { }
    }
}
