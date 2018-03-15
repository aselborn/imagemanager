using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Imagemanager.Models
{
    public interface INavigationTreeItem : INotifyPropertyChanged
    {
        string FriendlyName { get; set; }
        BitmapSource MyIcon { get; set; }
        string FullPathName { get; set; }
        ObservableCollection<INavigationTreeItem> Children { get; }

        bool IsExpanded { get; set; }

        bool IncludeFileChildren { get; set; }

        void DeleteChildren();
    }
}
