using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class Folder : ViewModelBase
    {
        //private ObservableCollection<DirectoryInfo> subFolders { get; } = new ObservableCollection<DirectoryInfo>();

        private List<string> foldersAsStrings = new List<string>();
        private ObservableCollection<FolderInformation> folderInformations = new ObservableCollection<FolderInformation>();

        public string FolderName { get; set; }

        public Folder(string folderPath)
        {
            foldersAsStrings = DataApi.GetFolders(folderPath);
            
            foreach(string str in foldersAsStrings)
            {
                FolderInformation finfo = new FolderInformation() { FolderName = str, SubFolders = new DirectoryInfo(str) };
                folderInformations.Add(finfo);
            }
            //foreach(string str in foldersAsStrings)
            //{
            //    DirectoryInfo dir = new DirectoryInfo(str);
            //    subFolders.Add(dir);
            //}

            FolderName = folderPath;
        }

        //public ObservableCollection<DirectoryInfo> SubFolders => subFolders;

        public ObservableCollection<FolderInformation> FolderInformations => folderInformations;


    }
}
