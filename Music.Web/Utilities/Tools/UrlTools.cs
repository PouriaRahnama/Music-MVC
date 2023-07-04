namespace Music.Web.Utilities.Tools
{
    public static class UrlTools
    {
        public static string FixedForUrl(this string url)
        {
            return url.Replace(" ", "-");
        }
    }
}