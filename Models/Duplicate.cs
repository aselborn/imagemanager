using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    class Duplicate
    {

        private List<FileItem> _duplicates;
        public List<FileItem> Duplicates => _duplicates;

        public Duplicate(FileItem item, FileItem copy)
        {
            if (_duplicates == null) _duplicates = new List<FileItem>();


            if (_duplicates.Find(p => p.MD5CheckSum == item.MD5CheckSum) == null)
                _duplicates.Add(item);


            _duplicates.Add(copy);


        }






    }
}
