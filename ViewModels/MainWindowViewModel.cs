using Imagemanager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Imagemanager.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public NavigationTree SingleTree { get; set; }

        public ObservableCollection<FileItem> Files { get; set; } = new ObservableCollection<FileItem>();

        private Boolean IsAllowed = false;
        private Boolean IsBrowse = true;

        public MainWindowViewModel()
        {
            SingleTree = new NavigationTree();
        }

        private String _selectedPath;
        public string SelectedPath
        {
            get => _selectedPath;
            set
            {
                _selectedPath = value;
                NotifyPropertyChanged(nameof(SelectedPath));
            }
        }
        public ICommand OnSelectedPathClick => new RelayCommand(x => OnTreeviewSelected(x), x => IsBrowse);
        public ICommand PerformSearch => new RelayCommand(p => OnBeginPerformSearch(), p => IsAllowed);

        private void OnBeginPerformSearch()
        {
            
        }

        private void OnTreeviewSelected(object x)
        {
            SelectedPath = x.ToString();
            IsAllowed = true;
            ListFilesInThisDirectory(x.ToString());

        }

        private void ListFilesInThisDirectory(string fullPath)
        {
            Files = DataApi.FetchFileItems(fullPath);
        }
    }
}
