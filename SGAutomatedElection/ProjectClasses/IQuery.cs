using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public interface IQuery
    {
        void Insert();
        void Update();
        void Delete();
    }
}
