using Music.Convertor;
using System.Web;

namespace Music.Web.Utilities.ImageTools
{
    public static class Image
    {
        public static void AddImageToServer(this HttpPostedFileBase image, string imageName, string orginalPath, int? width, int? height, string thumbPath = null, string deleteImageName = null)
        {
            if (image != null)
            {
                // remove image
                if (!string.IsNullOrEmpty(deleteImageName))
                {
                    if (System.IO.File.Exists(orginalPath + deleteImageName))
                    {
                        System.IO.File.Delete(orginalPath + deleteImageName);
                    }

                    if (!string.IsNullOrEmpty(thumbPath))
                    {
                        if (System.IO.File.Exists(thumbPath + deleteImageName))
                        {
                            System.IO.File.Delete(thumbPath + deleteImageName);
                        }
                    }
                }

                // add image
                image.SaveAs(orginalPath + imageName);
                if (!string.IsNullOrEmpty(thumbPath))
                {
                    image.SaveAs(thumbPath + imageName);
                    ImageResizer img = new ImageResizer();
                    if (width != null && height != null)
                    {
                        img.ResizeImageFromFile((thumbPath + imageName), height.Value, width.Value, false, false);
                    }
                    else
                    {
                        img.ResizeImageFromFile((thumbPath + imageName), 200, 200, false, false);
                    }

                }
            }
        }
    }
}