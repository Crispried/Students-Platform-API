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

                HousingAnnouncment dbEntry = context.HousingAnnouncments.Find(11);
                if (dbEntry != null)
                {
                    List<HousingAnnouncmentLang> oldHousingAnnouncmentLangs = dbEntry.HousingAnnouncmentLangs.ToList();
                    List<HousingAnnouncmentLang> newHousingAnnouncmentLangs = housingAnnouncment.HousingAnnouncmentLangs.ToList();
                    List<HousingAnnouncmentLang> updatedHousingAnnouncmentLangs = new List<HousingAnnouncmentLang>();
                    foreach (var oldHousingAnnouncmentLang in oldHousingAnnouncmentLangs)
                    {
                        context.HousingAnnouncmentLangs.Remove(oldHousingAnnouncmentLang);
                    }

                    foreach (var newHousingAnnouncmentLang in newHousingAnnouncmentLangs)
                    {
                        newHousingAnnouncmentLang.HousingAnnouncmentId = housingAnnouncment.HousingAnnouncmentId;
                        context.HousingAnnouncmentLangs.Add(newHousingAnnouncmentLang);
                    }

                    List<HousingAnnouncmentImage> oldHousingAnnouncmentImages = dbEntry.HousingAnnouncmentImages.ToList();
                    List<HousingAnnouncmentImage> newHousingAnnouncmentImages = housingAnnouncment.HousingAnnouncmentImages.ToList();
                    List<HousingAnnouncmentImage> updatedHousingAnnouncmentImages = new List<HousingAnnouncmentImage>();
                    foreach (var oldHousingAnnouncmentImage in oldHousingAnnouncmentImages)
                    {
                        context.HousingAnnouncmentImages.Remove(oldHousingAnnouncmentImage);
                    }

                    foreach (var newHousingAnnouncmentImage in newHousingAnnouncmentImages)
                    {
                        newHousingAnnouncmentImage.HousingAnnouncmentId = housingAnnouncment.HousingAnnouncmentId;
                        context.HousingAnnouncmentImages.Add(newHousingAnnouncmentImage);
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
