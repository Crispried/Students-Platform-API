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
        void SaveComment(HousingComment housingComment);

        /// <summary>
        /// saves travel comment in database
        /// </summary>
        /// <param name="travelComment"></param>
        void SaveComment(TravelComment travelComment);

        /// <summary>
        /// saves market comment in database
        /// </summary>
        /// <param name="marketComment"></param>
        void SaveComment(MarketComment marketComment);

        /// <summary>
        /// saves service comment in database
        /// </summary>
        /// <param name="serviceComment"></param>
        void SaveComment(ServiceComment serviceComment);

        /// <summary>
        /// deletes comment (depending on commentType) which id = commentId from database
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="commentType"></param>
        void DeleteComment(int commentId, CommentType commentType);
    }
}
