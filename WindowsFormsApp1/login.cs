using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    
    public partial class login : Form
    {
        public static string userLogin; //логин юзера (для профиля изменения и т.д.)
        public static string userPass; //пароль юзера (для профиля изменения и т.д.)
        public static bool inAcc = false; //вошел ли в аккаунт человек
        public static int id_acc; // айди аккаунта храним при входе
        
        DataBase db = new DataBase();
        
        public login()
        {
            InitializeComponent();
            StartPosition= FormStartPosition.CenterScreen;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registration reg = new registration();
            reg.Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 50;
            textBox2.PasswordChar= '*';
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userMail = textBox1.Text;
            var userPassword = textBox2.Text;
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_acc, mail, password from Accounts where mail = '{userMail}' and password = '{userPassword}'";

            SqlCommand command = new SqlCommand(querystring, db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                userLogin = userMail;
                userPass = userPassword;
                inAcc = true;
                id_acc = Convert.ToInt32(table.Rows[0]["id_acc"]);
               
                Menu menu = new Menu();
                this.Hide();
                menu.Show();            
            }
            else
                invalidAc.Visible = true;


        }
    }
}
