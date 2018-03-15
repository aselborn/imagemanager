using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Imagemanager.Lib
{
    public static class ImageCache
    {
        public static Dictionary<string, BitmapSource> ImageList = new Dictionary<string, BitmapSource>();
        public static BitmapSource GetImage(string path)
        {
            string ext = Path.GetExtension(path).ToLower();

            if (ImageList.ContainsKey(ext))
            {
                return ImageList[ext];
            }
            BitmapSource myIcon = GetIconForFile(path);

            if ((ext != "") && (ext != ".exe") && (ext != ".lnk") && (ext != ".ico"))
            {
                ImageList.Add(ext, myIcon);
            }
            return myIcon;
        }

        public static BitmapSource GetIconForFile(string filename)
        {
            BitmapSource resultIcon = null;
         
            //var driveInfo = DriveInfo.GetDrives().First(p => p.Name == filename);
            //bool valid = DriveInfo.GetDrives().First(p => p.Name == filename).IsReady;

            if (File.Exists(filename) || Directory.Exists(filename) )
            {
                using (Icon windowsIcon = ShellIcon.GetLargeIcon(filename))
                {
                    try
                    {
                        resultIcon = Imaging.CreateBitmapSourceFromHIcon(
                             windowsIcon.Handle,
                             Int32Rect.Empty,
                             BitmapSizeOptions.FromWidthAndHeight(34, 34));
                    }
                    catch (Exception e)
                    {
                        resultIcon = null;
                    }
                }
            }

            return resultIcon;
        }
    }
}
