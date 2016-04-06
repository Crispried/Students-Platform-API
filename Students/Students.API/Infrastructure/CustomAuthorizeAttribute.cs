using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Students.Domain.Concrete;

namespace Students.API.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new { controller = "Account", action = "Login" }));
            }
            else
            {
                var am = new EFUserRepository();
                CustomPrincipal mp = new CustomPrincipal(am.GetUserByUserName(SessionPersister.Username));
                if (!mp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult
                    (
                        new RouteValueDictionary
                        (
                            new { controller = "AccessDenied", action = "Index" }
                        )
                    );
                }
            }
        }
    }
}