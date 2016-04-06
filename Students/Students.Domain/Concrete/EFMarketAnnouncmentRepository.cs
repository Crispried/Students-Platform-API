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
            List<MarketAnnouncmentImage> marketAnnouncmentImages = marketAnnouncment.MarketAnnouncmentImages.ToList();
            if (marketAnnouncment.MarketAnnouncmentId == 0)
            {
                foreach (var marketAnnouncmentLang in marketAnnouncmentLangs)
                {
                    marketAnnouncment.MarketAnnouncmentLangs.Add(marketAnnouncmentLang);
                }
                foreach (var marketAnnouncmentImage in marketAnnouncmentImages)
                {
                    marketAnnouncment.MarketAnnouncmentImages.Add(marketAnnouncmentImage);
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
                List<MarketAnnouncmentLang> dbLangEntries = new List<MarketAnnouncmentLang>();
                string newTitle, newBulletin;
                for (int i = 0; i < marketAnnouncmentLangs.Count; i++)
                {
                    newTitle = marketAnnouncmentLangs[i].Title;
                    newBulletin = marketAnnouncmentLangs[i].Bulletin;
                    dbLangEntries[i] = context.MarketAnnouncmentLangs.Find(marketAnnouncmentLangs[i].MarketAnnouncmentLangId);
                    if (newTitle == null)
                    {
                        context.MarketAnnouncmentLangs.Remove(dbLangEntries[i]);
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
                            context.MarketAnnouncmentLangs.Add(marketAnnouncmentLangs[i]);
                        }
                    }
                }
                List<MarketAnnouncmentImage> dbImageEntries = new List<MarketAnnouncmentImage>();
                string newUrl;
                for (int i = 0; i < marketAnnouncmentImages.Count; i++)
                {
                    newUrl = marketAnnouncmentImages[i].Url;
                    dbImageEntries[i] = context.MarketAnnouncmentImages.Find(marketAnnouncmentImages[i].MarketAnnouncmentImageId);
                    if (newUrl == null)
                    {
                        context.MarketAnnouncmentImages.Remove(dbImageEntries[i]);
                    }
                    else
                    {
                        if (dbImageEntries[i] != null)
                        {
                            dbImageEntries[i].Url = newUrl;
                        }
                        else
                        {
                            context.MarketAnnouncmentImages.Add(marketAnnouncmentImages[i]);
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

        public MarketAnnouncment GetAnnouncmentById(int announcmentId)
        {
            MarketAnnouncment result = context.MarketAnnouncments.Find(announcmentId);
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
