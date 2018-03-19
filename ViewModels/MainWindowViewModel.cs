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

        private DataApi _dataApi = new DataApi();

        public NavigationTree SingleTree { get; set; }
        
        public ObservableCollection<FileItem> Files { get; } = new ObservableCollection<FileItem>();

        public Boolean IsAllowed = false;
        public Boolean CanBrowse = true;

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
        public ICommand OnSelectedPathClick => new RelayCommand(x => OnTreeviewSelected(x), x => CanBrowse);
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
            _dataApi.FullPath = fullPath;
            _dataApi.FetchFileItems.ToList().ForEach(Files.Add);
        }
    }
}
