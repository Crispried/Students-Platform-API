using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using Students.API.Abstract;

namespace Students.API.Controllers
{
    public class TravelController : ApiController, IAnnouncmentController<TravelAnnouncment>, ICommentController<TravelComment>
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
        public IHttpActionResult AddAnnouncment(TravelAnnouncment announcment)
        {
            if (announcmentRepository.SaveTravelAnnouncment(announcment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult AddComment(TravelComment comment)
        {
            if (commentRepository.SaveComment(comment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult DeleteAnnouncment(int announcmentId)
        {
            if (announcmentRepository.DeleteTravelAnnouncment(announcmentId))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult DeleteComment(int commentId)
        {
            if (commentRepository.DeleteComment(commentId, CommentType.Travel))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult EditAnnouncment(TravelAnnouncment announcment)
        {
            if (announcmentRepository.SaveTravelAnnouncment(announcment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult EditComment(TravelComment comment)
        {
            if (commentRepository.SaveComment(comment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult GetAnnouncments()
        {
            return Json(new { result = announcmentRepository.TravelAnnouncments });
        }

        [HttpPost]
        public IHttpActionResult GetComments()
        {
            return Json(new { result = commentRepository.Comments(CommentType.Travel) });
        }
    }
}
