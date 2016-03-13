using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class TravelComment : Comment
    {
        [Key]
        public int TravelCommentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // comment owner

        [Required]
        [ForeignKey("TravelAnnouncment")]
        public int TravelAnnouncmentId { get; set; } // announcment which contains comment

        public virtual User User { get; set; }

        public virtual TravelAnnouncment TravelAnnouncment { get; set; }

        public TravelComment() { }
    }
}
