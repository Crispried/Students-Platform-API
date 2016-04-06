using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Students.Domain.Entities;

namespace Students.API.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private readonly User _user;

        public CustomPrincipal(User user)
        {
            this._user = user;
            this.Identity = new GenericIdentity(user.UserName);
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(',').ToList();
            return roles.Contains(this._user.Role.ToString());
        }

        public IIdentity Identity { get; set; }
    }
}