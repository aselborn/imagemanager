using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class FolderRoot : ViewModelBase
    {
        private List<string> _rootFolderName = new List<string> { @"c:\"};
        public List<string> RootFolderName
        {
            get => _rootFolderName;
            set
            {
                _rootFolderName = value;
                NotifyPropertyChanged(nameof(RootFolderName));
            }
        }
        
    }
}
