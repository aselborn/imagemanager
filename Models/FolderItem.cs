using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class FolderItem : NavigationTreeItem
    {

        public override ObservableCollection<NavigationTreeItem> GetMyChildren()
        {

            ObservableCollection<NavigationTreeItem> childrenList = new ObservableCollection<NavigationTreeItem>();

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(FullPathName);
                if (dirInfo.Exists) return childrenList;
                foreach (DirectoryInfo di in dirInfo.GetDirectories())
                {
                    NavigationTreeItem item = new FolderItem();
                    item.FullPathName = FullPathName + "\\" + dirInfo.Name;
                    item.FriendlyName = dirInfo.Name;
                    item.IncludeFileChildren = IncludeFileChildren;
                    childrenList.Add(item);
                }

                if (IncludeFileChildren)
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        NavigationTreeItem fileItem = new FileItem();
                    }

            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.ToString());
            }
            {

            }

            return childrenList;
        }

        public override BitmapSource GetMyIcon()
        {
            throw new NotImplementedException();
        }
    }

}
