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
            command.CommandText = "SELECT NAME, adress, information, id FROM  Attractions WHERE Coordinats_Place_id = " + id + ";";
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
                        bd.Add(reader.GetString(3));
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

        public List<Coord> Food(int id) //метки
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT X, Y, id FROM a WHERE Place_id = "+ id.ToString() +" and City_id = "+ User.City_id + ";";
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

        public void visited(int Attraction_id, bool da)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = da ? "INSERT INTO `Liorkin`.`Visited` (`User_id`, `Attraction_id`) VALUES(?User.id, ?Attraction_id);" : "DELETE FROM `Liorkin`.`Visited` WHERE  `User_id`= ?User.id AND Attraction_id =?Attraction_id;";
            //command.CommandText = "INSERT INTO `Liorkin`.`Visited` (`User_id`, `Attraction_id`) VALUES(?User.id, ?Attraction_id);";
            command.Parameters.Add("?User.id", MySqlDbType.Int32).Value = User.id;
            command.Parameters.Add("?Attraction_id", MySqlDbType.Int32).Value = Attraction_id;
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool Visited_Check(int Attraction_id)
        {          
            MySqlCommand command = Connection.CreateCommand();
            // command.CommandText = "INSERT INTO info(name, surname, otch) VALUES(?name, ?surname, ?otch)";
            command.CommandText = "SELECT COUNT(*) FROM Visited WHERE User_id = "+ User.id + " AND Attraction_id = " + Attraction_id + ";";
            bool check = false;
            try
            {
                Connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        check = Convert.ToBoolean(reader.GetInt32(0));
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
            return check;
        }


    
        public void download(int Place_id, int City_id, string name, string adress, string info, double x, double y)
        {

            MySqlCommand command = Connection.CreateCommand();

            // command.CommandText = "INSERT INTO info(name, surname, otch) VALUES(?name, ?surname, ?otch)";
            command.CommandText = " INSERT INTO `Liorkin`.`Coordinats_Place` (`Place_id`, `X`, `Y`) VALUES(?Place_id, ?x, ?y);";
           
            command.Parameters.Add("?Place_id", MySqlDbType.Int32).Value = Place_id;
            command.Parameters.Add("?X", MySqlDbType.Double).Value = x;
            command.Parameters.Add("?Y", MySqlDbType.Double).Value = y;
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            command = Connection.CreateCommand();
            /////////////////////////////////////////////////////////////
            command.CommandText = "INSERT INTO `Liorkin`.`Attractions` (`User_id`, `Place_id`, `City_id`, `Coordinats_Place_id`, `Name`, `Adress`, `Information`) VALUES (?User_id, ?Place_id, ?City_id, (SELECT MAX(id) FROM `Liorkin`.`Coordinats_Place`), ?Name, ?Adress, ?Information);";

            command.Parameters.Add("?User_id", MySqlDbType.Int32).Value = User.id;
            command.Parameters.Add("?Place_id", MySqlDbType.Int32).Value = Place_id;
            command.Parameters.Add("?City_id", MySqlDbType.Int32).Value = User.City_id;
            command.Parameters.Add("?Name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("?Adress", MySqlDbType.VarChar).Value = adress;
            command.Parameters.Add("?Information", MySqlDbType.VarChar).Value = info;



            try
            {
                Connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

        }

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
