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
    public static class NavigationUtil
    {
        public const string LastPartRootItemName = "DriveRootItem";
        
        public static NavigationTreeItem GetRootItem(int rootNo, bool includeChildren = false)
        {
            Type selectedType = typeof(NavigationDriveRootItem);
            string selectedName = "Drive";

            var entitypes =
                from t in System.Reflection.Assembly.GetAssembly(typeof(NavigationTreeItem)).GetTypes()
                where
                t.IsSubclassOf(typeof(NavigationTreeItem))
                select t;

            int n = 0;
            foreach (var item in entitypes)
            {
                if (item.Name.EndsWith(LastPartRootItemName))
                {
                    if (n == rootNo)
                    {
                        selectedType = Type.GetType(item.FullName);
                        selectedName = item.Name.Replace(LastPartRootItemName, "");
                        break;
                    }
                    n++;
                }
            }

            NavigationTreeItem rootItem = (NavigationTreeItem)Activator.CreateInstance(selectedType);
            rootItem.FriendlyName = selectedName;
            rootItem.IncludeFileChildren = includeChildren;

            return rootItem;
        }

        public static string TrimDriveLetter(DriveInfo drive)
        {
            return drive.Name.Replace(@"\", string.Empty);
        }
    }
}

