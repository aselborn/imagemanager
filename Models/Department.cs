using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class Department : ViewModelBase
    {
        private List<Position> positions;

        public Department(string depname)
        {
            DepartmentName = depname;
            positions = new List<Position>()
                {
                    new Position("TL"),
                    new Position("PM")
                };
        }
        public List<Position> Positions
        {
            get
            {
                return positions;
            }
            set
            {
                positions = value;
                NotifyPropertyChanged(nameof(Positions));
            }
        }
        public string DepartmentName
        {
            get;
            set;
        }
    }
}
