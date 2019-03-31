using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructEnum
{
    public class SortByName : IComparer<Employee>
    {
        public int Compare(Employee object1, Employee object2)
        {
            return object1.Name.CompareTo(object2.Name);
        }
    }
}
