using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using Students.API.Abstract;
using Students.Domain.ViewModel;
using Students.API.Infrastructure;

namespace Students.API.APIControllers.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HousingController : ApiController, ICommentController<HousingComment>
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
        public HttpResponseMessage AddAnnouncment(HousingAnnouncment announcment)
        {
            if(announcment != null)
            {
                if (announcmentRepository.SaveHousingAnnouncment(announcment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage AddComment(HousingComment comment)
        {
            if(comment != null)
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
                if (announcmentRepository.DeleteHousingAnnouncment(announcmentId))
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
            if(commentId != 0)
            {
                if (commentRepository.DeleteComment(commentId, CommentType.Housing))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage EditAnnouncment(HousingAnnouncment announcment)
        {
            if(announcment != null)
            {
                if (announcmentRepository.SaveHousingAnnouncment(announcment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage EditComment(HousingComment comment)
        {
            if(comment != null)
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
        public HttpResponseMessage GetAnnouncment(int announcmentId)
        {
            if(announcmentId != 0)
            {
                object result = EntitiesFactory.GetViewModel(announcmentRepository.GetAnnouncmentById(announcmentId), EntitiesTypes.HousingAnnouncment);
                if(result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage GetAnnouncments()
        {
            List<object> result = EntitiesFactory.GetListViewModel(announcmentRepository.HousingAnnouncments, EntitiesTypes.HousingAnnouncment);            
            if(result != null)
            {                
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public HttpResponseMessage GetComments(int announcmentId)
        {
            if(announcmentId != 0)
            {
                IQueryable<Comment> comments = commentRepository.GetCommentsToAnnouncment(CommentType.Housing, announcmentId);
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
