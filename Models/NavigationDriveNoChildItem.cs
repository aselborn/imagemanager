using Imagemanager.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Imagemanager.Models
{
    public class NavigationDriveNoChildItem : NavigationTreeItem
    {
        public NavigationDriveNoChildItem()
        {

        }
        public override ObservableCollection<INavigationTreeItem> GetMyChildren()
        {
            ObservableCollection<INavigationTreeItem> childrenList = new ObservableCollection<INavigationTreeItem>();
            return childrenList;
        }

        public override BitmapSource GetMyIcon()
        {
            return _myIcon = ImageCache.GetIconForFile(FullPathName);
        }
    }
}
