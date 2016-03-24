using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Domain.ViewModels;
using Students.Domain.Abstract;
using Students.Web.Abstract;

namespace Students.Web.Controllers
{
    public class MarketController : Controller, IAnnouncmentController, ICommentController
    {
        private IMarketAnnouncmentRepository announcmentRepository;
        private ICommentRepository commentRepository;

        public MarketController(IMarketAnnouncmentRepository announcmentRepository,
                                ICommentRepository commentRepository)
        {
            this.announcmentRepository = announcmentRepository;
            this.commentRepository = commentRepository;
        }

        [HttpPost]
        public ActionResult AddAnnouncment(AnnouncmentVM announcment)
        {
            if (announcmentRepository.SaveMarketAnnouncment(announcment.MarketAnnouncment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult AddComment(CommentVM comment)
        {
            if (commentRepository.SaveComment(comment.MarketComment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult DeleteAnnouncment(int announcmentId)
        {
            if (announcmentRepository.DeleteMarketAnnouncment(announcmentId))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult DeleteComment(int commentId)
        {
            if (commentRepository.DeleteComment(commentId, Domain.Entities.CommentType.Market))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult EditAnnouncment(AnnouncmentVM announcment)
        {
            if (announcmentRepository.SaveMarketAnnouncment(announcment.MarketAnnouncment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult EditComment(CommentVM comment)
        {
            if (commentRepository.SaveComment(comment.MarketComment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public ActionResult GetAnnouncments()
        {
            return Json(new { result = announcmentRepository.MarketAnnouncments });
        }

        [HttpPost]
        public ActionResult GetComments()
        {
            return Json(new { result = commentRepository.Comments(Domain.Entities.CommentType.Market) });
        }
    }
}