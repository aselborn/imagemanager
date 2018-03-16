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
    public class NavigationDriveItem : NavigationTreeItem
    {
        public override ObservableCollection<INavigationTreeItem> GetMyChildren()
        {
            ObservableCollection<INavigationTreeItem> childrenList = new ObservableCollection<INavigationTreeItem>();
            INavigationTreeItem item1;

            DriveInfo drive = new DriveInfo(this.FullPathName);
            if (!drive.IsReady) return childrenList;

            DirectoryInfo di = new DirectoryInfo(((DriveInfo)drive).RootDirectory.Name);
            if (!di.Exists) return childrenList;

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                item1 = new NavigationFolderItem();
                item1.FullPathName = FullPathName + "\\" + dir.Name;
                item1.FriendlyName = dir.Name;
                item1.IncludeFileChildren = this.IncludeFileChildren;
                childrenList.Add(item1);
            }

            if (this.IncludeFileChildren)
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    item1 = new NavigationFileItem();
                    item1.FullPathName = FullPathName + "\\" + file.Name;
                    item1.FriendlyName = file.Name;
                    childrenList.Add(item1);
                }
            }
            return childrenList;
        }

        public override BitmapSource GetMyIcon()
        {
            return _myIcon = ImageCache.GetIconForFile(FullPathName);
        }
    }
}
