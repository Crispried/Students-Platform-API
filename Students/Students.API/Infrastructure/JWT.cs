using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.API.Infrastructure
{
    public static class JWT_Globals
    {
        public const string Audience = "099153c2625149bc8ecb3e85e03f0022";
        public const string AuthServerUrl = "http://authorization-server.azurewebsites.net/oauth2/token";
        public static byte[] Secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");
    }
    public class JWT
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}