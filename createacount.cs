using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_of_mart_system
{
    public partial class createacount : Form
    {
        public createacount()
        {
            InitializeComponent();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar)&&(e.KeyChar!='.')){
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user=f_user.Text, father=f_father.Text, d_birth=f_date.Text, gender="", nic=f_nic.Text, add=f_add.Text, pass=f_pas.Text, cpas=f_cpas.Text;
           if(radioButton1.Checked){
               gender = "Mail";
           }
            else{
                gender = "Femail";
           }



           try
           {
               if (pass == cpas)
               {
                   string query = "insert into log_in values('" + user + "','" + father + "','" + d_birth + "','" + gender + "','" + nic + "','" + add + "','" + pass + "')";

                   int res = db.connect_IUD(query);
                   
                   if (res > 0)
                   {
                       MessageBox.Show("Your Account is Created");
                       f_user.Text = "";
                       f_add.Text = "";
                       f_cpas.Text = "";
                       f_date.Text = "";
                       f_father.Text = "";
                       f_pas.Text = "";
                       f_nic.Text = "";
                   }
                   else
                   {
                       MessageBox.Show("Error");
                       f_user.Text = "";
                       f_add.Text = "";
                       f_cpas.Text = "";
                       f_date.Text = "";
                       f_father.Text = "";
                       f_pas.Text = "";
                       f_nic.Text = "";
                   }
               }
               else
               {
                   MessageBox.Show("Increcct password  ");
                   f_user.Text = "";
                   f_add.Text = "";
                   f_cpas.Text = "";
                   f_date.Text = "";
                   f_father.Text = "";
                   f_pas.Text = "";
                   f_nic.Text = "";

               }
           }
               



           catch (Exception ex)
           {

               MessageBox.Show(ex.ToString());
           }
           }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
