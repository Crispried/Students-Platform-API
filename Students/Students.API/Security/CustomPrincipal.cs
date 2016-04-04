using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Students.API.Models;
using Students.Domain.Entities;

namespace Students.API.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private readonly Account _account;

        public CustomPrincipal(Account account)
        {
            this._account = account;
            this.Identity = new GenericIdentity(account.UserName);
        }

        public bool IsInRole(string role)
        {
            return this._account.Role.ToString() == role;
        }

        public IIdentity Identity { get; set; }
    }
}