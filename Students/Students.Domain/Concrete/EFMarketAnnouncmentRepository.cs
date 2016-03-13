using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.Domain.Concrete
{
    public class EFMarketAnnouncmentRepository : IMarketAnnouncmentRepository
    {
        public IQueryable<MarketAnnouncment> MarketAnnouncments
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteMarketAnnouncment(int marketAnnouncmentId)
        {
            throw new NotImplementedException();
        }

        public void SaveMarketAnnouncment(MarketAnnouncment marketAnnouncment)
        {
            throw new NotImplementedException();
        }
    }
}
