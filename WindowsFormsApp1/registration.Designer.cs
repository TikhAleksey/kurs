namespace WindowsFormsApp1
{
    partial class registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registration));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_vvediteKod = new System.Windows.Forms.Label();
            this.tb_vvediteKod = new System.Windows.Forms.TextBox();
            this.label_genPassword = new System.Windows.Forms.Label();
            this.tb_genPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.linkLabel1.Location = new System.Drawing.Point(287, 327);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 16);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Есть аккаунт";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(248, -21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Зарегистрироваться";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Введите почту:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(248, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 22);
            this.textBox1.TabIndex = 8;
            // 
            // label_vvediteKod
            // 
            this.label_vvediteKod.AutoSize = true;
            this.label_vvediteKod.Location = new System.Drawing.Point(245, 186);
            this.label_vvediteKod.Name = "label_vvediteKod";
            this.label_vvediteKod.Size = new System.Drawing.Size(171, 16);
            this.label_vvediteKod.TabIndex = 16;
            this.label_vvediteKod.Text = "Введите пароль еще раз:";
            this.label_vvediteKod.Visible = false;
            this.label_vvediteKod.Click += new System.EventHandler(this.label_vvediteKod_Click);
            // 
            // tb_vvediteKod
            // 
            this.tb_vvediteKod.Location = new System.Drawing.Point(248, 205);
            this.tb_vvediteKod.Name = "tb_vvediteKod";
            this.tb_vvediteKod.Size = new System.Drawing.Size(168, 22);
            this.tb_vvediteKod.TabIndex = 17;
            this.tb_vvediteKod.Visible = false;
            // 
            // label_genPassword
            // 
            this.label_genPassword.AutoSize = true;
            this.label_genPassword.Location = new System.Drawing.Point(262, 129);
            this.label_genPassword.Name = "label_genPassword";
            this.label_genPassword.Size = new System.Drawing.Size(142, 16);
            this.label_genPassword.TabIndex = 18;
            this.label_genPassword.Text = "Придумайте пароль:";
            // 
            // tb_genPassword
            // 
            this.tb_genPassword.Location = new System.Drawing.Point(248, 148);
            this.tb_genPassword.Name = "tb_genPassword";
            this.tb_genPassword.Size = new System.Drawing.Size(168, 22);
            this.tb_genPassword.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(205, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Данная почта уже зарегистрирована";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(459, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 354);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(-4, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 354);
            this.panel2.TabIndex = 22;
            // 
            // registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 352);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_genPassword);
            this.Controls.Add(this.label_genPassword);
            this.Controls.Add(this.tb_vvediteKod);
            this.Controls.Add(this.label_vvediteKod);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Name = "registration";
            this.Text = "registration";
            this.Load += new System.EventHandler(this.registration_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_vvediteKod;
        private System.Windows.Forms.TextBox tb_vvediteKod;
        private System.Windows.Forms.Label label_genPassword;
        private System.Windows.Forms.TextBox tb_genPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}