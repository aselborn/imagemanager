using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public FileItem()
        {

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
    }
}
