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
    class NavigationDriveNoChildRootItem : NavigationTreeItem
    {
        public NavigationDriveNoChildRootItem()
        {
            FriendlyName = "DrivesRoot";
            IsExpanded = true;
            FullPathName = "$xxDriveRoot$";
        }

        public override ObservableCollection<INavigationTreeItem> GetMyChildren()
        {
            ObservableCollection<INavigationTreeItem> childrenList = new ObservableCollection<INavigationTreeItem>();
            INavigationTreeItem treeItem;
            string fn = "";
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
                if (drive.IsReady)
                {
                    treeItem = new NavigationDriveNoChildItem();

                    // Some processing for the FriendlyName
                    fn = drive.Name.Replace(@"\", "");
                    treeItem.FullPathName = fn;
                    if (drive.VolumeLabel == string.Empty)
                    {
                        fn = drive.DriveType.ToString() + " (" + fn + ")";
                    }
                    else if (drive.DriveType == DriveType.CDRom)
                    {
                        fn = drive.DriveType.ToString() + " " + drive.VolumeLabel + " (" + fn + ")";
                    }
                    else
                    {
                        fn = drive.VolumeLabel + " (" + fn + ")";
                    }

                    treeItem.FriendlyName = fn;
                    treeItem.IncludeFileChildren = this.IncludeFileChildren;
                    childrenList.Add(treeItem);
                }

            return childrenList;
        }

        public override BitmapSource GetMyIcon()
        {
            string Param = "pack://application:,,,/" + "MyImages/bullet_blue.png";
            Uri uri1 = new Uri(Param, UriKind.RelativeOrAbsolute);
            return _myIcon= BitmapFrame.Create(uri1);
        }
    }
    
}
