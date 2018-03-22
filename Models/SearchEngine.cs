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
        private List<Duplicate> _duplicates = new List<Duplicate>();
        public SearchEngine(string startPath)
        {
            _startPath = startPath;
        }

        public List<Duplicate> SearchForDuplicates()
        {
            if (!_startPath.Contains("\\"))
                _startPath = _startPath + "\\";
                
            DirectoryInfo[] dirs = new DirectoryInfo(_startPath).GetDirectories("*", SearchOption.AllDirectories);

            SearchFolderForDuplicates(new DirectoryInfo(_startPath));
            foreach (DirectoryInfo d in dirs)
                SearchFolderForDuplicates(d);

            return _duplicates;
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
                        
                        alreadyExists = _filesList.Find(p => p.FileSize == f.Length);

                        if (alreadyExists != null)
                        {
                            if (alreadyExists.MD5CheckSum.CompareTo(new FileItem(f.FullName).MD5CheckSum) == 0)
                            {
                                //We have a duplicate!
                                _duplicates.Add(new Duplicate(alreadyExists.Path));
                                _duplicates.Add(new Duplicate(f.FullName));



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

            catch (Exception ep)
            {
                Console.WriteLine(ep.ToString());
            }

        }

        private void AddFile(string path)
        {
            _filesList.Add(new FileItem(path));
        }

    }
}
