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

        public List<MarketAnnouncmentLangVM> MarketAnnouncmentLangsVM { get; set; }
    }
}
