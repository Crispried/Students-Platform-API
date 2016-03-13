using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class HousingComment : Comment
    {
        [Key]
        public int HousingCommentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // comment owner

        [Required]
        [ForeignKey("HousingAnnouncment")]
        public int HousingAnnouncmentId { get; set; } // announcment which contains comment

        public virtual User User { get; set; }

        public virtual HousingAnnouncment HousingAnnouncment { get; set; }

        public HousingComment() { }
    }
}
