using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class HousingAnnouncmentImage : Image
    {
        [Key]
        public int HousingAnnouncmentImageId { get; set; }

        [Required]
        [ForeignKey("HousingAnnouncment")]
        public int HousingAnnouncmentId { get; set; }

        public virtual HousingAnnouncment HousingAnnouncment { get; set; }

        public HousingAnnouncmentImage() : base() { }
    }
}
