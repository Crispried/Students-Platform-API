using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class HousingCommentImage : Image
    {
        [Key]
        public int HousingCommentImageId { get; set; }

        [Required]
        [ForeignKey("HousingComment")]
        public int HousingCommentId { get; set; }

        public virtual HousingComment HousingComment { get; set; }

        public HousingCommentImage() : base() { }
    }
}
