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

namespace project_of_mart_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fm_user = user.Text, fm_pass = pass.Text;
            string db_user = "", db_pass = "";
            try{
                if (fm_user == "")
                {
                    MessageBox.Show("Please insert it !!");
                }
                else
                {
                    string query = "select username, password from log_in where username='" + fm_user + "' and password='" + fm_pass + "' ";
                    SqlDataReader dr = db.connect_select(query);
                   
                    while (dr.Read())
                    {
                        db_user = dr.GetString(0);
                        db_pass = dr.GetString(1);
                    }
                    if (db_user.Equals(fm_user) && db_pass.Equals(fm_pass))
                    {
                        MessageBox.Show("Login copmlited !!");
                        this.Hide();
                        user.Text = "";
                        pass.Text = "";
                        first_page fs = new first_page();
                        fs.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Error !!");
                        user.Text = "";
                        pass.Text = "";
                    }
              
                
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            createacount cn = new createacount();
            cn.Show();
            this.Hide();



        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
