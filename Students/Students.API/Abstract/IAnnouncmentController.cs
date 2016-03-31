using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Students.Domain.Entities;
using System.Net.Http;

namespace Students.API.Abstract
{
    public interface IAnnouncmentController<T> where T : Announcment
    {
        HttpResponseMessage GetAnnouncments();

        HttpResponseMessage AddAnnouncment(T announcment);

        HttpResponseMessage DeleteAnnouncment(int announcmentId);

        HttpResponseMessage EditAnnouncment(T announcment);
    }
}