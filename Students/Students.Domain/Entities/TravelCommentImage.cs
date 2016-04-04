using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class TravelCommentImage : Image
    {
        [Key]
        public int TravelCommentImageId { get; set; }

        [Required]
        [ForeignKey("TravelComment")]
        public int TravelCommentId { get; set; }

        public virtual TravelComment TravelComment { get; set; }

        public TravelCommentImage() : base() { }
    }
}
