using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain.Entities;
using System.Net.Http;

namespace Students.API.Abstract
{
    public interface ICommentController<T> where T : Comment
    {
        HttpResponseMessage GetComments(int announcmentId);

        HttpResponseMessage AddComment(T comment);

        HttpResponseMessage DeleteComment(int commentId);

        HttpResponseMessage EditComment(T comment);
    }
}
