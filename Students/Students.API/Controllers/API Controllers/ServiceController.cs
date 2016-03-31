using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using Students.API.Abstract;
using Students.API.Infrastructure;

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
        public HttpResponseMessage AddAnnouncment(ServiceAnnouncment announcment)
        {
            if (announcment != null)
            {
                if (announcmentRepository.SaveServiceAnnouncment(announcment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage AddComment(ServiceComment comment)
        {
            if (comment != null)
            {
                if (commentRepository.SaveComment(comment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage DeleteAnnouncment(int announcmentId)
        {
            if (announcmentId != 0)
            {
                if (announcmentRepository.DeleteServiceAnnouncment(announcmentId))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage DeleteComment(int commentId)
        {
            if (commentId != 0)
            {
                if (commentRepository.DeleteComment(commentId, CommentType.Service))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage EditAnnouncment(ServiceAnnouncment announcment)
        {
            if (announcment != null)
            {
                if (announcmentRepository.SaveServiceAnnouncment(announcment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage EditComment(ServiceComment comment)
        {
            if (comment != null)
            {
                if (commentRepository.SaveComment(comment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage GetAnnouncments()
        {
            ICollection<ServiceAnnouncment> result = (ICollection<ServiceAnnouncment>)EntitiesFactory.GetViewModel(announcmentRepository.ServiceAnnouncments, EntitiesTypes.ServiceAnnouncment);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public HttpResponseMessage GetComments(int announcmentId)
        {
            if (announcmentId != 0)
            {
                List<Comment> comments = commentRepository.GetCommentsToAnnouncment(CommentType.Service, announcmentId).ToList();
                if (comments != null)
                {
                    Request.CreateResponse(HttpStatusCode.OK, comments);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
