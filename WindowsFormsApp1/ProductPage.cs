using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class ProductPage : Form
    {
        
        public ProductPage()
        {
            InitializeComponent();
        }

        private void ProductPage_Load(object sender, EventArgs e)
        {
            Work.GetProductpage(Katalog.idSelectItem, pictureBox1, label1, label4);

            if (login.inAcc == true)
            {
                label13.Text = login.userLogin;

                linkLabel1.Visible = false;
                linkLabel2.Visible = true;

                label13.Visible = true;
                label13.Left = label13.Location.X - (label13.Text.Length * 6);
            }
            else
            {
                linkLabel1.Visible = true;
                linkLabel2.Visible = false;
                label13.Visible = false;           
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login.inAcc = false;

            Katalog kat = new Katalog();
            this.Hide();
            kat.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login log = new login();
            this.Hide();
            log.Show();       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login.inAcc == true)
            {
                Work.AddToBasket();                      
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Katalog katalog = new Katalog();
            this.Hide();
            katalog.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (login.inAcc == false)
            {
                MessageBox.Show("Войдите в аккаунт", "Внимание!");
                return;
            }
            AddReview addReview = new AddReview();
            this.Hide();
            addReview.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Review review = new Review();
            this.Hide();
            review.Show();
        }
    }
}
