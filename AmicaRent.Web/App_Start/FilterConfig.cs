using System.Web.Mvc;
using WebApplication.UserManagement;

namespace WebApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute());
            filters.Add(new CustomAuthorizeAttribute());
        }
    }
}
