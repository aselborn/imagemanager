using Imagemanager.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Imagemanager.Models
{
    public class NavigationFolderItem : NavigationTreeItem
    {

        public override ObservableCollection<INavigationTreeItem> GetMyChildren()
        {

            ObservableCollection<INavigationTreeItem> childrenList = new ObservableCollection<INavigationTreeItem>();
            INavigationTreeItem item;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(FullPathName);
                if (dirInfo.Exists) return childrenList;
                foreach (DirectoryInfo di in dirInfo.GetDirectories())
                {
                    item = new NavigationFolderItem();
                    item.FullPathName = FullPathName + "\\" + dirInfo.Name;
                    item.FriendlyName = dirInfo.Name;
                    item.IncludeFileChildren = IncludeFileChildren;
                    childrenList.Add(item);
                }

                if (IncludeFileChildren)
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        NavigationTreeItem fileItem = new NavigationFileItem();
                        fileItem.FriendlyName = file.Name;
                        fileItem.FullPathName = file.FullName;
                        fileItem.IncludeFileChildren = IncludeFileChildren;
                        childrenList.Add(fileItem);
                    }

            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.ToString());
            }
            
            return childrenList;
        }

        public override BitmapSource GetMyIcon()
        {
            return _myIcon = ImageCache.GetIconForFile(FullPathName);
        }
    }

}
