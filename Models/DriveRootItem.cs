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
    public class DriveRootItem : NavigationTreeItem
    {
        public DriveRootItem()
        {
            FriendlyName = "DriveRoot";
            IsExpanded = true;
            FullPathName = "$$xxDriveRoot$";
        }
        public override ObservableCollection<NavigationTreeItem> GetMyChildren()
        {
            ObservableCollection<NavigationTreeItem> childrenList = new ObservableCollection<NavigationTreeItem>();
            //INavigationTreeItem item1;

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady)
                {
                    NavigationTreeItem item = new DriveRootItem();
                    NavigationTreeItem sss = new FolderItem();

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
            throw new NotImplementedException();
        }
    }
}