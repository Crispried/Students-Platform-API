using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class TravelAnnouncmentImage : Image
    {
        [Key]
        public int TravelAnnouncmentImageId { get; set; }

        [Required]
        [ForeignKey("TravelAnnouncment")]
        public int TravelAnnouncmentId { get; set; }

        public virtual TravelAnnouncment TravelAnnouncment { get; set; }

        public TravelAnnouncmentImage() : base() { }
    }
}
