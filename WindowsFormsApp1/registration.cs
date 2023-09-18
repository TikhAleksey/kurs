using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Crypto.Macs;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class registration : Form
    {
        DataBase db = new DataBase();
        public registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            label1.Visible = false;

            if (tb_vvediteKod.Visible == false)
            {
                if (textBox1.Text != "" && tb_genPassword.Text != "")
                {
                    

                    var us_login = textBox1.Text;
                    var password = tb_genPassword.Text;



                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();

                    string queryCheck = $"select mail from Accounts where mail = '{us_login}'";

                    SqlCommand command = new SqlCommand(queryCheck, db.getConnection());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    if (table.Rows.Count <= 0)
                    {
                        if (tb_vvediteKod.Visible == false && textBox1.Text != "")
                        {
                            tb_vvediteKod.Visible = true;
                            label_vvediteKod.Visible = true;

                            textBox1.Enabled = false;
                            tb_genPassword.Enabled = false;
                        }
                    }
                    else
                        label1.Visible = true;
                }
                else
                    MessageBox.Show("Заполните все поля", "Ошибка");

                
              
            }
            else
            {
                if (textBox1.Text != "" && tb_genPassword.Text != "" && tb_vvediteKod.Text != "")
                {


                    var us_login = textBox1.Text;
                    var password = tb_genPassword.Text;
                    var tbKod = tb_vvediteKod.Text;

                    if (tbKod == password)
                    {


                        string queryAdd = $"insert into Accounts(mail, password) values('{us_login}', '{password}')";

                        SqlCommand command = new SqlCommand(queryAdd, db.getConnection());

                        db.openConnection();
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Аккаунт создан");
                            login log = new login();
                            this.Hide();
                            log.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка в создании аккаунта", "Ошибка");
                        }
                        db.closeConnection();
                    }

                    else
                        MessageBox.Show("Пароли не совпадают!");
                }
                else
                    MessageBox.Show("Заполните все поля", "Ошибка");
            }
            

            
        }

        private void registration_Load(object sender, EventArgs e)
        {
            
        }

        private void label_vvediteKod_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login login = new login();
            this.Hide();
            login.ShowDialog();
        }

        private void registration_Load_1(object sender, EventArgs e)
        {

        }
    }
}
