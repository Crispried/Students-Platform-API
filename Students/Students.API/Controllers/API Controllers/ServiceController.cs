using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using Students.API.Abstract;

namespace Students.API.APIControllers.Controllers
{
    public class ServiceController : ApiController, IAnnouncmentController<ServiceAnnouncment>, ICommentController<ServiceComment>
    {
        private IServiceAnnouncmentRepository announcmentRepository;
        private ICommentRepository commentRepository;

        public ServiceController(IServiceAnnouncmentRepository announcmentRepository,
                                 ICommentRepository commentRepository)
        {
            this.announcmentRepository = announcmentRepository;
            this.commentRepository = commentRepository;
        }

        [HttpPost]
        public IHttpActionResult AddAnnouncment(ServiceAnnouncment announcment)
        {
            if (announcmentRepository.SaveServiceAnnouncment(announcment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult AddComment(ServiceComment comment)
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
            if (announcmentRepository.DeleteServiceAnnouncment(announcmentId))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult DeleteComment(int commentId)
        {
            if (commentRepository.DeleteComment(commentId, CommentType.Service))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult EditAnnouncment(ServiceAnnouncment announcment)
        {
            if (announcmentRepository.SaveServiceAnnouncment(announcment))
            {
                return Json(new { result = "" });
            }
            return Json(new { result = "" });
        }

        [HttpPost]
        public IHttpActionResult EditComment(ServiceComment comment)
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
            return Json(new { result = announcmentRepository.ServiceAnnouncments });
        }

        [HttpPost]
        public IHttpActionResult GetComments(int announcmentId)
        {
            return Json(new { result = commentRepository.Comments(CommentType.Service) });
        }
    }
}
