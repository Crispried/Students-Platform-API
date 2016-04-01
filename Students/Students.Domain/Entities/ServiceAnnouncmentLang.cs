using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Domain.Entities
{
    public class ServiceAnnouncmentLang : Announcment
    {
        [Key]
        public int ServiceAnnouncmentLangId { get; set; }

        [Required]
        [ForeignKey("ServiceAnnouncment")]
        public int ServiceAnnouncmentId { get; set; }

        [Required]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public ServiceAnnouncment ServiceAnnouncment { get; set; }

        public Language Language { get; set; }

        public ServiceAnnouncmentLang() : base()
        {

        }
    }
}
