using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class Position : ViewModelBase
    {
        private List<Employee> employees;

        public Position(string positionname)
        {
            PositionName = positionname;
            employees = new List<Employee>()
                {
                    new Employee("Employee1"),
                    new Employee("Employee2"),
                    new Employee("Employee3")
                };
        }

        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                NotifyPropertyChanged(nameof(Employees));
            }
        }

        public string PositionName
        {
            get;
            set;
        }
    }
}
