using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Students.Web.Abstract
{
    public interface ICommentController
    {
        ActionResult GetComments();

        ActionResult AddComment();

        ActionResult DeleteComment(int commentId);

        ActionResult EditComment(int commentId);
    }
}
