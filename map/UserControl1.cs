using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Common;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
namespace map
{
    public partial class UserControl1 : UserControl
    {
        GMapControl Search;
        Coord Cord;
        int id;
        dbworker db = new dbworker(bd_CON_VAL.server, bd_CON_VAL.user, bd_CON_VAL.pass, "Liorkin");
        public UserControl1(Coord iD, Control G)
        {
            Cord = iD;
            List<string> a = db.A(iD.id);
            InitializeComponent(a[0], a[1], a[2]);
            id = Convert.ToInt32(a[3]);
            this.Dock = DockStyle.Top;
            CheckBox1.Checked = db.Visited_Check(id);
            Search = (GMapControl)G;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search.Position = new PointLatLng(Cord.x, Cord.y);
            Search.Zoom = 17;
        }
        private void CheckBox1_Click(object sender, EventArgs e)
        {
            db.visited(id, CheckBox1.Checked);
        }
    }
}
