using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising
{
    static class filImage
    {
        public static Byte[] ImageToByte(System.Drawing.Image Img)
        {
            System.Drawing.ImageConverter d = new System.Drawing.ImageConverter();
            Byte[] bta;
            bta = (Byte[])(d.ConvertTo(Img, typeof(Byte[])));
            return bta;
        }

        public static System.Drawing.Image ImageFromByte(object bta)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream((Byte[])(bta));
                return System.Drawing.Image.FromStream(ms);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Byte[] FileToByte(string filename)
        {
            if (filename == "")
            {
                return null;
            }
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] ImageData = new byte[fs.Length];
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return ImageData;
        }

        public static void FileFromByte(Byte[] Files, string savepath)
        {
            String LPath = savepath;
            System.IO.FileStream fs = new System.IO.FileStream(LPath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.Write);
            fs.Write(Files, 0, Files.Length);
            fs.Flush();
            fs.Close();
        }
    }
}
