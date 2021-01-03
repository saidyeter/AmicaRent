using AmicaRent.DataAccess;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication.UserManagement
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    { 
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            string username = httpContext.User.Identity.Name;

            var rd = httpContext.Request.RequestContext.RouteData;
            //string currentAction = rd.GetRequiredString("action");
            string currentController = rd.GetRequiredString("controller");
            //string currentArea = rd.Values["area"] as string;


            try
            {
                AmicaRentDBContext db = new AmicaRentDBContext();
                var user = db.Kullanici.FirstOrDefault(x => x.Kullanici_Adi == username);
                if (user is null)
                {
                    throw new Exception("Kullanıcı bulunamadı.");
                }

                var userRoles = db.KullaniciRolIliskileri.Where(x => x.Kullanici_ID == user.Kullanici_ID).Select(x => x.Rol_ID);
                var roleNames = db.KullaniciRolTanimlari.Where(x => userRoles.Contains(x.Rol_ID)).Select(x => x.Rol_Adi).ToList();

                roleNames.Add("Account");
                roleNames.Add("Home");
                roleNames.Add("Root");

                httpContext.Items["Roles"] = "'" + string.Join("','", roleNames.ToList()) + "'";

                return roleNames.Contains(currentController);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            httpContext.Items["error"] = "Yetki Bulunamadı";
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Account" },
                    { "action", "Login" },
                    { "returnUrl" , filterContext.HttpContext.Request.Url.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped) }
               });
        }
    }
}