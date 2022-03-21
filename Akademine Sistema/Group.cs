using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Akademine_Sistema
{
    public partial class Group : Form
    {
        public Group()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Resources.connectionString);
        SqlCommand command;


        private void updateList(string group)
        {
            command= con.CreateCommand();
            command.CommandText = "SELECT account_id, account_name, account_type, account_group_type FROM account WHERE account_group_type=@group AND account_type=1";
            command.Parameters.AddWithValue("@group", comboBox1.SelectedIndex);

            con.Open();
            listBox1.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add( new account( reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3) ) ); 
            }
            con.Close();
        }

        private void updateLectures(string group)
        {
            command = con.CreateCommand();
            command.CommandText = "SELECT lecture_name, lecture_teacher_id, lecture_group_id FROM lecture WHERE lecture_group_id=@group";
            command.Parameters.AddWithValue("@group", comboBox1.SelectedIndex);
            con.Open();
            listBox2.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox2.Items.Add(new lecture(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2)));
            }
            con.Close();
        }

        private void updateTeachers(string group)
        {
            command = con.CreateCommand();
            command.CommandText = "SELECT account_id, account_name, account_type, account_group_type FROM account WHERE account_group_type=@group AND account_type=0";
            command.Parameters.AddWithValue("@group", comboBox1.SelectedIndex);

            con.Open();
            listBox3.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox3.Items.Add(new account(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
            }
            con.Close();
        }

        private void Group_Load(object sender, EventArgs e)
        {
            updateList("");
            updateTeachers("");
            updateLectures("");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateList(comboBox1.Text);
            updateTeachers("");
            updateLectures("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command.CommandText = "INSERT INTO lecture lecture_name, lecture_teacher_id, lecture_group_type VALUES @lecture, @teacher, @group";
            command.Parameters.AddWithValue("@lecture", textBox1.Text);
            command.Parameters.AddWithValue("@teacher", listBox3.SelectedIndex);
            command.Parameters.AddWithValue("@group", listBox1.SelectedIndex);

            updateLectures("");
        }
    }
}
