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
            if (serviceAnnouncment.ServiceAnnouncmentId == 0)
            {
                context.ServiceAnnouncments.Add(serviceAnnouncment);
            }
            else
            {
                ServiceAnnouncment dbEntry = context.ServiceAnnouncments.Find(serviceAnnouncment.ServiceAnnouncmentId);
                if (dbEntry != null)
                {
                    List<ServiceAnnouncmentLang> oldServiceAnnouncmentLangs = dbEntry.ServiceAnnouncmentLangs.ToList();
                    List<ServiceAnnouncmentLang> newServiceAnnouncmentLangs = serviceAnnouncment.ServiceAnnouncmentLangs.ToList();
                    foreach (var oldServiceAnnouncmentLang in oldServiceAnnouncmentLangs)
                    {
                        context.ServiceAnnouncmentLangs.Remove(oldServiceAnnouncmentLang);
                    }

                    foreach (var newServiceAnnouncmentLang in newServiceAnnouncmentLangs)
                    {
                        newServiceAnnouncmentLang.ServiceAnnouncmentId = serviceAnnouncment.ServiceAnnouncmentId;
                        context.ServiceAnnouncmentLangs.Add(newServiceAnnouncmentLang);
                    }

                    List<ServiceAnnouncmentImage> oldServiceAnnouncmentImages = dbEntry.ServiceAnnouncmentImages.ToList();
                    List<ServiceAnnouncmentImage> newServiceAnnouncmentImages = serviceAnnouncment.ServiceAnnouncmentImages.ToList();
                    foreach (var oldServiceAnnouncmentImage in oldServiceAnnouncmentImages)
                    {
                        context.ServiceAnnouncmentImages.Remove(oldServiceAnnouncmentImage);
                    }

                    foreach (var newServiceAnnouncmentImage in newServiceAnnouncmentImages)
                    {
                        newServiceAnnouncmentImage.ServiceAnnouncmentId = serviceAnnouncment.ServiceAnnouncmentId;
                        context.ServiceAnnouncmentImages.Add(newServiceAnnouncmentImage);
                    }
                }
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public ServiceAnnouncment GetAnnouncmentById(int announcmentId)
        {
            ServiceAnnouncment result = context.ServiceAnnouncments.Find(announcmentId);
            return result;
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
