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
                Comment dbEntry = context.ServiceComments.Find(serviceComment.ServiceCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = serviceComment.Body;
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
                Comment dbEntry = context.MarketComments.Find(marketComment.MarketCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = marketComment.Body;
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
                Comment dbEntry = context.TravelComments.Find(travelComment.TravelCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = travelComment.Body;
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
                Comment dbEntry = context.HousingComments.Find(housingComment.HousingCommentId);
                if (dbEntry != null)
                {
                    dbEntry.Body = housingComment.Body;
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
