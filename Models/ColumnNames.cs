using Imagemanager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class ColumnNames : ViewModelBase
    {
        public string Name { get; set; }

        private bool _isSelected;
        
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                NotifyPropertyChanged(nameof(IsSelected));
            }
        }

        
        
        public static List<ColumnNames> GetColumnNames()
        {
            StringBuilder bu = new StringBuilder();
            PropertyInfo[] props = typeof(FileItem).GetProperties();
            
            foreach (PropertyInfo mprop in props)
            {
                if ((mprop.PropertyType.UnderlyingSystemType.FullName == "System.String") ||(mprop.PropertyType.UnderlyingSystemType.FullName == "System.DateTime"))
                {
                    bu.Append(mprop.Name);
                    bu.Append(",");
                }
                

            }
            string myColNames = bu.ToString().Remove(bu.ToString().Length - 1, 1);            
            List<ColumnNames> colNamesList = myColNames.Split(',').Select(n => new ColumnNames { Name = n.Trim(), IsSelected = true }).ToList();

            return colNamesList;

        }
    }
}
