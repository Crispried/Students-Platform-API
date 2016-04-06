using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;
using Students.Domain.Abstract;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using Students.Domain.ViewModel;

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

        public bool DeleteHousingAnnouncment(int housingAnnouncmentId)
        {
            HousingAnnouncment dbEntry = context.HousingAnnouncments.Find(housingAnnouncmentId);            
            if (dbEntry != null)
            {
                context.HousingAnnouncments.Remove(dbEntry);
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SaveHousingAnnouncment(HousingAnnouncment housingAnnouncment)
        {
            List<HousingAnnouncmentLang> housingAnnouncmentLangs = housingAnnouncment.HousingAnnouncmentLangs.ToList();
            List<HousingAnnouncmentImage> housingAnnouncmentImages = housingAnnouncment.HousingAnnouncmentImages.ToList();
            if (housingAnnouncment.HousingAnnouncmentId == 0)
            {
                foreach(var housingAnnouncmentLang in housingAnnouncmentLangs)
                {
                    housingAnnouncment.HousingAnnouncmentLangs.Add(housingAnnouncmentLang);
                }
                foreach(var housingAnnouncmentImage in housingAnnouncmentImages)
                {
                    housingAnnouncment.HousingAnnouncmentImages.Add(housingAnnouncmentImage);
                }
                context.HousingAnnouncments.Add(housingAnnouncment);
            }
            else
            {
                HousingAnnouncment dbEntry = context.HousingAnnouncments.Find(housingAnnouncment.HousingAnnouncmentId);
                if (dbEntry != null)
                {
                    dbEntry.AuthorId = housingAnnouncment.AuthorId;
                }
                List<HousingAnnouncmentLang> dbLangEntries = new List<HousingAnnouncmentLang>();
                string newTitle, newBulletin;
                for (int i = 0; i < housingAnnouncmentLangs.Count; i++)
                {
                    newTitle = housingAnnouncmentLangs[i].Title;
                    newBulletin = housingAnnouncmentLangs[i].Bulletin;
                    dbLangEntries[i] = context.HousingAnnouncmentLangs.Find(housingAnnouncmentLangs[i].HousingAnnouncmentLangId);
                    if(newTitle == null)
                    {
                        context.HousingAnnouncmentLangs.Remove(dbLangEntries[i]);
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
                            context.HousingAnnouncmentLangs.Add(housingAnnouncmentLangs[i]);
                        }
                    }
                }
                List<HousingAnnouncmentImage> dbImageEntries = new List<HousingAnnouncmentImage>();
                string newUrl;
                for (int i = 0; i < housingAnnouncmentImages.Count; i++)
                {
                    newUrl = housingAnnouncmentImages[i].Url;
                    dbImageEntries[i] = context.HousingAnnouncmentImages.Find(housingAnnouncmentImages[i].HousingAnnouncmentImageId);
                    if (newUrl == null)
                    {
                        context.HousingAnnouncmentImages.Remove(dbImageEntries[i]);
                    }
                    else
                    {
                        if (dbImageEntries[i] != null)
                        {
                            dbImageEntries[i].Url = newUrl;
                        }
                        else
                        {
                            context.HousingAnnouncmentImages.Add(housingAnnouncmentImages[i]);
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
                catch (DbUpdateException housingAnnouncmentUpdateException)
                {
                    housingAnnouncmentUpdateException = new DbUpdateException("Problems with housing announcment update.");
                    return false;
                }
                catch (DbEntityValidationException housingAnnouncmentValidationException)
                {
                    housingAnnouncmentValidationException = new DbEntityValidationException("Problems with housing announcment validation.");
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

        public HousingAnnouncment GetAnnouncmentById(int announcmentId)
        {
            HousingAnnouncment result = context.HousingAnnouncments.Find(announcmentId);
            return result;
        }
    }
}
