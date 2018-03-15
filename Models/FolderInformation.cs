using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class FolderInformation : ViewModelBase
    {

        private string _folderName;
        public string FolderName
        {
            get => _folderName;
            set
            {
                _folderName = value;
                NotifyPropertyChanged(nameof(FolderName));
            }
        }

        private string _shortName;
        public string ShortName
        {
            get => _shortName;
            set
            {
                _shortName = value;
                NotifyPropertyChanged(nameof(ShortName));
            }
        }

        private DirectoryInfo _subFolders;
        public DirectoryInfo SubFolders
        {
            get => _subFolders;
            set
            {
                _subFolders = value;
                ShortName = value.Name;
                NotifyPropertyChanged(nameof(SubFolders));
            }
        }
    }
}
