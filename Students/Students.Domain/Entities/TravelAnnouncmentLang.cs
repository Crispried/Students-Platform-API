using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class TravelAnnouncmentLang : Announcment
    {
        [Key]
        public int TravelAnnouncmentLangId { get; set; }

        [Required]
        [ForeignKey("TravelAnnouncment")]
        public int TravelAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public TravelAnnouncment TravelAnnouncment { get; set; }

        public Language Language { get; set; }

        public TravelAnnouncmentLang() : base()
        {

        }
    }
}
