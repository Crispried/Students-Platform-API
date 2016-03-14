using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.Domain.Concrete
{
    public class EFTravelAnnouncmentRepository : ITravelAnnouncmentRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<TravelAnnouncment> TravelAnnouncments
        {
            get
            {
                return context.TravelAnnouncments;
            }
        }

        public void DeleteTravelAnnouncment(int travelAnnouncmentId)
        {
            TravelAnnouncment dbEntry = context.TravelAnnouncments.Find(travelAnnouncmentId);
            if (dbEntry != null)
            {
                context.TravelAnnouncments.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public void SaveTravelAnnouncment(TravelAnnouncment travelAnnouncment)
        {
            if (travelAnnouncment.TravelAnnouncmentId == 0)
            {
                context.TravelAnnouncments.Add(travelAnnouncment);
            }
            else
            {
                TravelAnnouncment dbEntry = context.TravelAnnouncments.Find(travelAnnouncment.TravelAnnouncmentId);
                if (dbEntry != null)
                {
                    dbEntry.Title = travelAnnouncment.Title;
                    dbEntry.Bulletin = travelAnnouncment.Bulletin;
                    dbEntry.AuthorId = travelAnnouncment.AuthorId;  
                }
            }
            context.SaveChanges();
        }
    }
}
