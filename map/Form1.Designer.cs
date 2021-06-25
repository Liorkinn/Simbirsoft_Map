using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace map
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        #region INI
        static public void InitializeComp(Control T)
        {
            System.Collections.Generic.List<string> AAA = new System.Collections.Generic.List<string>();
            AAA.Add("https://media1.tenor.com/images/867eba84d4e5f970ee679cefb7cfbe59/tenor.gif?itemid=5438490");// макиус
            AAA.Add("https://i.pinimg.com/736x/51/34/28/51342843659f45333e854950e67b30b1.jpg");// сансетус
            AAA.Add("https://media.discordapp.net/attachments/683636109867352064/857678253073235998/ZQSppIDMqCw.jpg?width=448&height=676");// курисус
            AAA.Add("https://i.redd.it/tq09zhrao9l51.jpg");// руисус

            System.Windows.Forms.PictureBox pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox2.Size = new System.Drawing.Size(100, 150);

            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            System.Random A = new System.Random();
            pictureBox2.LoadAsync(AAA[A.Next(AAA.Count)]);

            T.Controls.Add(pictureBox2);
            pictureBox2.BringToFront();
        }
        #endregion

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(360, 288);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(356, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите город";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(498, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Поехали";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(0, 1);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(972, 462);
            this.gMap.TabIndex = 3;
            this.gMap.Zoom = 0D;
            this.gMap.Load += new System.EventHandler(this.gMap_Load);
            this.gMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseDoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(897, 435);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 440);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Сохранить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Скриншот карты";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Питание";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox9);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(978, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 90);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтры";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(179, 49);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(74, 21);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Афиша";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(96, 22);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(193, 21);
            this.checkBox6.TabIndex = 11;
            this.checkBox6.Text = "Достопримечательности";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.Click += new System.EventHandler(this.checkBox6_Click);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox9.Location = new System.Drawing.Point(81, 49);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(92, 21);
            this.checkBox9.TabIndex = 12;
            this.checkBox9.Text = "Квартиры";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.Click += new System.EventHandler(this.checkBox9_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(6, 49);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(69, 21);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.Text = "Отели";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.Click += new System.EventHandler(this.checkBox5_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 478);
            this.panel1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(978, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 614);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Список меток";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 469);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(416, 153);
            this.textBox1.TabIndex = 12;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(434, 469);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(328, 157);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1316, 635);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.gMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private TextBox textBox1;
        private PictureBox pictureBox2;
    }
}

