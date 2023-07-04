using System.Web;

namespace Music.Web.Utilities.Tools
{
    public static class UserManager
    {
        public static string GetUserIP()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        public static bool IsUserAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static string GetCurrentUserName()
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }
}