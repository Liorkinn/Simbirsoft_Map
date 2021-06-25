
namespace map
{
    partial class UserControl1
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent(string name, string adress, string info)
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = name;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(135, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = adress;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 45);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(297, 126);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = info;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Показать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CheckBox1
            // 
            this.CheckBox1.Location = new System.Drawing.Point(147, 16);
            this.CheckBox1.Name = "button2";
            this.CheckBox1.Size = new System.Drawing.Size(75, 23);
            this.CheckBox1.TabIndex = 3;
            this.CheckBox1.Text = "я тут был";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.Click += new System.EventHandler(this.CheckBox1_Click);
            // 
            // UserControl1
            // 
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(317, 185);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
