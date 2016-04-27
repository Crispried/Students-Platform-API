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
                    List<MarketAnnouncmentLang> newMarketAnnouncmentLangs = marketAnnouncment.MarketAnnouncmentLangs.ToList();
                    foreach (var oldMarketAnnouncmentLang in oldMarketAnnouncmentLangs)
                    {
                        context.MarketAnnouncmentLangs.Remove(oldMarketAnnouncmentLang);
                    }

                    foreach (var newMarketAnnouncmentLang in newMarketAnnouncmentLangs)
                    {
                        newMarketAnnouncmentLang.MarketAnnouncmentId = marketAnnouncment.MarketAnnouncmentId;
                        context.MarketAnnouncmentLangs.Add(newMarketAnnouncmentLang);
                    }

                    List<MarketAnnouncmentImage> oldMarketAnnouncmentImages = dbEntry.MarketAnnouncmentImages.ToList();
                    List<MarketAnnouncmentImage> newMarketAnnouncmentImages = marketAnnouncment.MarketAnnouncmentImages.ToList();
                    foreach (var oldMarketAnnouncmentImage in oldMarketAnnouncmentImages)
                    {
                        context.MarketAnnouncmentImages.Remove(oldMarketAnnouncmentImage);
                    }

                    foreach (var newMarketAnnouncmentImage in newMarketAnnouncmentImages)
                    {
                        newMarketAnnouncmentImage.MarketAnnouncmentId = marketAnnouncment.MarketAnnouncmentId;
                        context.MarketAnnouncmentImages.Add(newMarketAnnouncmentImage);
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
