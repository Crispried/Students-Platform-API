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

        public bool DeleteTravelAnnouncment(int travelAnnouncmentId)
        {
            TravelAnnouncment dbEntry = context.TravelAnnouncments.Find(travelAnnouncmentId);
            if (dbEntry != null)
            {
                context.TravelAnnouncments.Remove(dbEntry);
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SaveTravelAnnouncment(TravelAnnouncment travelAnnouncment)
        {
            List<TravelAnnouncmentLang> travelAnnouncmentLangs = travelAnnouncment.TravelAnnouncmentLangs.ToList();
            List<TravelAnnouncmentImage> travelAnnouncmentImages = travelAnnouncment.TravelAnnouncmentImages.ToList();
            if (travelAnnouncment.TravelAnnouncmentId == 0)
            {
                foreach (var travelAnnouncmentLang in travelAnnouncmentLangs)
                {
                    travelAnnouncment.TravelAnnouncmentLangs.Add(travelAnnouncmentLang);
                }
                foreach (var travelAnnouncmentImage in travelAnnouncmentImages)
                {
                    travelAnnouncment.TravelAnnouncmentImages.Add(travelAnnouncmentImage);
                }
                context.TravelAnnouncments.Add(travelAnnouncment);
            }
            else
            {
                TravelAnnouncment dbEntry = context.TravelAnnouncments.Find(travelAnnouncment.TravelAnnouncmentId);
                if (dbEntry != null)
                {
                    dbEntry.AuthorId = travelAnnouncment.AuthorId;  
                }
                List<TravelAnnouncmentLang> dbLangEntries = new List<TravelAnnouncmentLang>();
                string newTitle, newBulletin;
                for (int i = 0; i < travelAnnouncmentLangs.Count; i++)
                {
                    newTitle = travelAnnouncmentLangs[i].Title;
                    newBulletin = travelAnnouncmentLangs[i].Bulletin;
                    dbLangEntries[i] = context.TravelAnnouncmentLangs.Find(travelAnnouncmentLangs[i].TravelAnnouncmentLangId);
                    if (newTitle == null)
                    {
                        context.TravelAnnouncmentLangs.Remove(dbLangEntries[i]);
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
                            context.TravelAnnouncmentLangs.Add(travelAnnouncmentLangs[i]);
                        }
                    }
                }
                List<TravelAnnouncmentImage> dbImageEntries = new List<TravelAnnouncmentImage>();
                string newUrl;
                for (int i = 0; i < travelAnnouncmentImages.Count; i++)
                {
                    newUrl = travelAnnouncmentImages[i].Url;
                    dbImageEntries[i] = context.TravelAnnouncmentImages.Find(travelAnnouncmentImages[i].TravelAnnouncmentImageId);
                    if (newUrl == null)
                    {
                        context.TravelAnnouncmentImages.Remove(dbImageEntries[i]);
                    }
                    else
                    {
                        if (dbImageEntries[i] != null)
                        {
                            dbImageEntries[i].Url = newUrl;
                        }
                        else
                        {
                            context.TravelAnnouncmentImages.Add(travelAnnouncmentImages[i]);
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
                catch (DbUpdateException travelAnnouncmentUpdateException)
                {
                    travelAnnouncmentUpdateException = new DbUpdateException("Problems with travel announcment update.");
                    return false;
                }
                catch (DbEntityValidationException travelAnnouncmentValidationException)
                {
                    travelAnnouncmentValidationException = new DbEntityValidationException("Problems with travel announcment validation.");
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
