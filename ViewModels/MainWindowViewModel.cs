using Imagemanager.Lib;
using Imagemanager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Imagemanager.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private DataApi _dataApi;
        private SearchEngine mySearchEngine;

        public NavigationTree SingleTree { get; set; }
        
        public ObservableCollection<FileItem> Files { get; } = new ObservableCollection<FileItem>();
        private string _progresStatusText = "";
        private string _duplcateCount = "";

        public Boolean IsAllowed = false;
        public Boolean CanClickTree = true;
        //public Boolean CanPerformSearch = false;
        private string _startPath;
        public string SelectedColumns { get; set; }

        public List<ColumnNames> FileColumns { get; } = ColumnNames.GetColumnNames();
        public MainWindowViewModel()
        {

            Messenger.Register<ColumnNames>(this, p =>
            {
                SelectedColumns = string.Join(",", FileColumns.Where(c => c.IsSelected).Select(c => c.Name));
            });
            

            NotifyPropertyChanged(nameof(FileColumns));

            SingleTree = new NavigationTree();
        }

        private void timerTest()
        {
            var statusTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            statusTimer.Tick += OnTimerTick;
            statusTimer.Start();

        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            DuplicateCount = "Time is now: " + DateTime.Now.ToLongTimeString();
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
        public ICommand OnSelectedPathClick => new RelayCommand(x => OnTreeviewSelected(x), x => CanClickTree);
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

        public string DuplicateCount
        {
            get => _duplcateCount;
            set
            {
                _duplcateCount = value;
                NotifyPropertyChanged(nameof(DuplicateCount));
            }
        }

        private void OnBeginPerformSearch()
        {

            StartPath = SelectedPath;

            mySearchEngine = new SearchEngine(SelectedPath);
            mySearchEngine.OnReportProgressEvent += ReportFoundFiles;

            _dataApi = new DataApi(mySearchEngine);

            Files.Clear();

            _dataApi.FullPath = SelectedPath;
            _dataApi.FetchFileItems.ToList().ForEach(Files.Add);
            ProgresStatusText = "Found " + Files.Count.ToString() + " duplicate files.";
        }

        private void ReportFoundFiles(long hitCount)
        {
            DuplicateCount = String.Format("Found {0}, item(s)", hitCount.ToString());
        }

        private void OnTreeviewSelected(object x)
        {
            SelectedPath = x.ToString();
            IsAllowed = true;
          

        }

      
    }
}
