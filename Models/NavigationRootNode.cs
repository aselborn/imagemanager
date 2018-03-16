using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Imagemanager.Models
{
    public class NavigationRootNode : NavigationTreeItem
    {
        public override ObservableCollection<INavigationTreeItem> GetMyChildren()
        {
            return new ObservableCollection<INavigationTreeItem> { };
        }

        public override BitmapSource GetMyIcon()
        {
            return _myIcon = null;
        }
    }
}
