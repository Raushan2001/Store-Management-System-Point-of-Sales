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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=storedb");
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void filldrop()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select CatName from category", con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            CatDrop.ValueMember = "CatName";
            CatDrop.DataSource = dt;
            con.Close();
        }

        private void populate()
        {
            con.Open();
            string query = "select * from ProductTbl";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdTbl.DataSource = ds.Tables[0];
            con.Close();

        }

        private void Product_Load(object sender, EventArgs e)
        {
            filldrop();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MngEmp emp = new MngEmp();
            this.Hide();
            emp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            this.Hide();
            cat.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into ProductTbl values(" + ProdID.Text + ",'" + ProdName.Text + "'," + ProdQ.Text + ",'"+CatDrop.SelectedValue.ToString()+ "' ," + ProdPrice.Text + ")";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added Succsessfully!!");
                con.Close();
                populate();
                ProdID.Text = "";
                ProdName.Text = "";
                ProdQ.Text = "";
                CatDrop.Text = "";
                ProdPrice.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProdTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdID.Text = ProdTbl.SelectedRows[0].Cells[0].Value.ToString();
            ProdName.Text = ProdTbl.SelectedRows[0].Cells[1].Value.ToString();
            ProdQ.Text = ProdTbl.SelectedRows[0].Cells[2].Value.ToString();
            ProdPrice.Text = ProdTbl.SelectedRows[0].Cells[4].Value.ToString();
            CatDrop.Text = ProdTbl.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProdName.Text == "" || ProdID.Text == "")
                {
                    MessageBox.Show("Information Not Selected");
                }
                else
                {
                    con.Open();
                    String query = "update ProductTbl set ProdName= '" + ProdName.Text + "', ProdQty= " + ProdQ.Text + ", ProdCat= '" + CatDrop.Text + "', Price= " + ProdPrice.Text + " where ProdID = " + ProdID.Text + "";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Succsesfully");
                    con.Close();
                    populate();
                    ProdID.Text = "";
                    ProdName.Text = "";
                    ProdQ.Text = "";
                    CatDrop.Text = "";
                    ProdPrice.Text = "";
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
                if (ProdID.Text == "")
                {
                    MessageBox.Show("Select the category");
                }
                else
                {
                    con.Open();
                    string query = "delete from ProductTbl where ProdID=" + ProdID.Text + "";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Sucessfully!!");
                    con.Close();
                    populate();
                    ProdID.Text = "";
                    ProdName.Text = "";
                    ProdQ.Text = "";
                    CatDrop.Text = "";
                    ProdPrice.Text = "";
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
