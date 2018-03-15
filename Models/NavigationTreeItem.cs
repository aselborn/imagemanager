using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Imagemanager.Models
{
    /*
     * Abstrakt basklass
     */
    public abstract class NavigationTreeItem : ViewModelBase
    {
        public string FriendlyName { get; set; }
        protected BitmapSource _myIcon;
        public BitmapSource MyIcon
        {
            get => _myIcon ?? (_myIcon = GetMyIcon());
        }

        public abstract BitmapSource GetMyIcon();

        public string FullPathName { get; set; }

        private ObservableCollection<NavigationTreeItem> _children;
        public ObservableCollection<NavigationTreeItem> Children
        {
            get => _children ?? (_children = GetMyChildren());
        }

        public abstract ObservableCollection<NavigationTreeItem> GetMyChildren();

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                NotifyPropertyChanged(nameof(IsExpanded));
            }
        }
        public bool IncludeFileChildren { get; set; }
        public void DeleteChildren()
        {
            if (_children != null)
            {
                for (int i = _children.Count -1; i>=0; i--)
                {
                    _children[i].DeleteChildren();
                    _children[i] = null;
                    _children.RemoveAt(i);
                }
            }
        }
    }
}
