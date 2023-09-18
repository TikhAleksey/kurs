using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Katalog : Form
    {
        public static int idSelectItem;
        DataBase db = new DataBase();       
        public Katalog()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;            
        }

        private void Katalog_Load(object sender, EventArgs e)
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

            Work.GetCatalog(DataBase.type, catalogPanel);
            
        }              
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();          
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login.inAcc = false;

            Katalog kat = new Katalog();
            this.Hide();
            kat.Show();
        }

        private void catalogTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            this.Hide();
            m.Show();
        }        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Work.ApplyFiltr(DataBase.type, catalogPanel, comboBox1.SelectedIndex);
        }
      
        public static void OpenItem(int id_item, Form f)
        {
            idSelectItem = id_item;
            ProductPage pp = new ProductPage();
            f.Hide();
            pp.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            basket basket = new basket();
            this.Hide();
            basket.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {         
            string search = textBox1.Text;
            if (search == "")
            {
                Work.GetCatalog(DataBase.type, catalogPanel);
                return;
            }

            Work.SearchItem(search, DataBase.type, catalogPanel);
        }
    }
}
