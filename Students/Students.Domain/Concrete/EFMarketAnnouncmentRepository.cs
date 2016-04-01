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
    public class EFMarketAnnouncmentRepository : IMarketAnnouncmentRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<MarketAnnouncment> MarketAnnouncments
        {
            get
            {
                return context.MarketAnnouncments;
            }
        }

        public bool DeleteMarketAnnouncment(int marketAnnouncmentId)
        {
            MarketAnnouncment dbEntry = context.MarketAnnouncments.Find(marketAnnouncmentId);
            if (dbEntry != null)
            {
                context.MarketAnnouncments.Remove(dbEntry);
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SaveMarketAnnouncment(MarketAnnouncment marketAnnouncment)
        {
            List<MarketAnnouncmentLang> marketAnnouncmentLangs = marketAnnouncment.MarketAnnouncmentLangs.ToList();
            if (marketAnnouncment.MarketAnnouncmentId == 0)
            {
                foreach (var marketAnnouncmentLang in marketAnnouncmentLangs)
                {
                    marketAnnouncment.MarketAnnouncmentLangs.Add(marketAnnouncmentLang);
                }
                context.MarketAnnouncments.Add(marketAnnouncment);
            }
            else
            {
                MarketAnnouncment dbEntry = context.MarketAnnouncments.Find(marketAnnouncment.MarketAnnouncmentId);
                if (dbEntry != null)
                {
                    dbEntry.AuthorId = marketAnnouncment.AuthorId;
                }
                List<MarketAnnouncmentLang> dbEntries = new List<MarketAnnouncmentLang>();
                for (int i = 0; i < marketAnnouncmentLangs.Count; i++)
                {
                    dbEntries[i] = context.MarketAnnouncmentLangs.Find(marketAnnouncmentLangs[i].MarketAnnouncmentLangId);
                    if (dbEntries[i] != null)
                    {
                        dbEntries[i].Title = marketAnnouncmentLangs[i].Title;
                        dbEntries[i].Bulletin = marketAnnouncmentLangs[i].Bulletin;
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
                catch (DbUpdateException marketAnnouncmentUpdateException)
                {
                    marketAnnouncmentUpdateException = new DbUpdateException("Problems with market announcment update.");
                    return false;
                }
                catch (DbEntityValidationException marketAnnouncmentValidationException)
                {
                    marketAnnouncmentValidationException = new DbEntityValidationException("Problems with market announcment validation.");
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
