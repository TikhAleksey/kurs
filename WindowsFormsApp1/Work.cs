using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1
{
    public static class Work //класс основных методов с работой с БД
    {
        public static void GetItem(string queryString, TableLayoutPanel table) // получить предметы по очереди в TableLayoutPanel
        {
            DataBase db = new DataBase();
            MemoryStream stmBLOBData;

            int i = 0;  //счетчик для добавления строк и столбцов в layuot panel

            db.openConnection();
            SqlCommand command = new SqlCommand(queryString, db.getConnection());

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Byte[] array = new Byte[100000000];
                    long count = reader.GetBytes(0, 0, array, 0, 100000000);
                    stmBLOBData = new MemoryStream();
                    stmBLOBData.Write(array, 0, (int)count);
                    stmBLOBData.Position = 0;
                    var pb = new PictureBox();
                    pb.Height = 60;
                    pb.Width = 100;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Image = Image.FromStream(stmBLOBData);

                    var name = reader.GetString(1);
                    var price = reader.GetDecimal(2);
                    var lb = new System.Windows.Forms.Label();
                    var id = reader.GetDecimal(3);
                    string avgmark;
                    if (Convert.ToString(reader.GetSqlDecimal(4)) == "Null")
                        avgmark = "Нет оценок";
                    else
                        avgmark = $"Рейтинг: {Convert.ToString(reader.GetSqlDecimal(4))}";

                    lb.Text = $"{name} \nЦена: {((double)price)} руб \n{avgmark}";
                    lb.Size = new Size(lb.PreferredWidth, lb.PreferredHeight);
                    lb.Click += new System.EventHandler((a, b) => Katalog.OpenItem((int)id, Form.ActiveForm));

                    pb.Click += new System.EventHandler((a, b) => Katalog.OpenItem((int)id, Form.ActiveForm));





                    var gBox = new GroupBox();
                    gBox.Name = "";
                    gBox.Text = "";
                    gBox.Controls.Add(pb);
                    lb.Location = new Point(pb.Location.X + 100, pb.Location.Y);
                    gBox.Controls.Add(lb);
                    gBox.Click += new System.EventHandler((a, b) => Katalog.OpenItem((int)id, Form.ActiveForm));

                    //при наведении выделяем
                    gBox.MouseEnter += new EventHandler((a, b) => gBox.BackColor = Color.FromArgb(192, 192, 192));
                    gBox.MouseEnter += new EventHandler((a, b) => lb.BackColor = Color.FromArgb(192, 192, 192));
                    lb.MouseEnter += new EventHandler((a, b) => gBox.BackColor = Color.FromArgb(192, 192, 192));
                    lb.MouseEnter += new EventHandler((a, b) => lb.BackColor = Color.FromArgb(192, 192, 192));
                    pb.MouseEnter += new EventHandler((a, b) => gBox.BackColor = Color.FromArgb(192, 192, 192));
                    pb.MouseEnter += new EventHandler((a, b) => lb.BackColor = Color.FromArgb(192, 192, 192));

                    //при уведении антивыделяем
                    gBox.MouseLeave += new EventHandler((a, b) => gBox.BackColor = Form.ActiveForm.BackColor);
                    gBox.MouseLeave += new EventHandler((a, b) => lb.BackColor = Form.ActiveForm.BackColor);
                    lb.MouseLeave += new EventHandler((a, b) => gBox.BackColor = Form.ActiveForm.BackColor);
                    lb.MouseLeave += new EventHandler((a, b) => lb.BackColor = Form.ActiveForm.BackColor);
                    pb.MouseLeave += new EventHandler((a, b) => gBox.BackColor = Form.ActiveForm.BackColor);
                    pb.MouseLeave += new EventHandler((a, b) => lb.BackColor = Form.ActiveForm.BackColor);

                    gBox.Width = 350;
                    gBox.Height = 63;
                    table.Controls.Add(gBox, 0, i);
                    table.ColumnStyles[0].Width = 500;

                    i++;
                }
            }
            else
            {
                Label filtr = new Label();
                filtr.Text = "результатов не найдено";
                table.Controls.Add(filtr, 0, 0);
            }

            reader.Close();
        }
        public static void GetCatalog(string type, TableLayoutPanel table) //создание запроса на получение каталога
        {
            string queryString = $"SELECT picture, name, price, id_item, avgmark FROM dbo.item WHERE type = '{type}'";
            GetItem(queryString, table);
        }

        public static void ApplyFiltr(string type, TableLayoutPanel table, int index) //создание запроса для принятия фильтров
        {
            table.Controls.Clear();
            string filtr = "";
            if (index == 0)
                filtr = "price DESC";
            if (index == 1)
                filtr = "price";
            if (index == 2)
                filtr = "name";
            if (index == 3)
                filtr = "name DESC";
            if (index == 4)
                filtr = "avgmark DESC";
            if (index == 5)
                filtr = "avgmark";


            string queryString = $"SELECT picture, name, price, id_item, avgmark FROM dbo.item WHERE type = '{type}' ORDER BY {filtr}";
            GetItem(queryString, table);
        }

        public static void SearchItem(string search, string type, TableLayoutPanel table)
        {
            table.Controls.Clear();

            string query = $"SELECT picture, name, price, id_item, avgmark FROM dbo.item WHERE name LIKE '%{search}%' AND type = '{type}'";
            GetItem(query, table);
        }

        public static void GetProductpage(int id_item, PictureBox picture, Label allDescription, Label salesCount)
        {
            DataBase db = new DataBase();
            MemoryStream stmBLOBData;

            string queryString = $"SELECT picture, name, price, count, description, sales FROM dbo.item WHERE id_item = '{id_item}'";

            db.openConnection();
            SqlCommand command = new SqlCommand(queryString, db.getConnection());

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Byte[] array = new Byte[100000000];
                    long count = reader.GetBytes(0, 0, array, 0, 100000000);
                    stmBLOBData = new MemoryStream();
                    stmBLOBData.Write(array, 0, (int)count);
                    stmBLOBData.Position = 0;
                    picture.Image = Image.FromStream(stmBLOBData);

                    var name = reader.GetString(1);
                    var price = reader.GetDecimal(2);
                    var countOfItem = reader.GetInt32(3);
                    var description = reader.GetString(4);

                    allDescription.Text = $"{name} \nЦена: {((double)price)} руб \nКоличество: {countOfItem}" +
                        $"\nХарактеристики: \n{description}";
                    allDescription.Size = new Size(allDescription.PreferredWidth, allDescription.PreferredHeight);

                    var sales = reader.GetInt32(5);
                    salesCount.Text = $"Продано: {sales} шт.";
                    salesCount.AutoSize = true;
                }
            }
            else
            {
                allDescription.Text = "Ошибка";

            }
        }

        public static void AddToBasket() //добавление товара в корзину
        {
            DataBase db = new DataBase();
            if (login.inAcc == true)
            {
                var price = 0;

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();

                string queryCount = $"SELECT id_item, price, count, name FROM dbo.item WHERE id_item = '{Katalog.idSelectItem}'";
                db.openConnection();
                SqlCommand commandCount = new SqlCommand(queryCount, db.getConnection());
                adapter.SelectCommand = commandCount;
                adapter.Fill(table);
                int count = Convert.ToInt32(table.Rows[0]["count"]);
                table.Clear();

                queryCount = $"SELECT count FROM dbo.basket WHERE id_item = '{Katalog.idSelectItem}' AND id_acc = '{login.id_acc}'";
                SqlCommand commandCheckCount = new SqlCommand(queryCount, db.getConnection());
                adapter.SelectCommand = commandCheckCount;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    if (count <= Convert.ToInt32(table.Rows[0]["count"]))
                    {
                        MessageBox.Show("Товара нет на складе!");
                        return;
                    }
                }
                table.Clear();


                string queryString = $"SELECT id_item, price, count, name FROM dbo.item WHERE id_item = '{Katalog.idSelectItem}'";
                SqlCommand command = new SqlCommand(queryString, db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (Convert.ToInt32(table.Rows[0]["count"]) > 0)
                {
                    price = Convert.ToInt32(table.Rows[0]["price"]);
                    var name = table.Rows[0]["name"].ToString();
                    table.Clear();

                    queryString = $"SELECT id_acc, id_item, count, sum FROM dbo.basket WHERE id_item = '{Katalog.idSelectItem}' AND id_acc = '{login.id_acc}'";
                    SqlCommand command2 = new SqlCommand(queryString, db.getConnection());
                    adapter.SelectCommand = command2;
                    adapter.Fill(table);

                    if (table.Rows.Count <= 0)
                    {
                        string queryAdd = $"insert into basket values({login.id_acc}, {Katalog.idSelectItem}, '{name}', 1, {price}, (SELECT picture FROM dbo.item WHERE id_item = '{Katalog.idSelectItem}'))";
                        SqlCommand command3 = new SqlCommand(queryAdd, db.getConnection());

                        db.openConnection();
                        if (command3.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Товар добавлен в корзину");

                        }
                        else
                        {
                            MessageBox.Show("Ошибка добавления", "Ошибка");
                        }
                        db.closeConnection();
                    }
                    else
                    {
                        price = Convert.ToInt32(table.Rows[0]["sum"]);

                        table.Clear();

                        queryString = $"SELECT price FROM dbo.item WHERE id_item = '{Katalog.idSelectItem}'";
                        SqlCommand command4 = new SqlCommand(queryString, db.getConnection());
                        adapter.SelectCommand = command4;
                        adapter.Fill(table);

                        price += Convert.ToInt32(table.Rows[0]["price"]);
                        string queryAdd = $"UPDATE basket SET sum = {price}, count = count + 1 WHERE id_item = '{Katalog.idSelectItem}' AND id_acc = '{login.id_acc}'";
                        SqlCommand command5 = new SqlCommand(queryAdd, db.getConnection());

                        db.openConnection();
                        if (command5.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Товар добавлен в корзину");

                        }
                        else
                        {
                            MessageBox.Show("Ошибка добавления", "Ошибка");
                        }
                        db.closeConnection();
                    }

                }
                else
                {
                    MessageBox.Show("Нет в наличии");
                    db.closeConnection();
                }
            }
            else
            {
                MessageBox.Show($"Сначала войдите в аккаунт");
            }
        }


        public static void GetBasket(TableLayoutPanel table, Label sumItem, System.Windows.Forms.Button orderZakaz)
        {
            if (login.inAcc == true)
            {
                double sumOfBasket = 0;

                DataBase db = new DataBase();
                MemoryStream stmBLOBData;

                string queryString = $"SELECT id_acc, id_item, name, count, sum, picture FROM dbo.basket WHERE id_acc = '{login.id_acc}'";

                int i = 0;  //счетчик для добавления строк и столбцов в layuot panel

                db.openConnection();
                SqlCommand command = new SqlCommand(queryString, db.getConnection());

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Byte[] array = new Byte[100000000];
                        long count = reader.GetBytes(5, 0, array, 0, 100000000);
                        stmBLOBData = new MemoryStream();
                        stmBLOBData.Write(array, 0, (int)count);
                        stmBLOBData.Position = 0;
                        var pb = new PictureBox();
                        pb.Height = 60;
                        pb.Width = 100;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Image = Image.FromStream(stmBLOBData);

                        var name = reader.GetString(2);
                        var countItem = reader.GetInt32(3);

                        var lb = new System.Windows.Forms.Label();
                        lb.Text = $"{name} \nКоличество: {countItem} шт.";
                        lb.Size = new Size(lb.PreferredWidth, lb.PreferredHeight);

                        var sum = reader.GetDecimal(4);
                        sumOfBasket += (double)sum;
                        var lbsum = new Label();
                        lbsum.Text = $"Цена: {(double)sum}";
                        lbsum.Size = new Size(lbsum.PreferredWidth, lbsum.PreferredHeight);

                        var gBox = new GroupBox();
                        gBox.Name = "";
                        gBox.Text = "";
                        gBox.Controls.Add(pb);
                        lb.Location = new Point(pb.Location.X + 100, pb.Location.Y);
                        gBox.Controls.Add(lb);

                        lbsum.Location = new Point(pb.Location.X + 100, pb.Location.Y + 50);
                        gBox.Controls.Add(lbsum);

                        gBox.Height = 75;
                        gBox.Width = 350;

                        table.Controls.Add(gBox, 0, i);

                        var id = reader.GetInt32(1);

                        System.Windows.Forms.Button but = new System.Windows.Forms.Button();
                        but.Text = "Удалить из корзины";
                        but.Size = new Size(100, 40);
                        but.Click += new System.EventHandler((a, b) => DeleteFromBasket((int)id));

                        table.Controls.Add(but, 1, i);

                        i++;
                    }
                    sumItem.Text = $"Общая сумма: {sumOfBasket}";

                }
                else
                {
                    Label lb = new Label();
                    lb.Text = $"Корзина пуста";
                    lb.Size = new Size(lb.PreferredWidth, lb.PreferredHeight);
                    table.Controls.Add(lb);
                    orderZakaz.Visible = false;
                    sumItem.Visible = false;
                }

                reader.Close();
            }
            else
            {

                MessageBox.Show("войдите в аккаунт"); // не вошел в акк
            }
        }

        public static void DeleteFromBasket(int id)
        {
            DataBase db = new DataBase();
            string queryString = $"DELETE FROM basket WHERE id_acc = '{login.id_acc}' AND id_item = '{id}'";

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            db.openConnection();
            SqlCommand command = new SqlCommand(queryString, db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            basket basket = new basket();
            Form.ActiveForm.Hide();
            basket.Show();
        }

        public static void Ordering()
        {
            DataBase db = new DataBase();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            db.openConnection();
          
            string queryString = $"Select id_acc, sum(sum) as sum FROM basket WHERE id_acc = {login.id_acc} GROUP BY id_acc ";                      
            SqlCommand command = new SqlCommand(queryString, db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            int id = Convert.ToInt32(table.Rows[0]["id_acc"]);
            double sum = Convert.ToDouble(table.Rows[0]["sum"]);

            queryString = $"INSERT INTO zakaz VALUES({id},{sum})";
            SqlCommand command1 = new SqlCommand(queryString, db.getConnection());
            if (command1.ExecuteNonQuery() == 1)
            {
                DataTable table1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter();
                queryString = $"Select TOP 1 id_zakaza FROM zakaz WHERE id_acc = {login.id_acc} ORDER BY id_zakaza DESC";
                SqlCommand command2 = new SqlCommand(queryString, db.getConnection());
                SqlDataReader reader1 = command2.ExecuteReader();              
                decimal idZakaza = 0;
                while (reader1.Read())
                {
                    idZakaza = Convert.ToDecimal(reader1["id_zakaza"]);
                }
                reader1.Close();
                queryString = $"Select id_item, count, sum FROM basket WHERE id_acc = {login.id_acc}";
                SqlCommand command3 = new SqlCommand(queryString, db.getConnection());

                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    int id_item = Convert.ToInt32(reader["id_item"]);
                    int count = Convert.ToInt32(reader["count"]);
                    double sumItem = Convert.ToDouble(reader["sum"]);
                    AddItemToZakaz(idZakaza, id_item, count, sumItem); 
                    ChangeCountItem(id_item, count);
                }
                MessageBox.Show("Заказ оформлен");
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Ошибка в составлении заказа", "Ошибка");
                return;
            }
            db.openConnection();
            queryString = $"DELETE FROM basket WHERE id_acc = {login.id_acc}";
            SqlCommand command4 = new SqlCommand(queryString, db.getConnection());
            command4.ExecuteNonQuery();      

            db.closeConnection();
            UpdateSalesCountItem();
        }

        public static void AddItemToZakaz(decimal idZakaza, int id_item, int count, double sumItem)
        {
            DataBase db = new DataBase();
            db.openConnection();
            string queryAdd = $"INSERT INTO purshcase_item VALUES({idZakaza}, {id_item}, {count}, {sumItem})";
            SqlCommand command4 = new SqlCommand(queryAdd, db.getConnection());
            if (command4.ExecuteNonQuery() == 1)
            {
            }
            else
            {
                MessageBox.Show("Ошибка добавления", "Ошибка");
                return;
            }
            db.closeConnection();
        }
        public static void ChangeCountItem(int id_item, int countWasBuying)
        {
            DataBase db = new DataBase();
            db.openConnection();
            string queryChange = $"UPDATE item SET count = count - {countWasBuying} WHERE id_item = {id_item}";
            SqlCommand command = new SqlCommand(queryChange, db.getConnection());
            command.ExecuteNonQuery(); 
            db.closeConnection();
        }

        public static void ChangeStar(int mark, PictureBox[] pb)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i < mark)
                    pb[i].Image = Image.FromFile("C:\\Users\\tikho\\Desktop\\курсовая\\image\\GolddenStar.png");
                else
                    pb[i].Image = Image.FromFile("C:\\Users\\tikho\\Desktop\\курсовая\\image\\EmptyStar.png");
            }
        }
        public static void AddReview(string name, string review, double mark)
        {
            DataBase db = new DataBase();
            db.openConnection();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string real_buyer = "";
            string checkQuery = $"select purshcase_item.id_item, zakaz.id_acc " +
                $"from purshcase_item inner join zakaz ON purshcase_item.id_zakaza = zakaz.id_zakaza " +
                $"WHERE zakaz.id_acc = {login.id_acc} and id_item = {Katalog.idSelectItem}";
            SqlCommand comm = new SqlCommand(checkQuery, db.getConnection());
            MessageBox.Show($"{login.id_acc}, {Katalog.idSelectItem}");
            adapter.SelectCommand = comm;
            adapter.Fill(table);
            if (table.Rows.Count > 1)           
                real_buyer = "да";           
            else
                real_buyer = "нет";


            string queryAdd = $"INSERT INTO review VALUES({Katalog.idSelectItem}, {mark}, '{name}', '{review}', {login.id_acc}, '{real_buyer}')";
            SqlCommand command = new SqlCommand(queryAdd, db.getConnection());
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Отзыв был оставлен");
                ProductPage productPage = new ProductPage();
                Form.ActiveForm.Hide();
                productPage.Show();
            }
            else
                MessageBox.Show("Ошибка", "Ошибка");

            string queryString = $"UPDATE item SET avgmark = (SELECT avg(mark) as avgMark " +
                $"from review Where id_item = {Katalog.idSelectItem} " +
                $"group by id_item) WHERE id_item = {Katalog.idSelectItem}";
            SqlCommand command1 = new SqlCommand(queryString, db.getConnection());
            command1.ExecuteNonQuery();
            db.closeConnection();
        }

        public static void GetImage(PictureBox pb)
        {
            DataBase db = new DataBase();
            MemoryStream stmBLOBData;

            string queryString = $"SELECT picture FROM dbo.item WHERE id_item = '{Katalog.idSelectItem}'";
            db.openConnection();
            SqlCommand command = new SqlCommand(queryString, db.getConnection());

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Byte[] array = new Byte[100000000];
                    long count = reader.GetBytes(0, 0, array, 0, 100000000);
                    stmBLOBData = new MemoryStream();
                    stmBLOBData.Write(array, 0, (int)count);
                    stmBLOBData.Position = 0;
                    pb.Image = Image.FromStream(stmBLOBData);
                }
            }
        }
        public static void UpdateSalesCountItem()
        {
            List<int> listCount = new List<int> { };
            List<int> listid = new List<int> { };

            DataBase db = new DataBase();
            db.openConnection();
            string queryString = $"select id_item, sum(count) as count from purshcase_item group by id_item";
            SqlCommand command2 = new SqlCommand(queryString, db.getConnection());
            SqlDataReader reader = command2.ExecuteReader();
            while (reader.Read()) 
            {
                var count = Convert.ToInt32(reader["count"]);
                var id_item = Convert.ToInt32(reader["id_item"]);

                listCount.Add(count);
                listid.Add(id_item);
            }
            reader.Close();

            for (int i = 0; i < listid.Count; i++)
            {
                queryString = $"UPDATE item SET sales = {listCount[i]} WHERE id_item = {listid[i]}";
                SqlCommand command1 = new SqlCommand(queryString, db.getConnection());
                command1.ExecuteNonQuery();
            }
            
            

            db.closeConnection();
        }


        public static void GetReviewPage(TableLayoutPanel table)
        {
            DataBase db = new DataBase();

            string queryString = $"SELECT mark, name, review, real_buyer FROM review WHERE id_item = {Katalog.idSelectItem}";
            db.openConnection();
            SqlCommand command = new SqlCommand(queryString, db.getConnection());

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int mark = Convert.ToInt32(reader["mark"]);

                    var pb1 = new PictureBox();
                    pb1.Height = 32;
                    pb1.Width = 32;
                    pb1.SizeMode = PictureBoxSizeMode.StretchImage;
                    var pb2 = new PictureBox();
                    pb2.Height = 32;
                    pb2.Width = 32;
                    pb2.SizeMode = PictureBoxSizeMode.StretchImage;
                    var pb3 = new PictureBox();
                    pb3.Height = 32;
                    pb3.Width = 32;
                    pb3.SizeMode = PictureBoxSizeMode.StretchImage;
                    var pb4 = new PictureBox();
                    pb4.Height = 32;
                    pb4.Width = 32;
                    pb4.SizeMode = PictureBoxSizeMode.StretchImage;
                    var pb5 = new PictureBox();
                    pb5.Height = 32;
                    pb5.Width = 32;
                    pb5.SizeMode = PictureBoxSizeMode.StretchImage;

                    PictureBox[] pb = new PictureBox[] { pb1, pb2, pb3, pb4, pb5 };
                    Work.ChangeStar(mark, pb);

                    var gBox = new GroupBox();
                    gBox.AutoSize = true;
                    gBox.Controls.Add(pb1);
                    for (int j = 1; j < pb.Length; j++)
                    {
                        if (j >= 1)
                        {
                            pb[j].Location = new Point(pb[j - 1].Location.X + 32, pb[j - 1].Location.Y);
                            gBox.Controls.Add(pb[j]);
                        }
                    }
                    Label name = new Label();
                    name.AutoSize = true;
                    name.Text = $"Имя: {reader["name"]}";
                    name.Location = new Point(name.Location.X, pb1.Location.Y + 40);

                    Label review = new Label();
                    review.AutoSize = true;
                    review.Text = $"Отзыв: {reader["review"]}";
                    review.Location = new Point(review.Location.X, name.Location.Y + 15);

                    gBox.Controls.Add(name);
                    gBox.Controls.Add(review);

                    if (Convert.ToString(reader["real_buyer"]) == "да")
                    {
                        

                        Label realBuyer = new Label();
                        realBuyer.AutoSize = true;
                        realBuyer.Text = $"Реальный покупатель";
                        realBuyer.Location = new Point(realBuyer.Location.X, review.Location.Y + 15);
                        realBuyer.ForeColor = Color.FromArgb(192, 192, 192);

                        Label info = new Label();
                        info.AutoSize = true;
                        info.Text = $"Этот отзыв оставлен человеком,\nкупившим данный продукт";
                        info.Location = new Point(realBuyer.Location.X, realBuyer.Location.Y + 15);
                        info.ForeColor = realBuyer.ForeColor;

                        realBuyer.MouseEnter += new EventHandler((a, b) => gBox.Controls.Add(info));
                        realBuyer.MouseLeave += new EventHandler((a, b) => gBox.Controls.Remove(info));
                        
                        gBox.Controls.Add(realBuyer);
                    }
                                                           
                    table.Controls.Add(gBox);
                }
            }
            else
            {
                var label = new Label();
                label.AutoSize = true;
                label.Text = $"Отзывов нет";
                table.Controls.Add(label);
            }

            reader.Close();
        }

        public static void ShowInfoAboutRealBuyer(Label realBuyer)
        {
            Label info = new Label();
            info.AutoSize = true;
            info.Text = $"Этот отзыв оставлен человеком, купившим данный продукт";
            info.Location = new Point(realBuyer.Location.X, realBuyer.Location.Y + 15);
        }

        public static void CheckForOrdering()
        {
            DataBase db = new DataBase();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            db.openConnection();

            string queryCheck = $"select id_item, count from basket where id_acc = {login.id_acc}";
            SqlCommand commandCheckCount = new SqlCommand(queryCheck, db.getConnection());
            SqlDataReader reader = commandCheckCount.ExecuteReader();
            while (reader.Read())
            {
                if (!CheckCountForOrdering(Convert.ToInt32(reader["id_item"]), Convert.ToInt32(reader["count"])))
                    return;
            }

            db.closeConnection();

            AcceptPay accept = new AcceptPay();
            Form.ActiveForm.Hide();
            accept.Show();
        }

        public static bool CheckCountForOrdering(int id_item, int countInBasket) 
        {
            DataBase db = new DataBase();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            db.openConnection();

            string queryCheckCount = $"select name, count from item where id_item = {id_item}";
            SqlCommand commandCheck = new SqlCommand(queryCheckCount, db.getConnection());
            adapter.SelectCommand = commandCheck;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                if (Convert.ToInt32(table.Rows[0]["count"]) < Convert.ToInt32(countInBasket))
                {
                    MessageBox.Show($"{table.Rows[0]["name"]} нет на складе");
                    db.closeConnection();
                    return false;
                }               
            }
            table.Clear();
            db.closeConnection();
            return true;
        }

    }

}
