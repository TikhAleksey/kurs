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

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        DataBase db = new DataBase();
        
        public Menu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (login.inAcc == true)
            {               
                label13.Text = login.userLogin;
               
                linkLabel1.Visible = false;
                linkLabel2.Visible = true;
                
                label13.Visible = true;
                label13.Left = label13.Location.X - (label13.Text.Length * 6);

                label15.Visible = true;
            }
            else
            {
                linkLabel1.Visible = true;
                linkLabel2.Visible = false;
                label13.Visible = false;
                label15.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login.inAcc = false;

            Menu m = new Menu();
            this.Hide();
            m.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

            DataBase.type = "accessories";
            Katalog kat = new Katalog();
            this.Hide();
            kat.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DataBase.type = "pc";
            Katalog kat = new Katalog();
            this.Hide();
            kat.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DataBase.type = "phone";
            Katalog kat = new Katalog();
            this.Hide();
            kat.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DataBase.type = "otdix";
            Katalog kat = new Katalog();
            this.Hide();
            kat.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DataBase.type = "tv";
            Katalog kat = new Katalog();
            this.Hide();
            kat.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            DataBase.type = "setevoe";
            Katalog kat = new Katalog();
            this.Hide();
            kat.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            basket basket = new basket();
            this.Hide();
            basket.Show();
        }
    }
}
