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
        private FileInfo _fileInfo;
        public FileItem() { }
        
        public FileItem(string path)
        {
            Path = path;
            FileInformation = new FileInfo(path);
            FileName = FileInformation.Name;
            FileSize = FileInformation.Length;
            CreatedAt = FileInformation.LastWriteTime;
            MD5CheckSum = FileInformation.FullName;

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
            get
            {
                if (_md5CheckSum == null)
                {
                    return CreateCheckSum();
                }
                return _md5CheckSum;
            }
            set
            {
                CreateCheckSum();
                NotifyPropertyChanged(nameof(MD5CheckSum));
            }
        }

        public FileInfo FileInformation
        {
            get => _fileInfo;
            set
            {
                _fileInfo = new FileInfo(Path);
                FileSize = _fileInfo.Length;
                NotifyPropertyChanged(nameof(FileInformation));
            }
        }

        private string CreateCheckSum()
        {
            
            using (var md5 = MD5.Create())
            {
                
                using (var stream = File.OpenRead(Path))
                {
                    var hash = md5.ComputeHash(stream);
                    _md5CheckSum =  BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return _md5CheckSum;
        }
    }
}
