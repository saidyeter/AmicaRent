using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication.UserManagement
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly UserManager userManager = new UserManager();
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            //this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var rd = httpContext.Request.RequestContext.RouteData;
            //string currentAction = rd.GetRequiredString("action");
            string currentController = rd.GetRequiredString("controller");
            //string currentArea = rd.Values["area"] as string;
            int kullanici_ID = Convert.ToInt32(httpContext.Session["UserId"]);

            try
            {

                var roles = userManager.GetRoles(kullanici_ID);
                roles.Add("Account");
                roles.Add("Home");
                return roles.Contains(currentController);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }

            //bool authorize = false;
            //var userId = Convert.ToString(httpContext.Session["UserId"]);
            //if (!string.IsNullOrEmpty(userId))
            //    using (var context = new SqlDbContext())
            //    {
            //        var userRole = (from u in context.Users
            //                        join r in context.Roles on u.RoleId equals r.Id
            //                        where u.UserId == userId
            //                        select new
            //                        {
            //                            r.Name
            //                        }).FirstOrDefault();
            //        foreach (var role in allowedroles)
            //        {
            //            if (role == userRole.Name) return true;
            //        }
            //    }


            //return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Account" },
                    { "action", "Login" }
                    
               });
        }
    }
}