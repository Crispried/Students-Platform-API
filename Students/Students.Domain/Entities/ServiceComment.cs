using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class ServiceComment : Comment
    {
        [Key]
        public int ServiceCommentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; } // comment owner

        [Required]
        [ForeignKey("ServiceAnnouncment")]
        public int ServiceAnnouncmentId { get; set; } // announcment which contains comment

        public virtual User User { get; set; }

        public virtual ServiceAnnouncment ServiceAnnouncment { get; set; }

        public virtual ICollection<ServiceCommentImage> ServiceCommentImages { get; set; }

        public ServiceComment()
        {
            this.ServiceCommentImages = new List<ServiceCommentImage>();
        }
    }
}
