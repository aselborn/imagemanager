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
        private string _progresStatusText = "";

        public Boolean IsAllowed = true;
        //public Boolean CanPerformSearch = false;
        private string _startPath;
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
        public ICommand OnSelectedPathClick => new RelayCommand(x => OnTreeviewSelected(x), x => IsAllowed);
        public ICommand PerformSearch => new RelayCommand(p => OnBeginPerformSearch(), p => IsAllowed);

        public string StartPath
        {
            get => _startPath;
            set
            {
                _startPath = "Search: " + value;
                NotifyPropertyChanged(nameof(StartPath));
            }
        }

        public string ProgresStatusText
        {
            get => _progresStatusText;
            set
            {
                _progresStatusText = value;
                NotifyPropertyChanged(nameof(ProgresStatusText));
            }
        }

        private void OnBeginPerformSearch()
        {

            StartPath = SelectedPath;
            Files.Clear();

            _dataApi.FullPath = SelectedPath;
            _dataApi.FetchFileItems.ToList().ForEach(Files.Add);
            ProgresStatusText = "Found " + Files.Count.ToString() + " duplicate files.";
        }

        private void OnTreeviewSelected(object x)
        {
            SelectedPath = x.ToString();
            IsAllowed = true;
          

        }

      
    }
}
