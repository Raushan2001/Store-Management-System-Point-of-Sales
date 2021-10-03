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
    public partial class Emp : Form
    {
        public Emp()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=storedb");

        private void populate()
        {
            con.Open();
            string query = "select ProdName, Price from ProductTbl";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdGv.DataSource = ds.Tables[0];
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        int n = 0;
        int GTot = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if (PName.Text == "" || PQty.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                int total = Convert.ToInt32(PPrice.Text) * Convert.ToInt32(PQty.Text);
                DataGridViewRow nr = new DataGridViewRow();
                nr.CreateCells(BillGv);
                nr.Cells[0].Value = n + 1;
                nr.Cells[1].Value = PName.Text;
                nr.Cells[2].Value = PPrice.Text;
                nr.Cells[3].Value = PQty.Text;
                nr.Cells[4].Value = Convert.ToInt32(PPrice.Text) * Convert.ToInt32(PQty.Text);
                BillGv.Rows.Add(nr);
                GTot = GTot + total;
                GTotLb.Text = GTot.ToString() + ".00";
                PName.Text = "";
                PPrice.Text = "";
                PQty.Text = "";
                n++;
            }
        }

        private void EmpID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Emp_Load(object sender, EventArgs e)
        {
            populate();
            Datelb.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();

        }

        private void ProdGv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PName.Text = ProdGv.SelectedRows[0].Cells[0].Value.ToString();
            PPrice.Text = ProdGv.SelectedRows[0].Cells[1].Value.ToString();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("STORE MANAGEMENT SYSTEM", new Font("Century Gothic", 25, FontStyle.Italic), Brushes.Black, new Point(160,15));
            e.Graphics.DrawString("Sample Bill Print View", new Font("Century Gothic", 20, FontStyle.Italic), Brushes.Black, new Point(280,50));
        }
    }
}
