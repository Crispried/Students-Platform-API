using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Domain.Abstract;
using Students.Web.Abstract;
using Students.Domain.ViewModels;

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
        public ActionResult AddAnnouncment(AnnouncmentVM announcment)
        {
            if (announcmentRepository.SaveTravelAnnouncment(announcment.TravelAnnouncment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult AddComment(CommentVM comment)
        {
            if (commentRepository.SaveComment(comment.TravelComment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult DeleteAnnouncment(int announcmentId)
        {
            if (announcmentRepository.DeleteTravelAnnouncment(announcmentId))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult DeleteComment(int commentId)
        {
            if (commentRepository.DeleteComment(commentId, Domain.Entities.CommentType.Travel))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult EditAnnouncment(AnnouncmentVM announcment)
        {
            if (announcmentRepository.SaveTravelAnnouncment(announcment.TravelAnnouncment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult EditComment(CommentVM comment)
        {
            if (commentRepository.SaveComment(comment.TravelComment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult GetAnnouncments()
        {
            return Json(new { result = announcmentRepository.TravelAnnouncments });
        }

        [HttpPost]
        public ActionResult GetComments()
        {
            return Json(new { result = commentRepository.Comments(Domain.Entities.CommentType.Travel) });
        }
    }
}