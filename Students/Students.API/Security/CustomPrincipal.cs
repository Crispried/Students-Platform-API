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
        private Account Account;

        public CustomPrincipal(Account account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.UserName);
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(UserRole role)//was string
        {
            //var roles = role.Split(new char[] { ',' });
            //return roles.Any(r => this.Account.Roles.Contains(r));

            return this.Account.Role.Equals(role);
        }
    }
}