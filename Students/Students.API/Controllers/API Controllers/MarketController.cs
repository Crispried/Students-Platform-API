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

namespace Students.API.APIControllers.Controllers
{
    public class MarketController : ApiController
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
        public HttpResponseMessage AddAnnouncment([FromBody]JObject jsonData)
        {
            MarketAnnouncment announcment = jsonData.GetValue("announcment").ToObject<MarketAnnouncment>();
            if (announcment != null)
            {
                if (announcmentRepository.SaveMarketAnnouncment(announcment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage AddComment([FromBody]JObject jsonData)
        {
            MarketComment comment = jsonData.GetValue("comment").ToObject<MarketComment>();
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
        public HttpResponseMessage DeleteAnnouncment([FromBody]JObject jsonData)
        {
            int announcmentId = Convert.ToInt32(jsonData.GetValue("announcmentId"));
            if (announcmentId != 0)
            {
                if (announcmentRepository.DeleteMarketAnnouncment(announcmentId))
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
                if (commentRepository.DeleteComment(commentId, CommentType.Market))
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
            MarketAnnouncment announcment = jsonData.GetValue("announcment").ToObject<MarketAnnouncment>();
            if (announcment != null)
            {
                if (announcmentRepository.SaveMarketAnnouncment(announcment))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage EditComment([FromBody]JObject jsonData)
        {
            MarketComment comment = jsonData.GetValue("comment").ToObject<MarketComment>();
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
            ICollection<MarketAnnouncment> result = (ICollection<MarketAnnouncment>)EntitiesFactory.GetViewModel(announcmentRepository.MarketAnnouncments, EntitiesTypes.MarketAnnouncment);
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
                object result = EntitiesFactory.GetViewModel(announcmentRepository.GetAnnouncmentById(announcmentId), EntitiesTypes.MarketAnnouncment);
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
                IQueryable<Comment> comments = commentRepository.GetCommentsToAnnouncment(CommentType.Market, announcmentId);
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
