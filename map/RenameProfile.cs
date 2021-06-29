using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using System.Data.Common;

namespace map
{
    public partial class RenameProfile : Form
    {
        dbworker db = new dbworker(bd_CON_VAL.server, bd_CON_VAL.user, bd_CON_VAL.pass, "Liorkin");

        int globalid = 0;
        public RenameProfile(int id)
        {
            InitializeComponent();
            comboBox1.DataSource = db.getTableInfo("SELECT id, City.Name FROM City");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";

            comboBox2.DataSource = db.getTableInfo("SELECT id, Gender.Name FROM Gender");
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "id";

            NameBox.Text = db.Usr_name(id);
            SurnameBox.Text = db.Usr_surname(id);
            SecnameBox.Text = db.Usr_secname(id);
            //CityBox.Text = db.Usr_city(id);
            //GenderBox.Text = db.Usr_gender(id);
            AgeBox.Text = db.Usr_age(id);
            AboutMeBox.Text = db.Usr_about(id);
            PasswordBox.Text = db.Usr_password(id);
            globalid = id;       
        }

        private void SafeAndClose_Click(object sender, EventArgs e)
        { 

            if (!Regex.Match(NameBox.Text, @"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$").Success)
            {
                MessageBox.Show("Имя не должно содержить цифр и символов!(кроме необходимых) )", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!Regex.Match(SurnameBox.Text, @"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$").Success)
            {
                MessageBox.Show("Фамилия не должна содержить цифр и символов!(кроме необходимых) )", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;

            }
            else if (!Regex.Match(PasswordBox.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Пароль должен содержать цифры, буквы верхнего и нижнего регистра", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            else if ((NameBox.Text.Length < 2) || (NameBox.Text.Length > 50))
            {
                MessageBox.Show("Неверная длина имени!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if ((SurnameBox.Text.Length < 2) || (SurnameBox.Text.Length > 50))
            {
                MessageBox.Show("Неверная длина фамилии!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if ((PasswordBox.Text.Length < 8) || (PasswordBox.Text.Length > 15))
            {
                MessageBox.Show("Неверная длина пароля!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (!Regex.Match(AgeBox.Text, @"^(?:1[01][0-9]|120|1[7-9]|[2-9][0-9])$").Success)
            {
                MessageBox.Show("Неверно указан возраст", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            dbworker db = new dbworker("95.104.192.212", "Liorkin", "lostdox561771", "Liorkin");
            db.Set_password(globalid, PasswordBox.Text.ToString());
            db.Set_aboutme(globalid, AboutMeBox.Text.ToString());
            db.Set_gender(globalid, Convert.ToInt32(comboBox2.SelectedValue));
            db.Set_name(globalid, NameBox.Text.ToString());
            db.Set_secname(globalid, SecnameBox.Text.ToString());
            db.Set_surname(globalid, SurnameBox.Text.ToString());
            db.Set_city(globalid, Convert.ToInt32(comboBox1.SelectedValue));
            db.Set_age(globalid, AgeBox.Text.ToString());
            this.Dispose();       
        }

        private void InitializeComponent()
        {
            this.SafeAndExit = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.SurnameBox = new System.Windows.Forms.TextBox();
            this.SecnameBox = new System.Windows.Forms.TextBox();
            this.AgeBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.AboutMeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SafeAndExit
            // 
            this.SafeAndExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SafeAndExit.Location = new System.Drawing.Point(801, 382);
            this.SafeAndExit.Margin = new System.Windows.Forms.Padding(2);
            this.SafeAndExit.Name = "SafeAndExit";
            this.SafeAndExit.Size = new System.Drawing.Size(171, 40);
            this.SafeAndExit.TabIndex = 18;
            this.SafeAndExit.Text = "Сохранить изменения";
            this.SafeAndExit.UseVisualStyleBackColor = true;
            this.SafeAndExit.Click += new System.EventHandler(this.SafeAndClose_Click);
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameBox.Location = new System.Drawing.Point(255, 10);
            this.NameBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(717, 37);
            this.NameBox.TabIndex = 19;
            // 
            // SurnameBox
            // 
            this.SurnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SurnameBox.Location = new System.Drawing.Point(255, 51);
            this.SurnameBox.Margin = new System.Windows.Forms.Padding(2);
            this.SurnameBox.Name = "SurnameBox";
            this.SurnameBox.Size = new System.Drawing.Size(717, 37);
            this.SurnameBox.TabIndex = 20;
            // 
            // SecnameBox
            // 
            this.SecnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecnameBox.Location = new System.Drawing.Point(255, 93);
            this.SecnameBox.Margin = new System.Windows.Forms.Padding(2);
            this.SecnameBox.Name = "SecnameBox";
            this.SecnameBox.Size = new System.Drawing.Size(717, 37);
            this.SecnameBox.TabIndex = 21;
            // 
            // AgeBox
            // 
            this.AgeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AgeBox.Location = new System.Drawing.Point(255, 134);
            this.AgeBox.Margin = new System.Windows.Forms.Padding(2);
            this.AgeBox.Name = "AgeBox";
            this.AgeBox.Size = new System.Drawing.Size(717, 37);
            this.AgeBox.TabIndex = 22;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordBox.Location = new System.Drawing.Point(255, 300);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(717, 37);
            this.PasswordBox.TabIndex = 27;
            // 
            // AboutMeBox
            // 
            this.AboutMeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AboutMeBox.Location = new System.Drawing.Point(255, 258);
            this.AboutMeBox.Margin = new System.Windows.Forms.Padding(2);
            this.AboutMeBox.Name = "AboutMeBox";
            this.AboutMeBox.Size = new System.Drawing.Size(717, 37);
            this.AboutMeBox.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 30);
            this.label1.TabIndex = 28;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 30);
            this.label2.TabIndex = 29;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 30);
            this.label3.TabIndex = 30;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 221);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 30);
            this.label4.TabIndex = 33;
            this.label4.Text = "Место жительства";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 180);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 30);
            this.label5.TabIndex = 32;
            this.label5.Text = "Пол";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(11, 141);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 30);
            this.label6.TabIndex = 31;
            this.label6.Text = "Возраст";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 304);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 30);
            this.label7.TabIndex = 36;
            this.label7.Text = "Пароль";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(9, 262);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 30);
            this.label8.TabIndex = 35;
            this.label8.Text = "О себе ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(255, 221);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 37;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(255, 180);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 38;
            // 
            // RenameProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 425);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.AboutMeBox);
            this.Controls.Add(this.AgeBox);
            this.Controls.Add(this.SecnameBox);
            this.Controls.Add(this.SurnameBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.SafeAndExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RenameProfile";
            this.Text = "RenanameProfile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button SafeAndExit;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox SurnameBox;
        private System.Windows.Forms.TextBox SecnameBox;
        private System.Windows.Forms.TextBox AgeBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox AboutMeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private System.Windows.Forms.Label label8;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
