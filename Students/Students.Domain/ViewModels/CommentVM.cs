using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;

namespace Students.Domain.ViewModels
{
    public class CommentVM
    {
        public HousingComment HousingComment { get; set; }
        public TravelComment TravelComment { get; set; }
        public MarketComment MarketComment { get; set; }
        public ServiceComment ServiceComment { get; set; }
    }
}
