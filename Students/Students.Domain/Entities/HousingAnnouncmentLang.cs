using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class HousingAnnouncmentLang : Announcment
    {
        [Key]
        public int HousingAnnouncmentLangId { get; set; }

        [Required]
        [ForeignKey("HousingAnnouncment")]
        public int HousingAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        
        public virtual HousingAnnouncment HousingAnnouncment { get; set; }

        public virtual Language Language { get; set; }

        public HousingAnnouncmentLang() : base()
        {

        }
    }
}
