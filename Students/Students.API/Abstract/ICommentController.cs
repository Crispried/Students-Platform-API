using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;
using System.Web.Http;

namespace Students.API.Abstract
{
    public interface ICommentController<T> where T : Comment
    {
        IHttpActionResult GetComments(int announcmentId);

        IHttpActionResult AddComment(T comment);

        IHttpActionResult DeleteComment(int commentId);

        IHttpActionResult EditComment(T comment);
    }
}
