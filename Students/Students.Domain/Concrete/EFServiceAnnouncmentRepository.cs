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
                    dbEntry.AuthorId = serviceAnnouncment.AuthorId;
                }
                List<ServiceAnnouncmentLang> dbLangEntries = new List<ServiceAnnouncmentLang>();
                string newTitle, newBulletin;
                for (int i = 0; i < serviceAnnouncmentLangs.Count; i++)
                {
                    newTitle = serviceAnnouncmentLangs[i].Title;
                    newBulletin = serviceAnnouncmentLangs[i].Bulletin;
                    dbLangEntries[i] = context.ServiceAnnouncmentLangs.Find(serviceAnnouncmentLangs[i].ServiceAnnouncmentLangId);
                    if (newTitle == null)
                    {
                        context.ServiceAnnouncmentLangs.Remove(dbLangEntries[i]);
                    }
                    else
                    {
                        if (dbLangEntries[i] != null)
                        {
                            dbLangEntries[i].Title = newTitle;
                            dbLangEntries[i].Bulletin = newBulletin;
                        }
                        else
                        {
                            context.ServiceAnnouncmentLangs.Add(serviceAnnouncmentLangs[i]);
                        }
                    }
                }
                List<ServiceAnnouncmentImage> dbImageEntries = new List<ServiceAnnouncmentImage>();
                string newUrl;
                for (int i = 0; i < serviceAnnouncmentImages.Count; i++)
                {
                    newUrl = serviceAnnouncmentImages[i].Url;
                    dbImageEntries[i] = context.ServiceAnnouncmentImages.Find(serviceAnnouncmentImages[i].ServiceAnnouncmentImageId);
                    if (newUrl == null)
                    {
                        context.ServiceAnnouncmentImages.Remove(dbImageEntries[i]);
                    }
                    else
                    {
                        if (dbImageEntries[i] != null)
                        {
                            dbImageEntries[i].Url = newUrl;
                        }
                        else
                        {
                            context.ServiceAnnouncmentImages.Add(serviceAnnouncmentImages[i]);
                        }
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
