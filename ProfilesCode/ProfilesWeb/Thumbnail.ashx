<%@ WebHandler Language="C#" Class="Thumbnail" %>

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.Common;

public class Thumbnail : IHttpHandler 
{
    static byte[] silhouetteImage = null;
    
    public void ProcessRequest (HttpContext context) 
    {
        // Set up the response settings
        context.Response.ContentType = "image/jpeg";
        context.Response.Cache.SetCacheability(HttpCacheability.Public);
        context.Response.BufferOutput = false;
        
        if (!string.IsNullOrEmpty(context.Request.QueryString["ID"]))
        {
            // get the id for the image
            int id = Convert.ToInt32(context.Request.QueryString["ID"]);
            
            // By Eric Meeks
            byte[] imageAsBytes = null;
            if ("True".Equals(context.Request.QueryString["ShowSilhouetteAsDefault"]))
            {
                // if user does not have image visibility set on, return silhouette
                UserPreferences userPreference = new UserPreferences();
                userPreference = new UserBL().GetUserPreferences(id);
                //IF "Y" then Show 
                //IF "N" then Hide

                if (!userPreference.Photo.Equals("Y"))
                {
                    // It's OK that this isn't synchronized even though it would be cleaner if it were
                    if (silhouetteImage == null)
                    {
                        // this method is limited to 2^32 byte files (4.2 GB)
                        FileStream fs = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "/template_files/default_img.png");
                        try
                        {
                            silhouetteImage = new byte[fs.Length];
                            fs.Read(silhouetteImage, 0, Convert.ToInt32(fs.Length));
                        }
                        finally
                        {
                            fs.Close();
                        }
                    }
                    imageAsBytes = silhouetteImage;
                }
            }
                
            if (imageAsBytes == null)                 
            {
                // get the image as a byte array
                imageAsBytes = new UserBL().GetUserPhoto(id);
            }

            // added by Eric Meeks
            context.Response.AddHeader("Content-Length", imageAsBytes.Length.ToString());
            
            // resize the image to a thumb (100)
            //imageAsBytes = ResizeImageFile(imageAsBytes, 100);
            if (imageAsBytes != null)
            {
                // put the byte array into a stream
                Stream stream = new MemoryStream((byte[])imageAsBytes);

                // setup the chunking of the image data (good for large images)
                int buffersize = 1024 * 16;
                byte[] buffer = new byte[buffersize];

                // push the bytes to the output stream in chunks
                int count = stream.Read(buffer, 0, buffersize);
                while (count > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, count);
                    count = stream.Read(buffer, 0, buffersize);
                }
            }
        }
    }
 
    public bool IsReusable 
    {
        get { return true; }
    }

    /// <summary>
    /// Resizes an image
    /// </summary>
    /// <param name="imageFile">the byte array of the file</param>
    /// <param name="targetSize">the target size of the file (may affect width or height) 
    /// depends on orientation of file (landscape or portrait)</param>
    /// <returns>Byte array containing the resized file</returns>
    private static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
    {
        using (System.Drawing.Image oldImage =
			System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
        {
            Size newSize = CalculateDimensions(oldImage.Size, targetSize);

            using (Bitmap newImage =
				new Bitmap(newSize.Width,
					newSize.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics canvas = Graphics.FromImage(newImage))
                {
                    canvas.SmoothingMode = SmoothingMode.AntiAlias;
                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    canvas.DrawImage(oldImage,
						new Rectangle(new Point(0, 0), newSize));

                    MemoryStream m = new MemoryStream();
                    newImage.Save(m, ImageFormat.Jpeg);
                    return m.GetBuffer();
                }
            }
        }
    }

    /// <summary>
    /// Calculates the new size of the image based on the target size
    /// </summary>
    /// <param name="oldSize">Is the size of the original file</param>
    /// <param name="targetSize">Is the target size of the resized file</param>
    /// <returns>The new size</returns>
    private static Size CalculateDimensions(Size oldSize, int targetSize)
    {
        Size newSize = new Size();
        if (oldSize.Height > oldSize.Width)
        {
            newSize.Width =
				(int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
            newSize.Height = targetSize;
        }
        else
        {
            newSize.Width = targetSize;
            newSize.Height =
				(int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
        }
        return newSize;
    }
}