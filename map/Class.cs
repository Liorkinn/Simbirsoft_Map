﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace map
{
    static class Class
    {
        
    }

    static class User
    {
        static public int id = 1;
        static public int lvl = 3;
        static public int City_id = 1;  
    }

    static class bd_CON_VAL
    {
        static public string server = "95.104.192.212";
        static public string user = "Liorkin";
        static public string pass = "lostdox561771";
    }

    public struct Coord
    {
        public int id;
        public double x;
        public double y;
    }
}
