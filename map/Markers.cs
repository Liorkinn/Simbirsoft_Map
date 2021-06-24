using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace map
{
    public partial class Markers : Form
    {
        double X, Y;
        dbworker db = new dbworker("95.104.192.212", "Liorkin", "lostdox561771", "Liorkin");
        public Markers(double x, double y)
        {
            InitializeComponent();
            X = y;
            Y = x;
           comboBox1.DataSource = db.getTableInfo($"SELECT `id`, `Name` FROM `Liorkin`.`Place` where Rate_id = {User.lvl}");
           comboBox1.DisplayMember = "Name";
           comboBox1.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.download(Convert.ToInt32(comboBox1.SelectedValue), User.City_id, textBox1.Text, textBox2.Text, textBox3.Text, X, Y);
            this.Close();
        }
    }
}
