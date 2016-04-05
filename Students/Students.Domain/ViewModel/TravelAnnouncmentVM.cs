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

        public UserAnnouncmentVM Author { get; set; }

        public DateTime AddedDate { get; set; }

        public ICollection<ImageVM> TravelAnnouncmentImagesVM { get; set; }

        public ICollection<TravelAnnouncmentLangVM> TravelAnnouncmentLangsVM { get; set; }

        public TravelAnnouncmentVM()
        {
            this.TravelAnnouncmentLangsVM = new List<TravelAnnouncmentLangVM>();
            this.TravelAnnouncmentImagesVM = new List<ImageVM>();
        }
    }
}
