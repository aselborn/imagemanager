using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class FileItem : ViewModelBase
    {
        private string _fileName;
        private string _path;
        private long _size;
        private DateTime _createdAt;
        private string _md5CheckSum;
        public FileItem() { }
        
        public FileItem(string path)
        {
            Path = path;
        }
        

        public String FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                NotifyPropertyChanged(nameof(FileName));
            }
        }

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                NotifyPropertyChanged(nameof(Path));
            }
        }

        public long FileSize
        {
            get => _size;
            set
            {
                _size = value;
                NotifyPropertyChanged(nameof(FileSize));
            }
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            set
            {
                _createdAt = value;
                NotifyPropertyChanged(nameof(CreatedAt));
            }
        }

        public string MD5CheckSum
        {
            get => _md5CheckSum;
            set
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(FileName))
                    {
                        _md5CheckSum = Encoding.Default.GetString(md5.ComputeHash(stream));
                    }
                }
            }
        }
    }
}
