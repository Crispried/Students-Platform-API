using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using Students.API.Infrastructure;
using Students.Domain.ViewModel;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace Students.API.APIControllers.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TravelController : ApiController
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
        public HttpResponseMessage AddAnnouncment([FromBody]JObject jsonData)
        {
            try
            {
                TravelAnnouncment announcment = jsonData.GetValue("announcment").ToObject<TravelAnnouncment>();
                if (announcment != null)
                {
                    if (announcmentRepository.SaveTravelAnnouncment(announcment))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (NullReferenceException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage AddComment([FromBody]JObject jsonData)
        {
            try
            {
                TravelComment comment = jsonData.GetValue("comment").ToObject<TravelComment>();
                if (comment != null)
                {
                    if (commentRepository.SaveComment(comment))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (NullReferenceException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage DeleteAnnouncment([FromBody]JObject jsonData)
        {
            int announcmentId = Convert.ToInt32(jsonData.GetValue("announcmentId"));
            if (announcmentId != 0)
            {
                if (announcmentRepository.DeleteTravelAnnouncment(announcmentId))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage DeleteComment([FromBody]JObject jsonData)
        {
            int commentId = Convert.ToInt32(jsonData.GetValue("commentId"));
            if (commentId != 0)
            {
                if (commentRepository.DeleteComment(commentId, CommentType.Travel))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage EditAnnouncment([FromBody]JObject jsonData)
        {
            try
            {
                TravelAnnouncment announcment = jsonData.GetValue("announcment").ToObject<TravelAnnouncment>();
                if (announcment != null)
                {
                    if (announcmentRepository.SaveTravelAnnouncment(announcment))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (NullReferenceException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage EditComment([FromBody]JObject jsonData)
        {
            try
            {
                TravelComment comment = jsonData.GetValue("comment").ToObject<TravelComment>();
                if (comment != null)
                {
                    if (commentRepository.SaveComment(comment))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (NullReferenceException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
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
        public HttpResponseMessage GetAnnouncment([FromBody]JObject jsonData)
        {
            var announcmentId = Convert.ToInt32(jsonData.GetValue("announcmentId"));
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
        public HttpResponseMessage GetComments([FromBody]JObject jsonData)
        {
            var announcmentId = Convert.ToInt32(jsonData.GetValue("announcmentId"));
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
