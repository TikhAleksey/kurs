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
    public partial class Review : Form
    {
        public Review()
        {
            InitializeComponent();
        }

        private void Review_Load(object sender, EventArgs e)
        {
            Work.GetImage(pictureBox1);

            Work.GetReviewPage(tableReview);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ProductPage productPage= new ProductPage();
            productPage.Show();
            this.Hide();
        }
    }
}
