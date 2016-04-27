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
            if (serviceComment.ServiceCommentId == 0)
            {
                context.ServiceComments.Add(serviceComment);
            }
            else
            {
                ServiceComment dbEntry = context.ServiceComments.Find(serviceComment.ServiceCommentId);
                if (dbEntry != null)
                {
                    List<ServiceCommentImage> oldServiceCommentImages = dbEntry.ServiceCommentImages.ToList();
                    List<ServiceCommentImage> newServiceCommentImages = serviceComment.ServiceCommentImages.ToList();
                    foreach (var oldServiceCommentImage in oldServiceCommentImages)
                    {
                        context.ServiceCommentImages.Remove(oldServiceCommentImage);
                    }

                    foreach (var newServiceCommentImage in newServiceCommentImages)
                    {
                        newServiceCommentImage.ServiceCommentId = serviceComment.ServiceCommentId;
                        context.ServiceCommentImages.Add(newServiceCommentImage);
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
            if (marketComment.MarketCommentId == 0)
            {
                context.MarketComments.Add(marketComment);
            }
            else
            {
                MarketComment dbEntry = context.MarketComments.Find(marketComment.MarketCommentId);
                if (dbEntry != null)
                {
                    List<MarketCommentImage> oldMarketCommentImages = dbEntry.MarketCommentImages.ToList();
                    List<MarketCommentImage> newMarketCommentImages = marketComment.MarketCommentImages.ToList();
                    foreach (var oldMarketCommentImage in oldMarketCommentImages)
                    {
                        context.MarketCommentImages.Remove(oldMarketCommentImage);
                    }

                    foreach (var newMarketCommentImage in newMarketCommentImages)
                    {
                        newMarketCommentImage.MarketCommentId = marketComment.MarketCommentId;
                        context.MarketCommentImages.Add(newMarketCommentImage);
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
            if (travelComment.TravelCommentId == 0)
            {
                context.TravelComments.Add(travelComment);
            }
            else
            {
                TravelComment dbEntry = context.TravelComments.Find(travelComment.TravelCommentId);
                if (dbEntry != null)
                {
                    List<TravelCommentImage> oldTravelCommentImages = dbEntry.TravelCommentImages.ToList();
                    List<TravelCommentImage> newTravelCommentImages = travelComment.TravelCommentImages.ToList();
                    foreach (var oldTravelCommentImage in oldTravelCommentImages)
                    {
                        context.TravelCommentImages.Remove(oldTravelCommentImage);
                    }

                    foreach (var newTravelCommentImage in newTravelCommentImages)
                    {
                        newTravelCommentImage.TravelCommentId = travelComment.TravelCommentId;
                        context.TravelCommentImages.Add(newTravelCommentImage);
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
            if (housingComment.HousingCommentId == 0)
            {
                context.HousingComments.Add(housingComment);
            }
            else
            {
                HousingComment dbEntry = context.HousingComments.Find(housingComment.HousingCommentId);
                if (dbEntry != null)
                {
                    List<HousingCommentImage> oldHousingCommentImages = dbEntry.HousingCommentImages.ToList();
                    List<HousingCommentImage> newHousingCommentImages = housingComment.HousingCommentImages.ToList();
                    foreach (var oldHousingCommentImage in oldHousingCommentImages)
                    {
                        context.HousingCommentImages.Remove(oldHousingCommentImage);
                    }

                    foreach (var newHousingCommentImage in newHousingCommentImages)
                    {
                        newHousingCommentImage.HousingCommentId = housingComment.HousingCommentId;
                        context.HousingCommentImages.Add(newHousingCommentImage);
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
