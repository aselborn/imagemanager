using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagemanager.Models
{
    public class Duplicate : FileItem
    {

        //public List<string> DuplicatePaths { get; } = new List<string>();

        public Duplicate(string duplicatePath) : base(duplicatePath) { }
        
            //DuplicatePaths.Add(duplicatePath);
        

    }
}
