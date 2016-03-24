using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Students.Domain.ViewModels;

namespace Students.Web.Abstract
{
    public interface ICommentController
    {
        ActionResult GetComments();

        ActionResult AddComment(CommentVM comment);

        ActionResult DeleteComment(int commentId);

        ActionResult EditComment(CommentVM comment);
    }
}
