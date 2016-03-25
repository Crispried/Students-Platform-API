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
    public class MarketController : ApiController, IAnnouncmentController<MarketAnnouncment>, ICommentController<MarketComment>
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
        public IHttpActionResult AddAnnouncment(MarketAnnouncment announcment)
        {
            if (announcmentRepository.SaveMarketAnnouncment(announcment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult AddComment(MarketComment comment)
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
            if (announcmentRepository.DeleteMarketAnnouncment(announcmentId))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult DeleteComment(int commentId)
        {
            if (commentRepository.DeleteComment(commentId, CommentType.Market))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult EditAnnouncment(MarketAnnouncment announcment)
        {
            if (announcmentRepository.SaveMarketAnnouncment(announcment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult EditComment(MarketComment comment)
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
            return Json(new { result = announcmentRepository.MarketAnnouncments });
        }

        [HttpPost]
        public IHttpActionResult GetComments()
        {
            return Json(new { result = commentRepository.Comments(CommentType.Market) });
        }
    }
}
