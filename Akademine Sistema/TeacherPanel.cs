using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akademine_Sistema
{
    public partial class TeacherPanel : Form
    {
        int account_id;
        public TeacherPanel(int id)
        {
            InitializeComponent();
            account_id = id;
        }
    }
}
