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
using Students.Domain.ViewModel;

namespace Students.API.APIControllers.Controllers
{
    public class TravelController : ApiController, ICommentController<TravelComment>
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
        public HttpResponseMessage AddAnnouncment(TravelAnnouncment announcment)
        {
            if (announcment != null)
            {
                if (announcmentRepository.SaveTravelAnnouncment(announcment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage AddComment(TravelComment comment)
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
                if (announcmentRepository.DeleteTravelAnnouncment(announcmentId))
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
                if (commentRepository.DeleteComment(commentId, CommentType.Travel))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage EditAnnouncment(TravelAnnouncment announcment)
        {
            if (announcment != null)
            {
                if (announcmentRepository.SaveTravelAnnouncment(announcment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage EditComment(TravelComment comment)
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
            ICollection<TravelAnnouncment> result = (ICollection<TravelAnnouncment>)EntitiesFactory.GetViewModel(announcmentRepository.TravelAnnouncments, EntitiesTypes.TravelAnnouncment);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public HttpResponseMessage GetAnnouncment(int announcmentId)
        {
            if (announcmentId != 0)
            {
                object result = EntitiesFactory.GetViewModel(announcmentRepository.GetAnnouncmentById(announcmentId), EntitiesTypes.TravelAnnouncment);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage GetComments(int announcmentId)
        {
            if (announcmentId != 0)
            {
                IQueryable<Comment> comments = commentRepository.GetCommentsToAnnouncment(CommentType.Travel, announcmentId);
                List<object> result = EntitiesFactory.GetListViewModel(comments, EntitiesTypes.Comment);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
