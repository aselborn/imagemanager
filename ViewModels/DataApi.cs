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

        private static ObservableCollection<Folder> MyObserv(List<string> list)
        {
            ObservableCollection<Folder> result = new ObservableCollection<Folder>();
            foreach (string dir in list)
            {
                result.Add(new Folder(dir));
            }
            return result;
        }
    }
}
