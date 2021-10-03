using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreMS
{
    public partial class MngEmp : Form
    {
        public MngEmp()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=storedb");

        private void populate()
        {
            con.Open();
            string query = "select * from Emp";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpTbl.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product pro = new Product();
            this.Hide();
            pro.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            this.Hide();
            cat.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Emp_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into Emp values(" + EmpID.Text + ",'" + EmpName.Text + "'," + EmpAge.Text + ",'" + PhnNo.Text + "' ,'" + Pass.Text + "')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Emp Added Succsessfully!!");
                con.Close();
                populate();
                EmpID.Text = "";
                EmpName.Text = "";
                EmpAge.Text = "";
                PhnNo.Text = "";
                Pass.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmpTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpID.Text = EmpTbl.SelectedRows[0].Cells[0].Value.ToString();
            EmpName.Text = EmpTbl.SelectedRows[0].Cells[1].Value.ToString();
            EmpAge.Text = EmpTbl.SelectedRows[0].Cells[2].Value.ToString();
            PhnNo.Text = EmpTbl.SelectedRows[0].Cells[3].Value.ToString();
            Pass.Text = EmpTbl.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpName.Text == "" || EmpID.Text == "")
                {
                    MessageBox.Show("Information Not Selected");
                }
                else
                {
                    con.Open();
                    String query = "update Emp set EmpName= '" + EmpName.Text + "', EmpAge= " + EmpAge.Text + ", EmpPhone= '" + PhnNo.Text + "', EmpPass= " + Pass.Text + " where EmpID = " + EmpID.Text + "";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Succsesfully");
                    con.Close();
                    populate();
                    EmpID.Text = "";
                    EmpName.Text = "";
                    EmpAge.Text = "";
                    PhnNo.Text = "";
                    Pass.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpID.Text == "")
                {
                    MessageBox.Show("Select the category");
                }
                else
                {
                    con.Open();
                    string query = "delete from Emp where EmpID=" + EmpID.Text + "";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Sucessfully!!");
                    con.Close();
                    populate();
                    EmpID.Text = "";
                    EmpName.Text = "";
                    EmpAge.Text = "";
                    PhnNo.Text = "";
                    Pass.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
    }
}
