using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Domain.ViewModels;

namespace Students.Web.Abstract
{
    public interface IAnnouncmentController
    {
        ActionResult GetAnnouncments();

        ActionResult AddAnnouncment(AnnouncmentVM announcment);

        ActionResult DeleteAnnouncment(int announcmentId);

        ActionResult EditAnnouncment(AnnouncmentVM announcment);
    }
}