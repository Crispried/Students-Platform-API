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

            if (housingAnnouncment.HousingAnnouncmentId == 0)
            {
                context.HousingAnnouncments.Add(housingAnnouncment);
            }
            else
            {

                HousingAnnouncment dbEntry = context.HousingAnnouncments.Find(housingAnnouncment.HousingAnnouncmentId);
                if (dbEntry != null)
                {
                    List<HousingAnnouncmentLang> oldHousingAnnouncmentLangs = dbEntry.HousingAnnouncmentLangs.ToList();
                    List<HousingAnnouncmentLang> updatedHousingAnnouncmentLangs = new List<HousingAnnouncmentLang>();
                    List<HousingAnnouncmentLang> newHousingAnnouncmentLangs = housingAnnouncment.HousingAnnouncmentLangs.ToList();
                    foreach (var oldHousingAnnouncmentLang in oldHousingAnnouncmentLangs)
                    {
                        if(newHousingAnnouncmentLangs.Any(nhal => nhal.LanguageId == oldHousingAnnouncmentLang.LanguageId))
                        {
                            updatedHousingAnnouncmentLangs.Add(oldHousingAnnouncmentLang);                           
                        }
                        else
                        {
                            context.HousingAnnouncmentLangs.Remove(oldHousingAnnouncmentLang);
                        }
                    }
                    for (int i = 0; i < updatedHousingAnnouncmentLangs.Count; i++)
                    {
                        if(newHousingAnnouncmentLangs[i].LanguageId == updatedHousingAnnouncmentLangs[i].LanguageId)
                        {
                            updatedHousingAnnouncmentLangs[i] = newHousingAnnouncmentLangs[i];
                            newHousingAnnouncmentLangs.Remove(newHousingAnnouncmentLangs[i]);                            
                        }
                    }
                    foreach (var newHousingAnnouncmentLang in newHousingAnnouncmentLangs)
                    {
                        dbEntry.HousingAnnouncmentLangs.Add(newHousingAnnouncmentLang);
                    }

                    List<HousingAnnouncmentImage> oldHousingAnnouncmentImages = dbEntry.HousingAnnouncmentImages.ToList();
                    List<HousingAnnouncmentImage> updatedHousingAnnouncmentImages = new List<HousingAnnouncmentImage>();
                    List<HousingAnnouncmentImage> newHousingAnnouncmentImages = housingAnnouncment.HousingAnnouncmentImages.ToList();
                    foreach (var oldHousingAnnouncmentImage in oldHousingAnnouncmentImages)
                    {
                        if (newHousingAnnouncmentImages.Any(nhai => nhai.HousingAnnouncmentImageId == oldHousingAnnouncmentImage.HousingAnnouncmentImageId))
                        {                            
                            updatedHousingAnnouncmentImages.Add(oldHousingAnnouncmentImage);
                        }
                        else
                        {
                            context.HousingAnnouncmentImages.Remove(oldHousingAnnouncmentImage);
                        }
                    }
                    for (int i = 0; i < updatedHousingAnnouncmentImages.Count; i++)
                    {
                        if (newHousingAnnouncmentImages[i].HousingAnnouncmentImageId == updatedHousingAnnouncmentImages[i].HousingAnnouncmentImageId)
                        {
                            updatedHousingAnnouncmentImages[i] = newHousingAnnouncmentImages[i];
                            newHousingAnnouncmentImages.Remove(newHousingAnnouncmentImages[i]);
                        }
                    }
                    foreach (var newHousingAnnouncmentImage in newHousingAnnouncmentImages)
                    {
                        dbEntry.HousingAnnouncmentImages.Add(newHousingAnnouncmentImage);
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
