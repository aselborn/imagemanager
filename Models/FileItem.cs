using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Imagemanager.Models
{
    public class FileItem : NavigationTreeItem
    {
        public override ObservableCollection<NavigationTreeItem> GetMyChildren()
        {
            throw new NotImplementedException();
        }

        public override BitmapSource GetMyIcon()
        {
            throw new NotImplementedException();
        }
    }
}
