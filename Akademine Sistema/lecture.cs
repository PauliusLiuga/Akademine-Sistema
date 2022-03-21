using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akademine_Sistema
{
    internal class lecture
    {
        string name;
        int teacher, group;
        public lecture(string name, int teacher, int group)
        {
            this.name = name;
            this.teacher = teacher;
            this.group = group;

        }
        public override string ToString()
        {
            return name+ " "+teacher+" "+group;
        }

        
    }

}
