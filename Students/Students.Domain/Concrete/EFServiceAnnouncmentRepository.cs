using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.Domain.Concrete
{
    public class EFServiceAnnouncmentRepository : IServiceAnnouncmentRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<ServiceAnnouncment> ServiceAnnouncments
        {
            get
            {
                return context.ServiceAnnouncments;
            }
        }

        public void DeleteServiceAnnouncment(int serviceAnnouncmentId)
        {
            ServiceAnnouncment dbEntry = context.ServiceAnnouncments.Find(serviceAnnouncmentId);
            if (dbEntry != null)
            {
                context.ServiceAnnouncments.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public void SaveServiceAnnouncment(ServiceAnnouncment serviceAnnouncment)
        {
            if (serviceAnnouncment.ServiceAnnouncmentId == 0)
            {
                context.ServiceAnnouncments.Add(serviceAnnouncment);
            }
            else
            {
                ServiceAnnouncment dbEntry = context.ServiceAnnouncments.Find(serviceAnnouncment.ServiceAnnouncmentId);
                if (dbEntry != null)
                {
                    dbEntry.Title = serviceAnnouncment.Title;
                    dbEntry.Bulletin = serviceAnnouncment.Bulletin;
                    dbEntry.AuthorId = serviceAnnouncment.AuthorId;
                }
            }
            context.SaveChanges();
        }
    }
}
