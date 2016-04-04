using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class ServiceCommentImage : Image
    {
        [Key]
        public int ServiceCommentImageId { get; set; }

        [Required]
        [ForeignKey("ServiceComment")]
        public int ServiceCommentId { get; set; }

        public virtual ServiceComment ServiceComment { get; set; }

        public ServiceCommentImage() : base() { }
    }
}
