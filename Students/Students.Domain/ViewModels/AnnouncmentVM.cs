using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;

namespace Students.Domain.ViewModels
{
    public class AnnouncmentVM
    {
        public HousingAnnouncment HousingAnnouncment { get; set; }
        public TravelAnnouncment TravelAnnouncment { get; set; }
        public MarketAnnouncment MarketAnnouncment { get; set; }
        public ServiceAnnouncment ServiceAnnouncment { get; set; }
    }
}
