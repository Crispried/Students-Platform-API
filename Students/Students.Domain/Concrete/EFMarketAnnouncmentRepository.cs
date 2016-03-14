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
        private EFDbContext context = new EFDbContext();
        public IQueryable<MarketAnnouncment> MarketAnnouncments
        {
            get
            {
                return context.MarketAnnouncments;
            }
        }

        public void DeleteMarketAnnouncment(int marketAnnouncmentId)
        {
            MarketAnnouncment dbEntry = context.MarketAnnouncments.Find(marketAnnouncmentId);
            if (dbEntry != null)
            {
                context.MarketAnnouncments.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public void SaveMarketAnnouncment(MarketAnnouncment marketAnnouncment)
        {
            if (marketAnnouncment.MarketAnnouncmentId == 0)
            {
                context.MarketAnnouncments.Add(marketAnnouncment);
            }
            else
            {
                MarketAnnouncment dbEntry = context.MarketAnnouncments.Find(marketAnnouncment.MarketAnnouncmentId);
                if (dbEntry != null)
                {
                    dbEntry.Title = marketAnnouncment.Title;
                    dbEntry.Bulletin = marketAnnouncment.Bulletin;
                    dbEntry.AuthorId = marketAnnouncment.AuthorId;
                }
            }
            context.SaveChanges();
        }
    }
}
