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
            if (travelAnnouncment.TravelAnnouncmentId == 0)
            {
                context.TravelAnnouncments.Add(travelAnnouncment);
            }
            else
            {
                TravelAnnouncment dbEntry = context.TravelAnnouncments.Find(travelAnnouncment.TravelAnnouncmentId);
                if (dbEntry != null)
                {
                    List<TravelAnnouncmentLang> oldTravelAnnouncmentLangs = dbEntry.TravelAnnouncmentLangs.ToList();
                    List<TravelAnnouncmentLang> updatedTravelAnnouncmentLangs = new List<TravelAnnouncmentLang>();
                    List<TravelAnnouncmentLang> newTravelAnnouncmentLangs = travelAnnouncment.TravelAnnouncmentLangs.ToList();
                    foreach (var oldTravelAnnouncmentLang in oldTravelAnnouncmentLangs)
                    {
                        if (newTravelAnnouncmentLangs.Any(ntal => ntal.LanguageId == oldTravelAnnouncmentLang.LanguageId))
                        {
                            updatedTravelAnnouncmentLangs.Add(oldTravelAnnouncmentLang);
                        }
                        else
                        {
                            context.TravelAnnouncmentLangs.Remove(oldTravelAnnouncmentLang);
                        }
                    }
                    for (int i = 0; i < updatedTravelAnnouncmentLangs.Count; i++)
                    {
                        if (newTravelAnnouncmentLangs[i].LanguageId == updatedTravelAnnouncmentLangs[i].LanguageId)
                        {
                            updatedTravelAnnouncmentLangs[i] = newTravelAnnouncmentLangs[i];
                            newTravelAnnouncmentLangs.Remove(newTravelAnnouncmentLangs[i]);
                        }
                    }
                    foreach (var newTravelAnnouncmentLang in newTravelAnnouncmentLangs)
                    {
                        dbEntry.TravelAnnouncmentLangs.Add(newTravelAnnouncmentLang);
                    }

                    List<TravelAnnouncmentImage> oldTravelAnnouncmentImages = dbEntry.TravelAnnouncmentImages.ToList();
                    List<TravelAnnouncmentImage> updatedTravelAnnouncmentImages = new List<TravelAnnouncmentImage>();
                    List<TravelAnnouncmentImage> newTravelAnnouncmentImages = travelAnnouncment.TravelAnnouncmentImages.ToList();
                    foreach (var oldTravelAnnouncmentImage in oldTravelAnnouncmentImages)
                    {
                        if (newTravelAnnouncmentImages.Any(ntai => ntai.TravelAnnouncmentImageId == oldTravelAnnouncmentImage.TravelAnnouncmentImageId))
                        {
                            updatedTravelAnnouncmentImages.Add(oldTravelAnnouncmentImage);
                        }
                        else
                        {
                            context.TravelAnnouncmentImages.Remove(oldTravelAnnouncmentImage);
                        }
                    }
                    for (int i = 0; i < newTravelAnnouncmentImages.Count; i++)
                    {
                        if (newTravelAnnouncmentImages[i].TravelAnnouncmentImageId == newTravelAnnouncmentImages[i].TravelAnnouncmentImageId)
                        {
                            newTravelAnnouncmentImages[i] = newTravelAnnouncmentImages[i];
                            newTravelAnnouncmentImages.Remove(newTravelAnnouncmentImages[i]);
                        }
                    }
                    foreach (var newTravelAnnouncmentImage in newTravelAnnouncmentImages)
                    {
                        dbEntry.TravelAnnouncmentImages.Add(newTravelAnnouncmentImage);
                    }
                }
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public TravelAnnouncment GetAnnouncmentById(int announcmentId)
        {
            TravelAnnouncment result = context.TravelAnnouncments.Find(announcmentId);
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
