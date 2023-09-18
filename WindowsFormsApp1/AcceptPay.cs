using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AcceptPay : Form
    {
        public AcceptPay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label3.Visible = true;
                return;
            }
            if (textBox2.Text.Length != 16)
            {
                MessageBox.Show("Введите валидный номер");
                return;
            }

            Work.Ordering();

            basket basket = new basket();
            this.Hide();
            basket.Show();
        }
       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AcceptPay_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void textBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
