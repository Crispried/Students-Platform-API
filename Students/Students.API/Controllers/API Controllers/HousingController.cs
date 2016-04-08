using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using Students.Domain.ViewModel;
using Students.API.Infrastructure;

namespace Students.API.APIControllers.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HousingController : ApiController
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
        public HttpResponseMessage AddAnnouncment([FromBody]JObject jsonData)
        {
            try
            {
                HousingAnnouncment announcment = jsonData.GetValue("announcment").ToObject<HousingAnnouncment>();
                if (announcment != null)
                {
                    if (announcmentRepository.SaveHousingAnnouncment(announcment))
                    {
                        Request.CreateResponse(HttpStatusCode.OK);
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
                HousingComment comment = jsonData.GetValue("comment").ToObject<HousingComment>();
                if (comment != null)
                {
                    if (commentRepository.SaveComment(comment))
                    {
                        Request.CreateResponse(HttpStatusCode.OK);
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
                if (announcmentRepository.DeleteHousingAnnouncment(announcmentId))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
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
                if (commentRepository.DeleteComment(commentId, CommentType.Housing))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
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
                HousingAnnouncment announcment = jsonData.GetValue("announcment").ToObject<HousingAnnouncment>();
                if (announcment != null)
                {
                    if (announcmentRepository.SaveHousingAnnouncment(announcment))
                    {
                        Request.CreateResponse(HttpStatusCode.OK);
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
                HousingComment comment = jsonData.GetValue("comment").ToObject<HousingComment>();
                if (comment != null)
                {
                    if (commentRepository.SaveComment(comment))
                    {
                        Request.CreateResponse(HttpStatusCode.OK);
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
            List<object> result = EntitiesFactory.GetListViewModel(announcmentRepository.HousingAnnouncments, EntitiesTypes.HousingAnnouncment);            
            if(result != null)
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
                object result = EntitiesFactory.GetViewModel(announcmentRepository.GetAnnouncmentById(announcmentId), EntitiesTypes.HousingAnnouncment);
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
