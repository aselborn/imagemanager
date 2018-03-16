using Imagemanager.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static System.Environment;

namespace Imagemanager.Models
{
    public class NavigationSpecialFolderRootItem : NavigationTreeItem
    {
        public NavigationSpecialFolderRootItem()
        {
            FriendlyName = "SpecialRootFolder";
            FullPathName = "$xxSpecialRootFolder$";
        }

        public override ObservableCollection<INavigationTreeItem> GetMyChildren()
        {
            ObservableCollection<INavigationTreeItem> childrenList = new ObservableCollection<INavigationTreeItem>();

            NavigationTreeItem item;

            var specialFoldersArray = Enum.GetValues(typeof(SpecialFolder));

            foreach (SpecialFolder spec in specialFoldersArray)
            {
                if (Environment.GetFolderPath(spec) != string.Empty)
                {
                    item = new NavigationFolderItem();

                    item.FriendlyName = spec.ToString();
                    item.FullPathName = GetFolderPath(spec);
                    item.IncludeFileChildren = true;

                    childrenList.Add(item);
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
