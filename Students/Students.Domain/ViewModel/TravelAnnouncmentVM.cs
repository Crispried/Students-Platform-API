using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.ViewModel
{
    public class TravelAnnouncmentVM
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public DateTime AddedDate { get; set; }

        public ICollection<TravelAnnouncmentLangVM> TravelAnnouncmentLangsVM { get; set; }

        public TravelAnnouncmentVM()
        {
            this.TravelAnnouncmentLangsVM = new List<TravelAnnouncmentLangVM>();
        }
    }
}
