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

        public int AuthorId { get; set; }

        public DateTime AddedDate { get; set; }

        public ICollection<MarketAnnouncmentLangVM> MarketAnnouncmentLangsVM { get; set; }
        
        public MarketAnnouncmentVM()
        {
            this.MarketAnnouncmentLangsVM = new List<MarketAnnouncmentLangVM>();
        }
    }
}
