using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace map
{
    public partial class UsrCab : Form
    {
        
        int globalid = 0;
        public UsrCab(int id)
        {
            dbworker db = new dbworker("95.104.192.212", "Liorkin", "lostdox561771", "Liorkin");
            InitializeComponent();
            this.Refresh();
            PlaceBox.ReadOnly = true;
            CityBox.ReadOnly = true;
            All_About.Text = $"{db.Usr_name(id)} {db.Usr_surname(id)} {db.Usr_secname(id)} {db.Usr_age(id)} {db.Usr_city(id)}";
            globalid = id;
            if (db.Usr_status(id) == 1)
            {
                status.Text = "Базовый";
                status.ReadOnly = true;
                
                BuyPrem.Enabled = true;
            }
            else if (db.Usr_status(id) == 2)
            {
                status.Text = "Арендодатель";
                status.ReadOnly = true;
                
                BuyPrem.Enabled = true;
            }
            else if (db.Usr_status(id) == 3)
            {
                status.Text = "Бизенес";
                status.ReadOnly = true;
                
                BuyPrem.Enabled = true;
            }
            List<string> places = new List<string>();
            List<string> adresses = new List<string>();
            places = db.selectattr(globalid);
            adresses = db.selectattraddress(globalid);
            for (int i = 0; i < db.selectattr(globalid).Count; i++)
                PlaceBox.Text += $"{places[i]} {adresses[i]}" + Environment.NewLine;
            List<string> citys = new List<string>();
            citys = db.selectcity(globalid);
            for (int i = 0; i < db.selectcity(globalid).Count; i++)
                CityBox.Text += citys[i] + Environment.NewLine;
        }
        private void UsrCab_Load(object sender, EventArgs e)
        {

        }

        private void RenUser_Click(object sender, EventArgs e)
        {
            RenameProfile shitass = new RenameProfile(globalid);
            shitass.Show();
            this.Dispose();
        }
        private void offer_obj_Click(object sender, EventArgs e)
        {
            
            //AttrListBox.GetItemChecked()
        }

        private void BuyPrem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            BuyForm window = new BuyForm(globalid);
            window.ShowDialog();
        }
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.status = new System.Windows.Forms.TextBox();
            this.All_About = new System.Windows.Forms.Label();
            this.RenUser = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PlaceBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CityBox = new System.Windows.Forms.TextBox();
            this.BuyPrem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.status);
            this.panel1.Location = new System.Drawing.Point(708, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 81);
            this.panel1.TabIndex = 3;
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.SystemColors.Control;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status.Location = new System.Drawing.Point(2, 2);
            this.status.Margin = new System.Windows.Forms.Padding(2);
            this.status.Multiline = true;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(205, 77);
            this.status.TabIndex = 0;
            this.status.TabStop = false;
            // 
            // All_About
            // 
            this.All_About.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.All_About.AutoSize = true;
            this.All_About.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.All_About.Location = new System.Drawing.Point(13, 13);
            this.All_About.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.All_About.Name = "All_About";
            this.All_About.Size = new System.Drawing.Size(430, 37);
            this.All_About.TabIndex = 6;
            this.All_About.Text = "Информация о пользователе";
            // 
            // RenUser
            // 
            this.RenUser.Location = new System.Drawing.Point(767, 376);
            this.RenUser.Margin = new System.Windows.Forms.Padding(2);
            this.RenUser.Name = "RenUser";
            this.RenUser.Size = new System.Drawing.Size(150, 37);
            this.RenUser.TabIndex = 7;
            this.RenUser.Text = "Редактировать профиль";
            this.RenUser.UseVisualStyleBackColor = true;
            this.RenUser.Click += new System.EventHandler(this.RenUser_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Location = new System.Drawing.Point(11, 89);
            this.TabControl.Margin = new System.Windows.Forms.Padding(2);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(513, 324);
            this.TabControl.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PlaceBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(505, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Места";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PlaceBox
            // 
            this.PlaceBox.BackColor = System.Drawing.SystemColors.Control;
            this.PlaceBox.Location = new System.Drawing.Point(5, 5);
            this.PlaceBox.Margin = new System.Windows.Forms.Padding(2);
            this.PlaceBox.Multiline = true;
            this.PlaceBox.Name = "PlaceBox";
            this.PlaceBox.Size = new System.Drawing.Size(498, 292);
            this.PlaceBox.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CityBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(505, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Города";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CityBox
            // 
            this.CityBox.BackColor = System.Drawing.SystemColors.Control;
            this.CityBox.Location = new System.Drawing.Point(5, 5);
            this.CityBox.Margin = new System.Windows.Forms.Padding(2);
            this.CityBox.Multiline = true;
            this.CityBox.Name = "CityBox";
            this.CityBox.Size = new System.Drawing.Size(498, 292);
            this.CityBox.TabIndex = 0;
            // 
            // BuyPrem
            // 
            this.BuyPrem.Location = new System.Drawing.Point(764, 89);
            this.BuyPrem.Name = "BuyPrem";
            this.BuyPrem.Size = new System.Drawing.Size(150, 37);
            this.BuyPrem.TabIndex = 10;
            this.BuyPrem.Text = "Оплатить подписку";
            this.BuyPrem.UseVisualStyleBackColor = true;
            this.BuyPrem.Click += new System.EventHandler(this.BuyPrem_Click);
            // 
            // UsrCab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 424);
            this.Controls.Add(this.All_About);
            this.Controls.Add(this.BuyPrem);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.RenUser);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UsrCab";
            this.Text = "UsrCab";
            this.Load += new System.EventHandler(this.UsrCab_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label All_About;
        private System.Windows.Forms.Button RenUser;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BuyPrem;
        private System.Windows.Forms.TextBox CityBox;
        private System.Windows.Forms.TextBox PlaceBox;

    }
}