using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class MarketAnnouncmentImage : Image
    {
        [Key]
        public int MarketAnnouncmentImageId { get; set; }

        [Required]
        [ForeignKey("MarketAnnouncment")]
        public int MarketAnnouncmentId { get; set; }

        public virtual MarketAnnouncment MarketAnnouncment { get; set; }

        public MarketAnnouncmentImage() : base() { }
    }
}
