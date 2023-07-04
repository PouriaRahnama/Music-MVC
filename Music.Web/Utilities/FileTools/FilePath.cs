using System.Web;

namespace Music.Web.Utilities.FileTools
{
    public class FilePath
    {
        #region Music Files

        public static string SongPath = "/Content/Files/Song/";
        public static string SongServerPath = HttpContext.Current.Server.MapPath("/Content/Files/Song/");


        #endregion
    }
}