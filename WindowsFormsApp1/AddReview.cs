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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1
{
    public partial class AddReview : Form
    {
        public PictureBox[] pb = new PictureBox[5];
        public static double mark = 1;
        
        public AddReview()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Work.ChangeStar(1, pb);
            mark = 1;
        }

        private void AddReview_Load(object sender, EventArgs e)
        {
            pb[0] = pictureBox1;
            pb[1] = pictureBox2;
            pb[2] = pictureBox3;
            pb[3] = pictureBox4;
            pb[4] = pictureBox5;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Work.ChangeStar(2, pb);
            mark = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Work.ChangeStar(3, pb);
            mark = 3;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Work.ChangeStar(4, pb);
            mark = 4;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Work.ChangeStar(5, pb);
            mark = 5;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ProductPage productPage = new ProductPage();
            this.Hide();
            productPage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            if (textBox1.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Внимание!");
                return;
            }
            if (richTextBox1.Text.Length < 5)
            {
                MessageBox.Show("В вашем отзыве менее 5 символов", "Внимание!");
                return;
            }
            string name = textBox1.Text;
            string review = richTextBox1.Text;
            Work.AddReview(name, review, mark);                   
        }
    }
}
