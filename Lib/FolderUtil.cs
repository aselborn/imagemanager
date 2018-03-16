using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Lib
{
    public static class FolderUtil
    {
        public static string ResolveShortCut(string path)
        {
            if (IsLink(path))
            {
                return "";
            }
            return "";
        }

        public static bool IsLink(string path)
        {
            return Path.GetExtension(path).ToLower().CompareTo(".lnk") == 0 ? true : false;
        }
    }
}
