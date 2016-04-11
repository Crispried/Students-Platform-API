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
    public class EFCommentRepository : ICommentRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Comment> Comments(CommentType commentType)
        {
            switch (commentType)
            {
                case CommentType.Housing:
                    return context.HousingComments;
                case CommentType.Travel:
                    return context.TravelComments;
                case CommentType.Market:
                    return context.MarketComments;
                case CommentType.Service:
                    return context.ServiceComments;
            }
            return null;
        }

        public IQueryable<Comment> GetCommentsToAnnouncment(CommentType commentType, int announcmentId)
        {
            switch (commentType)
            {
                case CommentType.Housing:
                    return context.HousingComments.Where(comm => comm.HousingAnnouncmentId == announcmentId);
                case CommentType.Travel:
                    return context.TravelComments.Where(comm => comm.TravelAnnouncmentId == announcmentId);
                case CommentType.Market:
                    return context.MarketComments.Where(comm => comm.MarketAnnouncmentId == announcmentId);
                case CommentType.Service:
                    return context.ServiceComments.Where(comm => comm.ServiceAnnouncmentId == announcmentId);
            }
            return null;
        }

        public bool DeleteComment(int commentId, CommentType commentType)
        {

            Comment dbEntry = null;
            switch (commentType)
            {
                case CommentType.Housing:
                    dbEntry = context.HousingComments.Find(commentId);
                    if (dbEntry != null)
                    {
                        context.HousingComments.Remove((HousingComment)dbEntry);
                    }
                    break;
                case CommentType.Travel:
                    dbEntry = context.TravelComments.Find(commentId);
                    if (dbEntry != null)
                    {
                        context.TravelComments.Remove((TravelComment)dbEntry);
                    }
                    break;
                case CommentType.Market:
                    dbEntry = context.MarketComments.Find(commentId);
                    if (dbEntry != null)
                    {
                        context.MarketComments.Remove((MarketComment)dbEntry);
                    }
                    break;
                case CommentType.Service:
                    dbEntry = context.ServiceComments.Find(commentId);
                    if (dbEntry != null)
                    {
                        context.ServiceComments.Remove((ServiceComment)dbEntry);
                    }
                    break;
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }
        

        public bool SaveComment(ServiceComment serviceComment)
        {
            List<ServiceCommentImage> serviceCommentImages = serviceComment.ServiceCommentImages.ToList();
            if (serviceComment.ServiceCommentId == 0)
            {
                foreach (var serviceCommentImage in serviceCommentImages)
                {
                    serviceComment.ServiceCommentImages.Add(serviceCommentImage);
                }
                context.ServiceComments.Add(serviceComment);
            }
            else
            {
                ServiceComment dbEntry = context.ServiceComments.Find(serviceComment.ServiceCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = serviceComment.Body;
                    
                    List<ServiceCommentImage> oldServiceCommentImages = dbEntry.ServiceCommentImages.ToList();
                    List<ServiceCommentImage> updatedServiceCommentImages = new List<ServiceCommentImage>();
                    List<ServiceCommentImage> newServiceCommentImages = serviceComment.ServiceCommentImages.ToList();
                    foreach (var oldServiceCommentImage in oldServiceCommentImages)
                    {
                        if (newServiceCommentImages.Any(nsci => nsci.ServiceCommentImageId == oldServiceCommentImage.ServiceCommentImageId))
                        {
                            updatedServiceCommentImages.Add(oldServiceCommentImage);
                        }
                        else
                        {
                            context.ServiceCommentImages.Remove(oldServiceCommentImage);
                        }
                    }
                    for (int i = 0; i < updatedServiceCommentImages.Count; i++)
                    {
                        if (newServiceCommentImages[i].ServiceCommentImageId == updatedServiceCommentImages[i].ServiceCommentImageId)
                        {
                            updatedServiceCommentImages[i] = newServiceCommentImages[i];
                            newServiceCommentImages.Remove(newServiceCommentImages[i]);
                        }
                    }
                    foreach (var newServiceCommentImage in newServiceCommentImages)
                    {
                        dbEntry.ServiceCommentImages.Add(newServiceCommentImage);
                    }
                }                
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SaveComment(MarketComment marketComment)
        {
            List<MarketCommentImage> marketCommentImages = marketComment.MarketCommentImages.ToList();
            if (marketComment.MarketCommentId == 0)
            {
                foreach (var marketCommentImage in marketCommentImages)
                {
                    marketComment.MarketCommentImages.Add(marketCommentImage);
                }
                context.MarketComments.Add(marketComment);
            }
            else
            {
                MarketComment dbEntry = context.MarketComments.Find(marketComment.MarketCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = marketComment.Body;

                    List<MarketCommentImage> oldMarketCommentImages = dbEntry.MarketCommentImages.ToList();
                    List<MarketCommentImage> updatedMarketCommentImages = new List<MarketCommentImage>();
                    List<MarketCommentImage> newMarketCommentImages = marketComment.MarketCommentImages.ToList();
                    foreach (var oldMarketCommentImage in oldMarketCommentImages)
                    {
                        if (newMarketCommentImages.Any(nmci => nmci.MarketCommentImageId == oldMarketCommentImage.MarketCommentImageId))
                        {
                            updatedMarketCommentImages.Add(oldMarketCommentImage);
                        }
                        else
                        {
                            context.MarketCommentImages.Remove(oldMarketCommentImage);
                        }
                    }
                    for (int i = 0; i < updatedMarketCommentImages.Count; i++)
                    {
                        if (newMarketCommentImages[i].MarketCommentImageId == updatedMarketCommentImages[i].MarketCommentImageId)
                        {
                            updatedMarketCommentImages[i] = newMarketCommentImages[i];
                            newMarketCommentImages.Remove(newMarketCommentImages[i]);
                        }
                    }
                    foreach (var newMarketCommentImage in newMarketCommentImages)
                    {
                        dbEntry.MarketCommentImages.Add(newMarketCommentImage);
                    }
                }
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SaveComment(TravelComment travelComment)
        {
            List<TravelCommentImage> travelCommentImages = travelComment.TravelCommentImages.ToList();
            if (travelComment.TravelCommentId == 0)
            {
                foreach (var travelCommentImage in travelCommentImages)
                {
                    travelComment.TravelCommentImages.Add(travelCommentImage);
                }
                context.TravelComments.Add(travelComment);
            }
            else
            {
                TravelComment dbEntry = context.TravelComments.Find(travelComment.TravelCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = travelComment.Body;

                    List<TravelCommentImage> oldTravelCommentImages = dbEntry.TravelCommentImages.ToList();
                    List<TravelCommentImage> updatedTravelCommentImages = new List<TravelCommentImage>();
                    List<TravelCommentImage> newTravelCommentImages = travelComment.TravelCommentImages.ToList();
                    foreach (var oldTravelCommentImage in oldTravelCommentImages)
                    {
                        if (newTravelCommentImages.Any(ntci => ntci.TravelCommentImageId == oldTravelCommentImage.TravelCommentImageId))
                        {
                            updatedTravelCommentImages.Add(oldTravelCommentImage);
                        }
                        else
                        {
                            context.TravelCommentImages.Remove(oldTravelCommentImage);
                        }
                    }
                    for (int i = 0; i < updatedTravelCommentImages.Count; i++)
                    {
                        if (newTravelCommentImages[i].TravelCommentImageId == updatedTravelCommentImages[i].TravelCommentImageId)
                        {
                            updatedTravelCommentImages[i] = newTravelCommentImages[i];
                            newTravelCommentImages.Remove(newTravelCommentImages[i]);
                        }
                    }
                    foreach (var newTravelCommentImage in newTravelCommentImages)
                    {
                        dbEntry.TravelCommentImages.Add(newTravelCommentImage);
                    }
                }
            }
            if (ContextWasSaved())
            {
                return true;
            }
            return false;
        }

        public bool SaveComment(HousingComment housingComment)
        {
            List<HousingCommentImage> housingCommentImages = housingComment.HousingCommentImages.ToList();
            if (housingComment.HousingCommentId == 0)
            {
                context.HousingComments.Add(housingComment);
                foreach (var housingCommentImage in housingCommentImages)
                {
                    housingComment.HousingCommentImages.Add(housingCommentImage);
                }
            }
            else
            {
                HousingComment dbEntry = context.HousingComments.Find(housingComment.HousingCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = housingComment.Body;

                    List<HousingCommentImage> oldHousingCommentImages = dbEntry.HousingCommentImages.ToList();
                    List<HousingCommentImage> updatedHousingCommentImages = new List<HousingCommentImage>();
                    List<HousingCommentImage> newHousingCommentImages = housingComment.HousingCommentImages.ToList();
                    foreach (var oldHousingCommentImage in oldHousingCommentImages)
                    {
                        if (newHousingCommentImages.Any(nhci => nhci.HousingCommentImageId == oldHousingCommentImage.HousingCommentImageId))
                        {
                            updatedHousingCommentImages.Add(oldHousingCommentImage);
                        }
                        else
                        {
                            context.HousingCommentImages.Remove(oldHousingCommentImage);
                        }
                    }
                    for (int i = 0; i < updatedHousingCommentImages.Count; i++)
                    {
                        if (newHousingCommentImages[i].HousingCommentImageId == updatedHousingCommentImages[i].HousingCommentImageId)
                        {
                            updatedHousingCommentImages[i] = newHousingCommentImages[i];
                            newHousingCommentImages.Remove(newHousingCommentImages[i]);
                        }
                    }
                    foreach (var newHousingCommentImage in newHousingCommentImages)
                    {
                        dbEntry.HousingCommentImages.Add(newHousingCommentImage);
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
                catch (DbUpdateException commentUpdateException)
                {
                    commentUpdateException = new DbUpdateException("Problems with comment update.");
                    return false;
                }
                catch (DbEntityValidationException commentValidationException)
                {
                    commentValidationException = new DbEntityValidationException("Problems with comment validation.");
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
