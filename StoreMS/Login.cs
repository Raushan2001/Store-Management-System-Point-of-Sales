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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CatDrop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Uname.Text = "";
            Pwd.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Uname.Text=="" || Pwd.Text == "")
            {
                MessageBox.Show("Enter valid Username or Password");
            }
            else
            {
                if (RoleDrop.SelectedItem.ToString() == "Admin")
                {
                    if(Uname.Text == "admin" && Pwd.Text =="admin")
                    {
                        Product prod = new Product();
                        prod.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Type, User Name or Password");
                        RoleDrop.Text = "";
                        Uname.Text = "";
                        Pwd.Text = "";
                    }
                }
                else if (RoleDrop.SelectedItem.ToString() == "Employee")
                {
                    if (Uname.Text == "user" && Pwd.Text == "user")
                    {
                        Emp emp = new Emp();
                        emp.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Type, User Name or Password");
                        RoleDrop.Text = "";
                        Uname.Text = "";
                        Pwd.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Oops Somthing Went Wrong");
                }
            }
        }
    }
}
