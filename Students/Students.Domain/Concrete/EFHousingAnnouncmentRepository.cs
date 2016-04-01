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
            if (housingAnnouncment.HousingAnnouncmentId == 0)
            {
                foreach(var housingAnnouncmentLang in housingAnnouncmentLangs)
                {
                    housingAnnouncment.HousingAnnouncmentLangs.Add(housingAnnouncmentLang);
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
                List<HousingAnnouncmentLang> dbEntries = new List<HousingAnnouncmentLang>();
                for (int i = 0; i < housingAnnouncmentLangs.Count; i++)
                {
                    dbEntries[i] = context.HousingAnnouncmentLangs.Find(housingAnnouncmentLangs[i].HousingAnnouncmentLangId);
                    if(dbEntries[i] != null)
                    {
                        dbEntries[i].Title = housingAnnouncmentLangs[i].Title;
                        dbEntries[i].Bulletin = housingAnnouncmentLangs[i].Bulletin;
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
    }
}
