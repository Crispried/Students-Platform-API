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
                Comment dbEntry = context.ServiceComments.Find(serviceComment.ServiceCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = serviceComment.Body;
                }
                List<ServiceCommentImage> dbImageEntries = new List<ServiceCommentImage>();
                string newUrl;
                for (int i = 0; i < serviceCommentImages.Count; i++)
                {
                    newUrl = serviceCommentImages[i].Url;
                    dbImageEntries[i] = context.ServiceCommentImages.Find(serviceCommentImages[i].ServiceCommentImageId);
                    if (newUrl == null)
                    {
                        context.ServiceCommentImages.Remove(dbImageEntries[i]);
                    }
                    else
                    {
                        if (dbImageEntries[i] != null)
                        {
                            dbImageEntries[i].Url = newUrl;
                        }
                        else
                        {
                            context.ServiceCommentImages.Add(serviceCommentImages[i]);
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
                Comment dbEntry = context.MarketComments.Find(marketComment.MarketCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = marketComment.Body;
                }
                List<MarketCommentImage> dbImageEntries = new List<MarketCommentImage>();
                string newUrl;
                for (int i = 0; i < marketCommentImages.Count; i++)
                {
                    newUrl = marketCommentImages[i].Url;
                    dbImageEntries[i] = context.MarketCommentImages.Find(marketCommentImages[i].MarketCommentImageId);
                    if (newUrl == null)
                    {
                        context.MarketCommentImages.Remove(dbImageEntries[i]);
                    }
                    else
                    {
                        if (dbImageEntries[i] != null)
                        {
                            dbImageEntries[i].Url = newUrl;
                        }
                        else
                        {
                            context.MarketCommentImages.Add(marketCommentImages[i]);
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
                Comment dbEntry = context.TravelComments.Find(travelComment.TravelCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = travelComment.Body;
                }
                List<TravelCommentImage> dbImageEntries = new List<TravelCommentImage>();
                string newUrl;
                for (int i = 0; i < travelCommentImages.Count; i++)
                {
                    newUrl = travelCommentImages[i].Url;
                    dbImageEntries[i] = context.TravelCommentImages.Find(travelCommentImages[i].TravelCommentImageId);
                    if (newUrl == null)
                    {
                        context.TravelCommentImages.Remove(dbImageEntries[i]);
                    }
                    else
                    {
                        if (dbImageEntries[i] != null)
                        {
                            dbImageEntries[i].Url = newUrl;
                        }
                        else
                        {
                            context.TravelCommentImages.Add(travelCommentImages[i]);
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
                Comment dbEntry = context.HousingComments.Find(housingComment.HousingCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = housingComment.Body;
                }
                List<HousingCommentImage> dbImageEntries = new List<HousingCommentImage>();
                string newUrl;
                for (int i = 0; i < housingCommentImages.Count; i++)
                {
                    newUrl = housingCommentImages[i].Url;
                    dbImageEntries[i] = context.HousingCommentImages.Find(housingCommentImages[i].HousingCommentImageId);
                    if (newUrl == null)
                    {
                        context.HousingCommentImages.Remove(dbImageEntries[i]);
                    }
                    else
                    {
                        if (dbImageEntries[i] != null)
                        {
                            dbImageEntries[i].Url = newUrl;
                        }
                        else
                        {
                            context.HousingCommentImages.Add(housingCommentImages[i]);
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
