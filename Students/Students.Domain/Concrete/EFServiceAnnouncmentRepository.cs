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
            List<ServiceAnnouncmentImage> serviceAnnouncmentImages = serviceAnnouncment.ServiceAnnouncmentImages.ToList();
            if (serviceAnnouncment.ServiceAnnouncmentId == 0)
            {
                foreach (var serviceAnnouncmentLang in serviceAnnouncmentLangs)
                {
                    serviceAnnouncment.ServiceAnnouncmentLangs.Add(serviceAnnouncmentLang);
                }
                foreach (var serviceAnnouncmentImage in serviceAnnouncmentImages)
                {
                    serviceAnnouncment.ServiceAnnouncmentImages.Add(serviceAnnouncmentImage);
                }
                context.ServiceAnnouncments.Add(serviceAnnouncment);
            }
            else
            {
                ServiceAnnouncment dbEntry = context.ServiceAnnouncments.Find(serviceAnnouncment.ServiceAnnouncmentId);
                if (dbEntry != null)
                {
                    List<ServiceAnnouncmentLang> oldServiceAnnouncmentLangs = dbEntry.ServiceAnnouncmentLangs.ToList();
                    List<ServiceAnnouncmentLang> updatedServiceAnnouncmentLangs = new List<ServiceAnnouncmentLang>();
                    List<ServiceAnnouncmentLang> newServiceAnnouncmentLangs = serviceAnnouncment.ServiceAnnouncmentLangs.ToList();
                    foreach (var oldServiceAnnouncmentLang in oldServiceAnnouncmentLangs)
                    {
                        if (newServiceAnnouncmentLangs.Any(nsal => nsal.LanguageId == oldServiceAnnouncmentLang.LanguageId))
                        {
                            updatedServiceAnnouncmentLangs.Add(oldServiceAnnouncmentLang);
                        }
                        else
                        {
                            context.ServiceAnnouncmentLangs.Remove(oldServiceAnnouncmentLang);
                        }
                    }
                    for (int i = 0; i < updatedServiceAnnouncmentLangs.Count; i++)
                    {
                        if (newServiceAnnouncmentLangs[i].LanguageId == updatedServiceAnnouncmentLangs[i].LanguageId)
                        {
                            updatedServiceAnnouncmentLangs[i] = newServiceAnnouncmentLangs[i];
                            newServiceAnnouncmentLangs.Remove(newServiceAnnouncmentLangs[i]);
                        }
                    }
                    foreach (var newServiceAnnouncmentLang in newServiceAnnouncmentLangs)
                    {
                        dbEntry.ServiceAnnouncmentLangs.Add(newServiceAnnouncmentLang);
                    }

                    List<ServiceAnnouncmentImage> oldServiceAnnouncmentImages = dbEntry.ServiceAnnouncmentImages.ToList();
                    List<ServiceAnnouncmentImage> updatedServiceAnnouncmentImages = new List<ServiceAnnouncmentImage>();
                    List<ServiceAnnouncmentImage> newServiceAnnouncmentImages = serviceAnnouncment.ServiceAnnouncmentImages.ToList();
                    foreach (var oldServiceAnnouncmentImage in oldServiceAnnouncmentImages)
                    {
                        if (newServiceAnnouncmentImages.Any(nsai => nsai.ServiceAnnouncmentImageId == oldServiceAnnouncmentImage.ServiceAnnouncmentImageId))
                        {
                            updatedServiceAnnouncmentImages.Add(oldServiceAnnouncmentImage);
                        }
                        else
                        {
                            context.ServiceAnnouncmentImages.Remove(oldServiceAnnouncmentImage);
                        }
                    }
                    for (int i = 0; i < updatedServiceAnnouncmentImages.Count; i++)
                    {
                        if (newServiceAnnouncmentImages[i].ServiceAnnouncmentImageId == updatedServiceAnnouncmentImages[i].ServiceAnnouncmentImageId)
                        {
                            updatedServiceAnnouncmentImages[i] = newServiceAnnouncmentImages[i];
                            newServiceAnnouncmentImages.Remove(newServiceAnnouncmentImages[i]);
                        }
                    }
                    foreach (var newServiceAnnouncmentImage in newServiceAnnouncmentImages)
                    {
                        dbEntry.ServiceAnnouncmentImages.Add(newServiceAnnouncmentImage);
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
