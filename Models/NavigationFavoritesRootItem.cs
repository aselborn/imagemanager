using Imagemanager.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static System.Environment;

namespace Imagemanager.Models
{
    public class NavigationFavoritesRootItem : NavigationTreeItem
    {
        public NavigationFavoritesRootItem()
        {
            FriendlyName = "Favorites";
            FullPathName = "$xxFavoritesRoot$";
            IsExpanded = true;
        }
        public override ObservableCollection<INavigationTreeItem> GetMyChildren()
        {
            ObservableCollection<INavigationTreeItem> childrenList = new ObservableCollection<INavigationTreeItem>();

            INavigationTreeItem item;

            string fn = GetFolderPath(SpecialFolder.UserProfile);
            fn = fn + "\\Links";

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(fn);
                if (!dirInfo.Exists)
                    return childrenList;

                string fileResolvedShortCut = "";

                foreach(FileInfo finfo in dirInfo.GetFiles())
                {
                    if (finfo.Name.ToUpper().EndsWith(".LNK"))
                    {
                        fileResolvedShortCut = FolderUtil.ResolveShortCut(finfo.FullName);
                        if (!String.IsNullOrEmpty(fileResolvedShortCut))
                        {
                            FileInfo fileInfo = new FileInfo(fileResolvedShortCut);

                            item = new NavigationFileItem();
                            item.FriendlyName = fileInfo.Name != string.Empty ? fileInfo.Name : fileInfo.ToString();
                            item.FullPathName = fileInfo.FullName;

                            childrenList.Add(item);

                        }
                    }
                }

            }


            catch { }

            return childrenList;
        }

        public override BitmapSource GetMyIcon()
        {
            return _myIcon = ImageCache.GetIconForFile(FullPathName);
        }
    }
}
