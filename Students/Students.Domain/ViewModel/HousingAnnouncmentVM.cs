using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.ViewModel
{
    public class HousingAnnouncmentVM
    {
        public int Id { get; set; }

        public UserAnnouncmentVM Author { get; set; }

        public DateTime AddedDate { get; set; }

        public ICollection<ImageVM> HousingAnnouncmentImagesVM { get; set; }

        public ICollection<HousingAnnouncmentLangVM> HousingAnnouncmentLangsVM { get; set; }

        public HousingAnnouncmentVM()
        {
            this.HousingAnnouncmentLangsVM = new List<HousingAnnouncmentLangVM>();
            this.HousingAnnouncmentImagesVM = new List<ImageVM>();
        }
    }
}
