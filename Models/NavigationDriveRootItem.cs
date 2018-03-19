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
    public class NavigationDriveRootItem : NavigationTreeItem
    {
        public NavigationDriveRootItem()
        {
            FriendlyName = "DriveRoot";
            IsExpanded = true;
            FullPathName = "$$xxDriveRoot$";
        }
        public override ObservableCollection<INavigationTreeItem> GetMyChildren()
        {
            ObservableCollection<INavigationTreeItem> childrenList = new ObservableCollection<INavigationTreeItem>();
            INavigationTreeItem item;

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady)
                {
                    item = new NavigationDriveItem();

                    item.FullPathName = NavigationUtil.TrimDriveLetter(drive);

                    if (drive.VolumeLabel == string.Empty)
                    {
                        item.FriendlyName = drive.VolumeLabel + " (" + NavigationUtil.TrimDriveLetter(drive) + ")";
                    }
                    else if (drive.DriveType == DriveType.CDRom)
                    {
                        item.FriendlyName = drive.DriveType.ToString() + " " + drive.VolumeLabel + " (" + NavigationUtil.TrimDriveLetter(drive) + ")";
                    }
                    else
                    {
                        item.FriendlyName = drive.VolumeLabel + " (" + NavigationUtil.TrimDriveLetter(drive) + ")";
                    }

                    item.IncludeFileChildren = IncludeFileChildren;
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