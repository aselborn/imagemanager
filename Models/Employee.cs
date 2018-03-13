using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class Employee : ViewModelBase
    {

        public Employee(string employeeName)
        {
            EmployeeName = employeeName;
        }

        private string _employeeName;
        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                _employeeName = value;
                NotifyPropertyChanged(nameof(EmployeeName));
            }
        }
    }
}
