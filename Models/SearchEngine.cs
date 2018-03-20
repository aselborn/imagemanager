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
        private Duplicate _duplicate;
        public SearchEngine(string startPath)
        {
            _startPath = startPath;
        }

        public void SearchForDuplicates()
        {
            DirectoryInfo[] dirs = new DirectoryInfo(_startPath).GetDirectories("*", SearchOption.AllDirectories);

            SearchFolderForDuplicates(new DirectoryInfo(_startPath));

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
                    if (_filesList.Count != 0)
                    {
                        FileItem alreadyExists = null;
                        //alreadyExists = _filesList.FirstOrDefault(p => (p.FileName == f.Name && p.FileSize == f.Length));

                        alreadyExists = _filesList.Find(p => p.FileSize == f.Length);

                        if (alreadyExists != null)
                        {
                            if (alreadyExists.MD5CheckSum.CompareTo(new FileItem(f.FullName).MD5CheckSum) == 0)
                            {
                                //We have a duplicate!
                                if (_duplicate == null)
                                {
                                    _duplicate = new Duplicate(new FileItem(f.FullName), alreadyExists);
                                }
                               
                            }
                        }
                        else
                        {
                            AddFile(f.FullName);
                        }

                    }

                    else
                    {
                        AddFile(f.FullName);
                    }
                }
            }

            catch { }

        }

        private void AddFile(string path)
        {
            _filesList.Add(new FileItem(path)
            {
                FileInformation = new FileInfo(path)
            });
        }

    }
}
