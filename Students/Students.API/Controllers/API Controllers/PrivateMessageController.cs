using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using Students.Domain.ViewModel;
using Newtonsoft.Json.Linq;

namespace Students.API.Controllers.API_Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PrivateMessageController : ApiController
    {
        public IPrivateMessageRepository privateMessageRepository;
        public PrivateMessageController(IPrivateMessageRepository privateMessageRepository)
        {
            this.privateMessageRepository = privateMessageRepository;
        }

        [HttpPost]
        public HttpResponseMessage AddPrivateMessage([FromBody]JObject jsonData)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage EditPrivateMessage([FromBody]JObject jsonData)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage DeletePrivateMessage([FromBody]JObject jsonData)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage GetPrivateMessages([FromBody]JObject jsonData)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
