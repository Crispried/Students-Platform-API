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
                    List<TravelAnnouncmentLang> newTravelAnnouncmentLangs = travelAnnouncment.TravelAnnouncmentLangs.ToList();
                    foreach (var oldTravelAnnouncmentLang in oldTravelAnnouncmentLangs)
                    {
                        context.TravelAnnouncmentLangs.Remove(oldTravelAnnouncmentLang);
                    }

                    foreach (var newTravelAnnouncmentLang in newTravelAnnouncmentLangs)
                    {
                        newTravelAnnouncmentLang.TravelAnnouncmentId = travelAnnouncment.TravelAnnouncmentId;
                        context.TravelAnnouncmentLangs.Add(newTravelAnnouncmentLang);
                    }

                    List<TravelAnnouncmentImage> oldTravelAnnouncmentImages = dbEntry.TravelAnnouncmentImages.ToList();
                    List<TravelAnnouncmentImage> newTravelAnnouncmentImages = travelAnnouncment.TravelAnnouncmentImages.ToList();
                    foreach (var oldTravelAnnouncmentImage in oldTravelAnnouncmentImages)
                    {
                        context.TravelAnnouncmentImages.Remove(oldTravelAnnouncmentImage);
                    }

                    foreach (var newTravelAnnouncmentImage in newTravelAnnouncmentImages)
                    {
                        newTravelAnnouncmentImage.TravelAnnouncmentId = travelAnnouncment.TravelAnnouncmentId;
                        context.TravelAnnouncmentImages.Add(newTravelAnnouncmentImage);
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
