using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akademine_Sistema
{
    public class account
    {
        int id, type, group;
        string name;

        public account(int id, string name, int type, int group)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.group = group;
        }

        public override string ToString()
        {
            string account_type;
            if (type == 0)
                account_type = "Teacher";
            else 
                account_type = "Student";
            /*
            else
                account_type=patient
            */

            string group_type;
            if (group == 0)
                group_type = "PI20S";
            else
                group_type = "PI21A";

            return account_type + ": " + id.ToString() + " - " + name + " - " + group_type.ToString();
        }

        public int getID()
        {
            return id;
        }
    }
}
