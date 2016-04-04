using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class MarketCommentImage : Image
    {
        [Key]
        public int MarketCommentImageId { get; set; }

        [Required]
        [ForeignKey("MarketComment")]
        public int MarketCommentId { get; set; }

        public virtual MarketComment MarketComment { get; set; }

        public MarketCommentImage() : base() { }
    }
}
