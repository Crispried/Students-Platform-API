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
            if(announcment != null)
            {
                if (announcmentRepository.SaveHousingAnnouncment(announcment))
                {
                    return Json(new { result = "Success" });
                }
                return Json(new { result = "Can't add" });
            }
            return Json(new { result = "Request is null" });
        }

        [HttpPost]
        public IHttpActionResult AddComment(HousingComment comment)
        {
            if(comment != null)
            {
                if (commentRepository.SaveComment(comment))
                {
                    return Json(new { result = "Success" });
                }
                return Json(new { result = "Can't add" });
            }
            return Json(new { result = "Request is null" });
        }

        [HttpPost]
        public IHttpActionResult DeleteAnnouncment(int announcmentId)
        {
            if (announcmentId != 0)
            {
                if (announcmentRepository.DeleteHousingAnnouncment(announcmentId))
                {
                    return Json(new { result = "Success" });
                }
                return Json(new { result = "Can't delete" });
            }
            return Json(new { result = "Request is 0" });
        }

        [HttpPost]
        public IHttpActionResult DeleteComment(int commentId)
        {
            if(commentId != 0)
            {
                if (commentRepository.DeleteComment(commentId, CommentType.Housing))
                {
                    return Json(new { result = "Success" });
                }
                return Json(new { result = "Can't delete" });
            }
            return Json(new { result = "Request is 0" });
        }

        [HttpPost]
        public IHttpActionResult EditAnnouncment(HousingAnnouncment announcment)
        {
            if(announcment != null)
            {
                if (announcmentRepository.SaveHousingAnnouncment(announcment))
                {
                    return Json(new { result = "Success" });
                }
                return Json(new { result = "Can't edit" });
            }
            return Json(new { result = "Request is null" });
        }

        [HttpPost]
        public IHttpActionResult EditComment(HousingComment comment)
        {
            if(comment != null)
            {
                if (commentRepository.SaveComment(comment))
                {
                    return Json(new { result = "Success" });
                }
                return Json(new { result = "Can't edit" });
            }
            return Json(new { result = "Request is null" });
        }

        [HttpPost]
        public IHttpActionResult GetAnnouncments()
        {
            List<HousingAnnouncment> announcments = announcmentRepository.HousingAnnouncments.ToList();
            if(announcments != null)
            {
                return Json(new { result = announcments });
            }
            return Json(new { result = "Not found" });
        }

        [HttpPost]
        public IHttpActionResult GetComments(int announcmentId)
        {
            if(announcmentId != 0)
            {
                List<Comment> comments = commentRepository.GetCommentsToAnnouncment(CommentType.Housing, announcmentId).ToList();
                if (comments != null)
                {
                    return Json(new { result = comments });
                }
                return Json(new { result = "Not found" });
            }
            return Json(new { result = "Request is 0" });
        }
    }
}
