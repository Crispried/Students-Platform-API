using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Students.Domain.Entities;
using System.Web;

namespace Students.API.Infrastructure
{
    public static class RequestSender
    {
        public static JWT SendRequest(string username, string password, UserRole role)
        {
            var request = (HttpWebRequest)WebRequest.Create(JWT_Globals.AuthServerUrl);

            var postData = "username=" + username;
            postData += "&password=" + password;
            postData += "&grant_type=password";
            postData += "&client_id=" + JWT_Globals.Audience;
            postData += "&Role=" + role;

            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            JWT token = JsonConvert.DeserializeObject<JWT>(responseString);

            return token;
        }
    }
}