using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public class CandidateListViewItem
    {
        public CandidateListViewItem()
        { 
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public string Position { get; set; }
        public int Votes { get; set; }
    }
}
