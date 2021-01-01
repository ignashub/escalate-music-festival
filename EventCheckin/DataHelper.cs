using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EventCheckin
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

        public int AddVisitor(string eventid)
        {  

          String sql = "INSERT INTO visitor (EventID) VALUES (@eventid)";
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

        public int AddNewVisitorID(string oldeventid, string neweventid)
        {

            String sql = "UPDATE visitor SET EventId = @neweventid, CheckedIn = @checkedin WHERE EventId = @oldeventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@oldeventid", oldeventid);
            command.Parameters.AddWithValue("@checkedin", "Yes");
            command.Parameters.AddWithValue("@neweventid", neweventid);

            try
            {
                connection.Open();
                int nrOfRecordsChanged = command.ExecuteNonQuery();
                return nrOfRecordsChanged;
                // return 1;

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

        public int Checkout(string eventid)
        {

            String sql = "UPDATE visitor SET CheckedIn = @checkedinafter WHERE EventId = @eventid AND CheckedIn = @checkedinbefore";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            command.Parameters.AddWithValue("@checkedinafter", "No");
            command.Parameters.AddWithValue("@checkedinbefore", "Yes");


            try
            {
                connection.Open();
                int nrOfRecordsChanged = command.ExecuteNonQuery();
                return nrOfRecordsChanged;
                // return 1;

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

        public string CheckedinCheckoutSelect(string eventid)
        {

            String sql = "SELECT CheckedIn FROM visitor WHERE EventID = @eventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            string checkedin = "";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    checkedin = Convert.ToString(reader["CheckedIn"]);
                }
            }
            catch
            {
                //  Messagebox.show("error while loading the students"); 
                checkedin = "Error";
            }
            finally
            {
                connection.Close();
            }
            return checkedin;
        }



        public int Checkin(string eventid)
        {

            String sql = "UPDATE visitor SET CheckedIn = @checkedinafter WHERE EventId = @eventid AND CheckedIn = @checkedinbefore";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            command.Parameters.AddWithValue("@checkedinafter", "Yes");
            command.Parameters.AddWithValue("@checkedinbefore", "No");


            try
            {
                connection.Open();
                int nrOfRecordsChanged = command.ExecuteNonQuery();
                return nrOfRecordsChanged;
                // return 1;

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

        public int AddLogCheckedIn(string eventid)
        {

            String sql = "INSERT INTO trackinglog (EventID,Activity) VALUES (@eventid,@activity)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            command.Parameters.AddWithValue("@activity", "eventcheckin");

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

        public int AddLogCheckedOut(string eventid)
        {

            String sql = "INSERT INTO trackinglog (EventID,Activity) VALUES (@eventid,@activity)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            command.Parameters.AddWithValue("@activity", "eventcheckout");

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


    }
}

   