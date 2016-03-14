using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;
using Students.Domain.Abstract;

namespace Students.Domain.Concrete
{
    public class EFHousingAnnouncmentRepository : IHousingAnnouncmentRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<HousingAnnouncment> HousingAnnouncments
        {
            get
            {
                return context.HousingAnnouncments;
            }
        }

        public void DeleteHousingAnnouncment(int housingAnnouncmentId)
        {
            HousingAnnouncment dbEntry = context.HousingAnnouncments.Find(housingAnnouncmentId);
            if (dbEntry != null)
            {
                context.HousingAnnouncments.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public void SaveTravelAnnouncment(HousingAnnouncment housingAnnouncment)
        {
            if (housingAnnouncment.HousingAnnouncmentId == 0)
            {
                context.HousingAnnouncments.Add(housingAnnouncment);
            }
            else
            {
                HousingAnnouncment dbEntry = context.HousingAnnouncments.Find(housingAnnouncment.HousingAnnouncmentId);
                if (dbEntry != null)
                {
                    dbEntry.Title = housingAnnouncment.Title;
                    dbEntry.Bulletin = housingAnnouncment.Bulletin;
                    dbEntry.AuthorId = housingAnnouncment.AuthorId;
                }
            }
            context.SaveChanges();
        }
    }
}
