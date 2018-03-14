using Imagemanager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<Department> departments;
        private List<Folder> computerFolders;

        //public ObservableCollection<Folder> ComputerDirectories { get; } = new ObservableCollection<Folder>();
        

        public MainWindowViewModel()
        {
            
            Departments = new List<Department>()
            {
                new Department("DotNet"),
                new Department("PHP")
            };


            ComputerFolders = new List<Folder>()
            {
                new Folder(@"C:\"),
                new Folder(@"D:\")
            };

            //ComputerDirectories = DataApi.GetFolders(@"c:\");
            
        }

        public List<string> RootFolder
        {
            get => new FolderRoot().RootFolderName;
        }

        public List<Department> Departments
        {
            get
            {
                return departments;
            }
            set
            {
                departments = value;
                NotifyPropertyChanged(nameof(Departments));
            }
        }

        public List<Folder> ComputerFolders
        {
            get => computerFolders;
            set
            {
                computerFolders = value;
                NotifyPropertyChanged(nameof(ComputerFolders));
            }
        }
    }
}
