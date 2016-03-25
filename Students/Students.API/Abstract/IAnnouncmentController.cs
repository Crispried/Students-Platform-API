using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Students.Domain.Entities;
using System.Web.Http;

namespace Students.API.Abstract
{
    public interface IAnnouncmentController<T> where T : Announcment
    {
        IHttpActionResult GetAnnouncments();

        IHttpActionResult AddAnnouncment(T announcment);

        IHttpActionResult DeleteAnnouncment(int announcmentId);

        IHttpActionResult EditAnnouncment(T announcment);
    }
}