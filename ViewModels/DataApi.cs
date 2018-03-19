using Imagemanager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.ViewModels
{
    public class DataApi
    {
        string _path = "";
        public DataApi()
        {

        }

        public DataApi(string fullPath)
        {
            _path = fullPath;
        }

        public string FullPath
        {
            get => _path;

            set
            {
                _path = value;
            }
         }

        public  ObservableCollection<FileItem> FetchFileItems
        {
            get
            {
                ObservableCollection<FileItem> files = new ObservableCollection<FileItem>();
                files.Add(new FileItem { FileName = "test.txt", CreatedAt = DateTime.Now, FileSize = 93939, Path = "C:\\temp\\" });
                return files;
            }
            
        }

        public ObservableCollection<FileItem> FetchDuplicates
        {
            get
            {
                ObservableCollection<FileItem> duplicates = new ObservableCollection<FileItem>();

                return duplicates;
            }
        }


        


        #region depricated
        /*
        public static List<string> GetFolders (string startPath, string searchPattern="*", 
            SearchOption searchOption= SearchOption.TopDirectoryOnly)
        {

            List<string> folders = new List<string>();

            if (searchOption == SearchOption.TopDirectoryOnly)
            {
                folders = Directory.GetDirectories(startPath, searchPattern).ToList();
            }
            else
            {
                folders = new List<string>(GetDirectories(startPath, searchPattern));
                for (int n = 0; n<=folders.Count; n++)
                {
                    folders.AddRange(GetDirectories(folders[n], searchPattern));
                }

            }

            return folders;
        }

        private static List<string> GetDirectories(string path, string searchPattern)
        {
            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }
        */
#endregion
    }
}
