using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Domain.Entities;
using Students.Domain.Abstract;
using Students.Web.Abstract;

namespace Students.Web.Controllers
{
    public class TravelController : Controller, IAnnouncmentController, ICommentController
    {
        private ITravelAnnouncmentRepository announcmentRepository;
        private ICommentRepository commentRepository;

        public TravelController(ITravelAnnouncmentRepository announcmentRepository,
                                ICommentRepository commentRepository)
        {
            this.announcmentRepository = announcmentRepository;
            this.commentRepository = commentRepository;
        }

        [HttpPost]
        public ActionResult AddAnnouncment()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult AddComment()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult DeleteAnnouncment(int announcmentId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult DeleteComment(int commentId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EditAnnouncment(int announcmentId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EditComment(int commentId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult GetAnnouncments()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult GetComments()
        {
            throw new NotImplementedException();
        }
    }
}