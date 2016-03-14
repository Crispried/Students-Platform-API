using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Abstract;
using Students.Domain.Entities;

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

        public void DeleteComment(int commentId, CommentType commentType)
        {
            Comment dbEntry;
            switch (commentType)
            {
                case CommentType.Housing:
                    dbEntry = context.HousingComments.Find(commentId);
                    if(dbEntry != null)
                    {
                        context.HousingComments.Remove((HousingComment)dbEntry);
                        context.SaveChanges();
                    }
                    break;
                case CommentType.Travel:
                    dbEntry = context.TravelComments.Find(commentId);
                    if (dbEntry != null)
                    {
                        context.TravelComments.Remove((TravelComment)dbEntry);
                        context.SaveChanges();
                    }
                    break;
                case CommentType.Market:
                    dbEntry = context.MarketComments.Find(commentId);
                    if (dbEntry != null)
                    {
                        context.MarketComments.Remove((MarketComment)dbEntry);
                        context.SaveChanges();
                    }
                    break;
                case CommentType.Service:
                    dbEntry = context.ServiceComments.Find(commentId);
                    if (dbEntry != null)
                    {
                        context.ServiceComments.Remove((ServiceComment)dbEntry);
                        context.SaveChanges();
                    }
                    break;
            }
        }

        public void SaveComment(ServiceComment serviceComment)
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
            context.SaveChanges();
        }

        public void SaveComment(MarketComment marketComment)
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
            context.SaveChanges();
        }

        public void SaveComment(TravelComment travelComment)
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
            context.SaveChanges();
        }

        public void SaveComment(HousingComment housingComment)
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
            context.SaveChanges();
        }
    }
}
