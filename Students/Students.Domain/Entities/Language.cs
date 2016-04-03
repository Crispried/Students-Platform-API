using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public enum LanguageCode
    {
        eng,
        rus,
        ukr,
        pol
    }
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public LanguageCode Code { get; set; }

        [Required]
        [StringLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<HousingAnnouncmentLang> HousingAnnouncmentLangs { get; set; }

        public virtual ICollection<TravelAnnouncmentLang> TravelAnnouncmentLangs { get; set; }

        public virtual ICollection<MarketAnnouncmentLang> MarketAnnouncmentLangs { get; set; }

        public virtual ICollection<ServiceAnnouncmentLang> ServiceAnnouncmentLangs { get; set; }

        public Language()
        {
            this.HousingAnnouncmentLangs = new List<HousingAnnouncmentLang>();
            this.TravelAnnouncmentLangs = new List<TravelAnnouncmentLang>();
            this.MarketAnnouncmentLangs = new List<MarketAnnouncmentLang>();
            this.ServiceAnnouncmentLangs = new List<ServiceAnnouncmentLang>();
        }
    }
}
