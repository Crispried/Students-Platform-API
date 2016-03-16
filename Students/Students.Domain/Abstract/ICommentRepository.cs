using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;

namespace Students.Domain.Abstract
{
    public interface ICommentRepository
    {
        /// <summary>
        /// gets all comments (depending on commentType) from database
        /// </summary>
        /// <param name="commentType"></param>
        /// <returns></returns>
        IQueryable<Comment> Comments(CommentType commentType);

        /// <summary>
        /// saves housing comment in database
        /// </summary>
        /// <param name="housingComment"></param>
        bool SaveComment(HousingComment housingComment);

        /// <summary>
        /// saves travel comment in database
        /// </summary>
        /// <param name="travelComment"></param>
        bool SaveComment(TravelComment travelComment);

        /// <summary>
        /// saves market comment in database
        /// </summary>
        /// <param name="marketComment"></param>
        bool SaveComment(MarketComment marketComment);

        /// <summary>
        /// saves service comment in database
        /// </summary>
        /// <param name="serviceComment"></param>
        bool SaveComment(ServiceComment serviceComment);

        /// <summary>
        /// deletes comment (depending on commentType) which id = commentId from database
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="commentType"></param>
        bool DeleteComment(int commentId, CommentType commentType);
    }
}
