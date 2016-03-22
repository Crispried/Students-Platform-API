using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students.Web.Abstract
{
    public interface IAnnouncmentController
    {
        ActionResult GetAnnouncments();

        ActionResult AddAnnouncment();

        ActionResult DeleteAnnouncment(int announcmentId);

        ActionResult EditAnnouncment(int announcmentId);
    }
}