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
        private SearchEngine _searchEngine;

      
        /*
        public DataApi(string fullPath)
        {
            _path = fullPath;
        }
        */
        public DataApi(SearchEngine mySearchEngine)
        {
            _searchEngine = mySearchEngine;
            FullPath = _searchEngine.GetStartPath;
        }
        public string FullPath
        {
            get => _path;

            set
            {
                _path = value;
            }
        }

        public ObservableCollection<FileItem> FetchFileItems
        {
            get
            {
                ObservableCollection<FileItem> files = new ObservableCollection<FileItem>();

                var TaskResult = Task.Factory.StartNew(() => GetList()).Result;
                TaskResult.Result.ForEach(files.Add);

                return files;
            }

        }

        

        private List<Duplicate> SearchResultList()
        {
            SearchEngine searchEngine = new SearchEngine(FullPath);
            return searchEngine.SearchForDuplicates();
        }

        private async void PerformSearch2()
        {
            SearchEngine searchEngine = new SearchEngine(FullPath);
            await Task.Run(() =>
           {
               searchEngine.SearchForDuplicates();
           });
        }

        private async Task PerformSearch()
        {
            Func<List<Duplicate>> function = new Func<List<Duplicate>>(() => SearchResultList());
            List<Duplicate> dpl = await Task.Factory.StartNew<List<Duplicate>>(function);

        }


        public async Task<List<Duplicate>> GetList()
        {
            //SearchEngine searchEngine = new SearchEngine(FullPath);            
            //return await Task.FromResult<List<Duplicate>>(searchEngine.SearchForDuplicates());
            return await Task.FromResult<List<Duplicate>>(_searchEngine.SearchForDuplicates());
        }

        private string EventOnHitCount(long hitCount)
        {
            return String.Format("Finding, {0}", hitCount);
        }

        private void reportFinnished(Task<List<Duplicate>> obj)
        {
            string s = ";";
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
