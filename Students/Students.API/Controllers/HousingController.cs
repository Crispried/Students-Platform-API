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
    public class HousingController : ApiController, IAnnouncmentController<HousingAnnouncment>, ICommentController<HousingComment>
    {
        private IHousingAnnouncmentRepository announcmentRepository;
        private ICommentRepository commentRepository;

        public HousingController(IHousingAnnouncmentRepository announcmentRepository,
                                 ICommentRepository commentRepository)
        {
            this.announcmentRepository = announcmentRepository;
            this.commentRepository = commentRepository;
        }

        [HttpPost]
        public IHttpActionResult AddAnnouncment(HousingAnnouncment announcment)
        {
            if (announcmentRepository.SaveHousingAnnouncment(announcment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult AddComment(HousingComment comment)
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
            if (announcmentRepository.DeleteHousingAnnouncment(announcmentId))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult DeleteComment(int commentId)
        {
            if (commentRepository.DeleteComment(commentId, CommentType.Housing))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult EditAnnouncment(HousingAnnouncment announcment)
        {
            if (announcmentRepository.SaveHousingAnnouncment(announcment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult EditComment(HousingComment comment)
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
            return Json(new { result = announcmentRepository.HousingAnnouncments });
        }

        [HttpPost]
        public IHttpActionResult GetComments()
        {
            return Json(new { result = commentRepository.Comments(CommentType.Housing) });
        }
    }
}
