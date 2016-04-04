using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.ViewModel
{
    public class MarketAnnouncmentVM
    {
        public int Id { get; set; }

        public UserAnnouncmentVM Author { get; set; }

        public DateTime AddedDate { get; set; }

        public ICollection<ImageVM> MarketAnnouncmentImagesVM { get; set; }

        public ICollection<MarketAnnouncmentLangVM> MarketAnnouncmentLangsVM { get; set; }
        
        public MarketAnnouncmentVM()
        {
            this.MarketAnnouncmentLangsVM = new List<MarketAnnouncmentLangVM>();
            this.MarketAnnouncmentImagesVM = new List<ImageVM>();
        }
    }
}
