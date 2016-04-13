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
            if (marketAnnouncment.MarketAnnouncmentId == 0)
            {
                context.MarketAnnouncments.Add(marketAnnouncment);
            }
            else
            {
                MarketAnnouncment dbEntry = context.MarketAnnouncments.Find(marketAnnouncment.MarketAnnouncmentId);
                if (dbEntry != null)
                {
                    List<MarketAnnouncmentLang> oldMarketAnnouncmentLangs = dbEntry.MarketAnnouncmentLangs.ToList();
                    List<MarketAnnouncmentLang> updatedMarketAnnouncmentLangs = new List<MarketAnnouncmentLang>();
                    List<MarketAnnouncmentLang> newMarketAnnouncmentLangs = marketAnnouncment.MarketAnnouncmentLangs.ToList();
                    foreach (var oldMarketAnnouncmentLang in oldMarketAnnouncmentLangs)
                    {
                        if (newMarketAnnouncmentLangs.Any(nmal => nmal.LanguageId == oldMarketAnnouncmentLang.LanguageId))
                        {
                            updatedMarketAnnouncmentLangs.Add(oldMarketAnnouncmentLang);
                        }
                        else
                        {
                            context.MarketAnnouncmentLangs.Remove(oldMarketAnnouncmentLang);
                        }
                    }
                    for (int i = 0; i < updatedMarketAnnouncmentLangs.Count; i++)
                    {
                        if (newMarketAnnouncmentLangs[i].LanguageId == updatedMarketAnnouncmentLangs[i].LanguageId)
                        {
                            updatedMarketAnnouncmentLangs[i] = newMarketAnnouncmentLangs[i];
                            newMarketAnnouncmentLangs.Remove(newMarketAnnouncmentLangs[i]);
                        }
                    }
                    foreach (var newMarketAnnouncmentLang in newMarketAnnouncmentLangs)
                    {
                        dbEntry.MarketAnnouncmentLangs.Add(newMarketAnnouncmentLang);
                    }

                    List<MarketAnnouncmentImage> oldMarketAnnouncmentImages = dbEntry.MarketAnnouncmentImages.ToList();
                    List<MarketAnnouncmentImage> updatedMarketAnnouncmentImages = new List<MarketAnnouncmentImage>();
                    List<MarketAnnouncmentImage> newMarketAnnouncmentImages = marketAnnouncment.MarketAnnouncmentImages.ToList();
                    foreach (var oldMarketAnnouncmentImage in oldMarketAnnouncmentImages)
                    {
                        if (newMarketAnnouncmentImages.Any(nhai => nhai.MarketAnnouncmentImageId == oldMarketAnnouncmentImage.MarketAnnouncmentImageId))
                        {
                            updatedMarketAnnouncmentImages.Add(oldMarketAnnouncmentImage);
                        }
                        else
                        {
                            context.MarketAnnouncmentImages.Remove(oldMarketAnnouncmentImage);
                        }
                    }
                    for (int i = 0; i < updatedMarketAnnouncmentImages.Count; i++)
                    {
                        if (newMarketAnnouncmentImages[i].MarketAnnouncmentImageId == updatedMarketAnnouncmentImages[i].MarketAnnouncmentImageId)
                        {
                            updatedMarketAnnouncmentImages[i] = newMarketAnnouncmentImages[i];
                            newMarketAnnouncmentImages.Remove(newMarketAnnouncmentImages[i]);
                        }
                    }
                    foreach (var newMarketAnnouncmentImage in newMarketAnnouncmentImages)
                    {
                        dbEntry.MarketAnnouncmentImages.Add(newMarketAnnouncmentImage);
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
