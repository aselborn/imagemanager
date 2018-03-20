using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class SearchEngine
    {
        string _startPath = "";
        private List<FileItem> _filesList = new List<FileItem>();
        public SearchEngine(string startPath)
        {
            _startPath = startPath;
        }

        public void SearchForDuplicates()
        {
            DirectoryInfo[] dirs = new DirectoryInfo(_startPath).GetDirectories("*", SearchOption.AllDirectories);

            foreach (DirectoryInfo d in dirs)
                SearchFolderForDuplicates(d);

        }


        private void SearchFolderForDuplicates(DirectoryInfo dirInf)
        {
            try
            {
                FileInfo[] finfo = dirInf.GetFiles();


                foreach (FileInfo f in finfo)
                {
                    //om filnamnet redan finns i listan...
                    if (_filesList.Count != 0)
                    {
                        FileItem alreadyExists = null;
                        alreadyExists = _filesList.FirstOrDefault(p => (p.FileName == f.Name && p.FileSize == f.Length));
                    }

                    else
                    {
                        _filesList.Add(new FileItem(f.FullName));
                    }
                }
            }

            catch { }

        }

    }
}
