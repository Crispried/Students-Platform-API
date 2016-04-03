using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class MarketAnnouncmentLang : Announcment
    {
        [Key]
        public int MarketAnnouncmentLangId { get; set; }

        [Required]
        [ForeignKey("MarketAnnouncment")]
        public int MarketAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public MarketAnnouncment MarketAnnouncment { get; set; }

        public Language Language { get; set; }

        public MarketAnnouncmentLang() : base()
        {

        }
    }
}
