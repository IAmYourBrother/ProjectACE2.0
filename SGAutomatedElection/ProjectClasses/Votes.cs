using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public class Votes : IQuery
    {
        public Votes(int id)
        {
            ID = id;
        }
        public void Insert()
        { 
            //nothing should happen here since we'll just update the votes in the candidate table. :))
        }
        public void Update()
        { }
        public void Delete()
        {
            //nothing here
        }
            //props
        public int ID { get; set; }
        public int VoteCast { get; set; }
    }
}
