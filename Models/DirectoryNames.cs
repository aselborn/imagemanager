using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class DirectoryNames : ViewModelBase
    {
        

        private ObservableCollection<Folder> _folders;
        public ObservableCollection<Folder> FolderNames
        {
            get => _folders;
            set
            {
                _folders = value;
                NotifyPropertyChanged(nameof(FolderNames));
            }
        }

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

     
    }



}
