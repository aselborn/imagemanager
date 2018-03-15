using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class NavigationTree : ViewModelBase
    {
        private int _rootNr;

        public int RootNr
        {
            get => _rootNr;
            set
            {
                _rootNr = value;
                NotifyPropertyChanged(nameof(RootNr));
            }
        }


        private string _treeName;

        public string TreeName
        {
            get => _treeName;
            set
            {
                _treeName = value;
                NotifyPropertyChanged(nameof(TreeName));
            }
        }

        private ObservableCollection<NavigationTreeItem> _rootChildren = new ObservableCollection<NavigationTreeItem>();
        public ObservableCollection<NavigationTreeItem> RootChildren
        {
            get => _rootChildren;
            set
            {
                _rootChildren = value;
                NotifyPropertyChanged(nameof(RootChildren));
            }
        }
        
        public NavigationTree(int pRootNumber = 0, bool pincludeFileChildren = false)
        {
            RootNr = pRootNumber;
            NavigationTreeItem navigationTreeItem = NavigationUtil.GetRootItem(pRootNumber, pincludeFileChildren);

            TreeName = navigationTreeItem.FriendlyName;

            foreach(NavigationTreeItem item in RootChildren)
            {
                item.DeleteChildren();
            }
            RootChildren.Clear();

            foreach(NavigationTreeItem item in navigationTreeItem.Children)
            {
                RootChildren.Add(item);
            }


        }

        public NavigationTree(int rootNr) : this(rootNr, false) { }
        public NavigationTree() : this(0) { }
    }
}
