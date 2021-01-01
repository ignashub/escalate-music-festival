using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End_of_Event
{
    class DataHelper
    {

        public MySqlConnection connection;

        public DataHelper()
        {
            String connectionInfo = "server=studmysql01.fhict.local;" +//the hera-server
                                     "database=dbi387149;" +
                                     "user id=dbi387149;" +
                                     "password=PROP;" +
                                     "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }
        public int Invalid(string eventid)
        {
            string sql = "UPDATE visitor SET Valid = 'No' WHERE EventId = @eventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);

            try
            {
                connection.Open();
                int nrOfRecordsChanged = command.ExecuteNonQuery();
                return nrOfRecordsChanged;
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }
        public int Returned(string eventid)
        {
            string sql = "UPDATE loaneditem SET Returned = 'Yes' WHERE EventId = @eventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);

            try
            {
                connection.Open();
                int nrOfRecordsChanged = command.ExecuteNonQuery();
                return nrOfRecordsChanged;
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }
        public double GetBalance(string eventid)
        {
            String sql = "SELECT Balance FROM visitor WHERE EventID = @eventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            double bal = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    bal = Convert.ToDouble(reader["Balance"]);
                }
            }
            catch
            {
                bal = -1;
            }
            finally
            {
                connection.Close();
            }
            return bal;
        }
        public List<List<string>> Items(string eventid)
        {
            List<List<string>> inf = new List<List<string>>();
            string IName = "";
            string Price = "";
            string SName = "";
            string sql = "SELECT Itemname, Price, Name FROM loaneditem i JOIN eventstand es ON i.StandID = es.StandID JOIN eventitem ei ON i.ItemID = ei.ItemID WHERE i.EventID = @eventid AND i.Returned = 'No'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IName = Convert.ToString(reader["Itemname"]);
                    Price = Convert.ToString(reader["Price"]);
                    SName = Convert.ToString(reader["Name"]);
                    inf.Add(new List<string> {IName,Price,SName });
                }
            }
            catch
            {
                inf = null;
            }
            finally
            {
                connection.Close();
            }
            return inf;
        }
    }
}
