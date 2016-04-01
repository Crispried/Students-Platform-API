using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

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

        public bool DeleteServiceAnnouncment(int serviceAnnouncmentId)
        {
            ServiceAnnouncment dbEntry = context.ServiceAnnouncments.Find(serviceAnnouncmentId);
            if (dbEntry != null)
            {
                context.ServiceAnnouncments.Remove(dbEntry);
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SaveServiceAnnouncment(ServiceAnnouncment serviceAnnouncment)
        {
            List<ServiceAnnouncmentLang> serviceAnnouncmentLangs = serviceAnnouncment.ServiceAnnouncmentLangs.ToList();
            if (serviceAnnouncment.ServiceAnnouncmentId == 0)
            {
                foreach (var serviceAnnouncmentLang in serviceAnnouncmentLangs)
                {
                    serviceAnnouncment.ServiceAnnouncmentLangs.Add(serviceAnnouncmentLang);
                }
                context.ServiceAnnouncments.Add(serviceAnnouncment);
            }
            else
            {
                ServiceAnnouncment dbEntry = context.ServiceAnnouncments.Find(serviceAnnouncment.ServiceAnnouncmentId);
                if (dbEntry != null)
                {
                    dbEntry.AuthorId = serviceAnnouncment.AuthorId;
                }
                List<ServiceAnnouncmentLang> dbEntries = new List<ServiceAnnouncmentLang>();
                for (int i = 0; i < serviceAnnouncmentLangs.Count; i++)
                {
                    dbEntries[i] = context.ServiceAnnouncmentLangs.Find(serviceAnnouncmentLangs[i].ServiceAnnouncmentLangId);
                    if (dbEntries[i] != null)
                    {
                        dbEntries[i].Title = serviceAnnouncmentLangs[i].Title;
                        dbEntries[i].Bulletin = serviceAnnouncmentLangs[i].Bulletin;
                    }
                }
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool ContextWasSaved()
        {
            if (EFDbContext.HasUnsavedChanges(context))
            {
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException serviceAnnouncmentUpdateException)
                {
                    serviceAnnouncmentUpdateException = new DbUpdateException("Problems with service announcment update.");
                    return false;
                }
                catch (DbEntityValidationException serviceAnnouncmentValidationException)
                {
                    serviceAnnouncmentValidationException = new DbEntityValidationException("Problems with service announcment validation.");
                    return false;
                }
                catch (ObjectDisposedException contextDisposedException)
                {
                    contextDisposedException = new ObjectDisposedException("Context was disposed.");
                    return false;
                }
            }
            return true;
        }
    }
}
