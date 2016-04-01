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
            if (travelAnnouncment.TravelAnnouncmentId == 0)
            {
                foreach (var travelAnnouncmentLang in travelAnnouncmentLangs)
                {
                    travelAnnouncment.TravelAnnouncmentLangs.Add(travelAnnouncmentLang);
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
                List<TravelAnnouncmentLang> dbEntries = new List<TravelAnnouncmentLang>();
                for (int i = 0; i < travelAnnouncmentLangs.Count; i++)
                {
                    dbEntries[i] = context.TravelAnnouncmentLangs.Find(travelAnnouncmentLangs[i].TravelAnnouncmentLangId);
                    if (dbEntries[i] != null)
                    {
                        dbEntries[i].Title = travelAnnouncmentLangs[i].Title;
                        dbEntries[i].Bulletin = travelAnnouncmentLangs[i].Bulletin;
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
