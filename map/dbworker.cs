using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Drawing;

namespace map
{

    class dbworker
    {


        MySqlConnection Connection;
        MySqlConnectionStringBuilder Connect = new MySqlConnectionStringBuilder();

        public dbworker(string server, string user, string pass, string database) //Database Worker
        {
            Connect.Server = server;
            Connect.UserID = user;
            Connect.Password = pass;
            Connect.Port = 3306;
            Connect.Database = database;
            Connect.CharacterSet = "utf8";
            Connection = new MySqlConnection(Connect.ConnectionString);
        }

        public List<String> A(int id)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT NAME, adress, information FROM  Attractions WHERE Coordinats_Place_id = " + id + ";";
            List<String> bd = new List<String>();
            try
            {
                Connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bd.Add(reader.GetString(0));
                        bd.Add(reader.GetString(1));
                        bd.Add(reader.GetString(2));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { Connection.Close(); }
            return bd;
        }

        public PointLatLng Cordinates(int id) //стартовая метка города
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT Coordinates_City.X,Coordinates_City.Y FROM Coordinates_City WHERE City_id = " + id + ";";
            List<Coord> bd = new List<Coord>();
            try
            {
                Connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Coord databd = new Coord
                        {
                            x = reader.GetDouble(0),
                            y = reader.GetDouble(1),
                        };
                        bd.Add(databd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { Connection.Close(); }

            return new PointLatLng(bd[0].x, bd[0].y);


        }

        public List<Coord> Food(int id) //метки для еды
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT X, Y, id FROM Coordinats_Place WHERE Place_id = "+ id.ToString() +";";
            List<Coord> bd = new List<Coord>();
            try
            {
                Connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Coord databd = new Coord
                        {
                            id = reader.GetInt32(2),
                            x = reader.GetDouble(0),
                            y = reader.GetDouble(1),
                        };
                        bd.Add(databd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                Connection.Close();
            }
            return bd;
        }

        //public List<Coord> Place() //метки для мест
        //{
        //    MySqlCommand command = Connection.CreateCommand();
        //    command.CommandText = "SELECT X, Y FROM Coordinats_Place WHERE Place_id = 2;";
        //    List<Coord> bd = new List<Coord>();
        //    try
        //    {
        //        Connection.Open();
        //        using (DbDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Coord databd = new Coord
        //                {
        //                    id = reader.GetInt32(2),
        //                    x = reader.GetDouble(0),
        //                    y = reader.GetDouble(1),
        //                };
        //                bd.Add(databd);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {

        //        Connection.Close();
        //    }
        //    return bd;
        //}

        //public List<Coord> Flat() //метки для квартиры
        //{
        //    MySqlCommand command = Connection.CreateCommand();
        //    command.CommandText = "SELECT X, Y FROM Coordinats_Place WHERE Place_id = 4;";
        //    List<Coord> bd = new List<Coord>();
        //    try
        //    {
        //        Connection.Open();
        //        using (DbDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Coord databd = new Coord
        //                {
        //                    id = reader.GetInt32(2),
        //                    x = reader.GetDouble(0),
        //                    y = reader.GetDouble(1),
        //                };
        //                bd.Add(databd);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {

        //        Connection.Close();
        //    }
        //    return bd;
        //}

        //public List<Coord> Hotel() //метки для гостиниц
        //{
        //    MySqlCommand command = Connection.CreateCommand();
        //    command.CommandText = "SELECT X, Y FROM Coordinats_Place WHERE Place_id = 3";
        //    List<Coord> bd = new List<Coord>();
        //    try
        //    {
        //        Connection.Open();
        //        using (DbDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Coord databd = new Coord
        //                {
        //                    x = reader.GetDouble(0),
        //                    y = reader.GetDouble(1),
        //                };
        //                bd.Add(databd);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {

        //        Connection.Close();
        //    }
        //    return bd;
        //}

        //public List<Coord> Poster() //метки для афишы
        //{
        //    MySqlCommand command = Connection.CreateCommand();
        //    command.CommandText = "SELECT X, Y FROM Coordinats_Place WHERE Place_id = 5";
        //    List<Coord> bd = new List<Coord>();
        //    try
        //    {
        //        Connection.Open();
        //        using (DbDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Coord databd = new Coord
        //                {
        //                    x = reader.GetDouble(0),
        //                    y = reader.GetDouble(1),
        //                };
        //                bd.Add(databd);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {

        //        Connection.Close();
        //    }
        //    return bd;
        //}
        public DataTable getTableInfo(string query)//Combobox_worker
        {
            Connection.Open();
            MySqlCommand queryExecute = new MySqlCommand(query, Connection);
            DataTable ass = new DataTable();
            ass.Load(queryExecute.ExecuteReader());
            Connection.Close();
            return ass;
        }


    }
}
