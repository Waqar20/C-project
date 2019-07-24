using System;
using System.Collections;
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
    public partial class first_page : Form
    {
        public first_page()
        {
            InitializeComponent();
            dataGridView2.Hide();
        }

        string total = "", to = "";
        long inp =0,inp1 = 0, inp2 = 0, res = 0;
     
        private void label2_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string dt = dateTimePicker1.Value.Date.ToString();
            try
            {
                var query = "insert into Stock values('" + i_name.Text + "','" + i_price.Text + "','" + i_quan.Text + "','" + i_com_n.Text + "','" + dt + "')";
                int res = db.connect_IUD(query);

              
                if (res > 0)
                {
                    MessageBox.Show("Item insert Sucessfull !");

                    i_name.Text = "";
                    i_price.Text = "";
                    i_com_n.Text = "";
                    i_quan.Text = "";
                }
                else
                {
                    MessageBox.Show("Item insert Error !");
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }

        private void i_price_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if(!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar)&&(e.KeyChar!='.')){
                e.Handled = true;
            }
        }

        private void i_quan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

            try
            {
                var query = "select item_name from Stock ";
                SqlDataReader dr = db.connect_select(query);
               
                while(dr.Read()){
                    comboBox1.Items.Add(dr.GetString(0));
                }

            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }

        }

        private void first_page_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            try
            {
                var query = "select item_name from Stock ";
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
            string price=textBox1.Text, qun=textBox2.Text;
            try
            {
                var query = "update Stock set item_price='" + price + "', item_quantity='" + qun + "' where item_name='" + comboBox1.SelectedItem + "'";
                int res = db.connect_IUD(query);
                
              
                if (res > 0)
                {
                    MessageBox.Show("Item Update Sucessfull !");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Item Update Error !");
                    textBox1.Text = "";
                    textBox2.Text = "";
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
                var query = " delete from Stock  where item_name='" + comboBox1.SelectedItem + "'";
                int res = db.connect_IUD(query);
                
                if (res > 0)
                {
                    MessageBox.Show("Item Delete Sucessfull !");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Item Delete Error !");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try {
                string query = "select * from stock";
                db.connect_sel_table(query);

                SqlCommand cmd = new SqlCommand(query,db.con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s = textBox3.Text;
       //   int n = dataGridView2.Rows.Add();
        
            try
            {
                dataGridView2.Show();
                string query = "select item_name from Stock where item_name like '" + s + "%'";
            
                 db.connect_sel_table(query);
                 SqlDataReader dr = db.connect_select(query);
                while(dr.Read()){
                  button6.Text = dr.GetString(0);
                                  
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
           
            try
            {
               
                textBox4.Text = " ";
                textBox4.AppendText("" + Environment.NewLine);
                textBox4.AppendText(" MART SYSTEM " + Environment.NewLine);
                textBox4.AppendText("* * * * * * * * * * *"+ Environment.NewLine);
                textBox4.AppendText("" + Environment.NewLine);
                textBox4.AppendText("Total Price : " + label15.Text + Environment.NewLine);
                int ca = dataGridView2.RowCount - 1;
               
                textBox4.AppendText ( "Item Quntaty : " + ca +Environment.NewLine);
              
         

              
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {
            
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
    
            long dt_qun=0,fm_qn=0;
           
            string fm_qun = textBox5.Text ,fmm="0";
            string a = "", b = "", c = "", d = "";
            string query = "select item_name, item_price , item_quantity,company_name,item_expire from Stock where item_name='"+button6.Text+"'";
            try
            {
                fmm = fm_qun;
                db.connect_sel_table(query);
                SqlDataReader dr = db.connect_select(query);
                fm_qn = long.Parse(fmm);
                while (dr.Read())
                {
                   a = dr.GetString(0);
                   b = dr.GetInt32(1).ToString();
                dt_qun= dr.GetInt64(2);
                   c = dr.GetString(3);
                   d = dr.GetString(4);
           
                }
                if(fm_qun==""){
                    MessageBox.Show("Please insert any Quantity");
                }
                else if (fm_qn < dt_qun)
                {
                    int n = dataGridView2.Rows.Add();
                    
                    dataGridView2.Rows[n].Cells[0].Value = a;
                    dataGridView2.Rows[n].Cells[1].Value = b;
                    dataGridView2.Rows[n].Cells[2].Value = c;
                    dataGridView2.Rows[n].Cells[3].Value = fm_qun;
                    dataGridView2.Rows[n].Cells[4].Value = d;
                    label13.Text = dt_qun.ToString();
                    if (n == 0)
                    {
                        to = dataGridView2.Rows[0].Cells[1].Value.ToString();
                        inp1 = int.Parse(to);
                    }
                    else {
                        total = dataGridView2.Rows[n].Cells[1].Value.ToString();
                        inp2 = int.Parse(total);
                     }
                    inp = inp2 * fm_qn;
                    res = inp1 += inp;
                  
                   
                    label15.Text = res.ToString();
                    textBox3.Text = "";
                    textBox5.Text = "";
                    fm_qun = "";
                   
                   int ca = dataGridView2.RowCount -1;
                     label16.Text = ca.ToString();
                        
                }
                else {
                    MessageBox.Show("Stock Not Avalabale");
                }
     
    }
            catch(Exception ex){

                MessageBox.Show("Mising Same Thing");
    }
                      }

        private void button7_Click(object sender, EventArgs e)
        {
            employes em = new employes();
            em.Show();
            this.Hide();
              }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            label15.Text = "";
            label13.Text = "";
            dataGridView2.Hide();
          
            
        }
    }
}
