using System.Web;

namespace Music.Web.Utilities.FileTools
{
    public static class Add_RemoveFile
    {
        public static void AddFileToServer(this HttpPostedFileBase file, string filePath, string fileName, string deletedFileName = null)
        {
            if (System.IO.File.Exists(filePath + deletedFileName))
            {
                System.IO.File.Delete(filePath + deletedFileName);
            }

            file.SaveAs(filePath + fileName);
        }

    }

}