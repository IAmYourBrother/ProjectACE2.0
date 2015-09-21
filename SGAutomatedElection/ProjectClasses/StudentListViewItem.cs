using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public class StudentListViewItem
    {
        public StudentListViewItem()
        { 
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string YearSection { get; set; }
        public int HasVoted { get; set; }
    }
}
