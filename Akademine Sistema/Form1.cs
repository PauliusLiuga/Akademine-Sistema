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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = Akademine_Sistema.Properties.Resources.connectionString;
            SqlConnection con= new SqlConnection(connectionString);
            SqlCommand command= con.CreateCommand();

            command.CommandText = "SELECT user_id FROM [user] WHERE user_username=@username AND user_password=@password";
            command.Parameters.AddWithValue("@username", textBox1.Text);
            command.Parameters.AddWithValue("@password", textBox2.Text);

            con.Open();
            var result = command.ExecuteScalar();
            con.Close();

            if (result != null)
            {
                //Authenticated
                if(textBox1.Text=="admin")
                {
                    //Admin panel
                    Hide();
                    AdminPanel adminPanel= new AdminPanel();
                    adminPanel.ShowDialog();
                    Show();
                }
                else
                {
                    con.Open();
                    command.CommandText = "SELECT account_id, account_type FROM account WHERE account_user_id=@user_id";
                    command.Parameters.AddWithValue("@user_id", result.ToString());
                    SqlDataReader reader = command.ExecuteReader();                   

                    if(reader.Read())
                    {
                        int account_id = reader.GetInt32(0);
                        int account_type=reader.GetInt32(1);

                        con.Close();

                        if (account_type==0)
                        {
                            //Teacher panel
                            Hide();
                            TeacherPanel teacherPanel = new TeacherPanel(account_id);
                            teacherPanel.ShowDialog();
                            Show();
                        }
                        else if(account_type==1)
                        {
                            //Student panel
                            Hide();
                            StudentPanel studentPanel = new StudentPanel(account_id);
                            studentPanel.ShowDialog();
                            Show();
                        }
                    }
                }
            }
            else
            {
                //Authentication error
                MessageBox.Show("Authentication failed");
            }
            
        }
    }
}
