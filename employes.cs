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
    public partial class employes : Form
    {
        public employes()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from log_in";

                db.connect_sel_table(query);

                SqlCommand cmd = new SqlCommand(query, db.con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            try
            {
                string query = "select * from log_in where username='" + name + "'";
                db.connect_sel_table(query);

                SqlCommand cmd = new SqlCommand(query, db.con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                textBox1.Text="";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void employes_Load(object sender, EventArgs e)
        {
            try
            {
                var query = "select username from log_in ";
                SqlDataReader dr = db.connect_select(query);

                
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr.GetString(0));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string father = f_father.Text, date = f_date.Text, add = f_add.Text, pass = f_pas.Text;
          
            try
            {
                var query = "update log_in set  father='" + father + "', date_of_birth='" + date + "',addres='" + add + "',password='" + pass + "' where username='" + comboBox1.SelectedItem + "'";
                int res = db.connect_IUD(query);
                if (res > 0)
                {
                    MessageBox.Show(" Update Sucessfull !");
                   
                    f_father.Text = "";
                    f_add.Text = "";
                    f_date.Text = "";
                    f_pas.Text = "";
            
                }
                else
                {
                    MessageBox.Show("Update Error !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var query = " delete from log_in  where username='" + comboBox1.SelectedItem + "'";
                int res = db.connect_IUD(query);

              
                if (res > 0)
                {
                    MessageBox.Show("Data Delete Sucessfull !");
                    f_father.Text = "";
                    f_add.Text = "";
                    f_date.Text = "";
                    f_pas.Text = "";
                }
                else
                {
                    MessageBox.Show("Data Delete Error !");
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            try
            {
                var query = " select count(username) from log_in";
                SqlDataReader dr = db.connect_select(query);

                while (dr.Read())
                {
                    emp.Text = "" + dr.GetSqlValue(0) + "";
                  
                }
            }
            catch(Exception ex){

                MessageBox.Show(ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            first_page fs = new first_page();
            fs.Show();
        }
    }
}
