using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CampCheckin_Checkout
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

        public int Checkout(string eventid)
        {

            String sql = "UPDATE reservation SET VisitorCheckedIn = @checkedinafter WHERE EventId = @eventid AND VisitorCheckedIn = @checkedinbefore";
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

        public bool CheckReservationSelect(string eventid)
        {

            String sql = "SELECT * FROM reservation WHERE EventID = @eventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            bool reserved =  false;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    reserved = true;
                   
                }
                return reserved;
            }
            catch
            { 
               
                return false;
            }
            finally
            {
                connection.Close();
            }
           
        }

        public string CheckedinCheckoutSelect(string eventid)
        {

            String sql = "SELECT VisitorCheckedIn FROM reservation WHERE EventID = @eventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            string checkedin = "";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    checkedin = Convert.ToString(reader["VisitorCheckedIn"]);
                }
            }
            catch
            {
                
                checkedin = "Error";
            }
            finally
            {
                connection.Close();
            }
            return checkedin;
        }

        
        public List<string> NonReservedSelect()
        {

            String sql = "SELECT Name FROM campingspot WHERE CampingSpotID NOT IN (SELECT CampingSpotID FROM reservation)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<string> nonres = new List<string>();
            string open = "";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    open = Convert.ToString(reader["Name"]);
                    nonres.Add(open);
                }
            }
            catch
            {
                
                 nonres.Add("No Free Camping Spots");
                
            }
            finally
            {
                connection.Close();
            }
           
            return nonres;
        }

        public int CampingCapacitySelect(string name)
        {

            String sql = "SELECT Capacity FROM campingspot WHERE Name = @name";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            int capacity = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    capacity = Convert.ToInt32(reader["Capacity"]);
                }
            }
            catch
            {
                
                capacity = -1;
            }
            finally
            {
                connection.Close();
            }
            return capacity;
        }

        public double PricePerPersonSelect(string name)
        {

            String sql = "SELECT PricePerPerson FROM campingspot WHERE Name = @name";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            double priceperperson = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    priceperperson = Convert.ToInt32(reader["PricePerPerson"]);
                }
            }
            catch
            {

                priceperperson = -1;
            }
            finally
            {
                connection.Close();
            }
            return priceperperson;
        }


        public int Checkin(string eventid)
        {

            String sql = "UPDATE reservation SET VisitorCheckedIn = @checkedinafter WHERE EventId = @eventid AND VisitorCheckedIn = @checkedinbefore";
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

        public double BalanceSelect(string eventid)
        {

            String sql = "SELECT Balance FROM visitor WHERE EventID = @eventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            double balance = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    balance = Convert.ToDouble(reader["Balance"]);
                }
            }
            catch
            {

                balance = -1;
            }
            finally
            {
                connection.Close();
            }
            return balance;
        }

        public int CampingIDSelect(string name)
        {

            String sql = "SELECT CampingSpotID FROM campingspot WHERE Name = @name";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            int capacity = 0;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    capacity = Convert.ToInt32(reader["CampingSpotID"]);
                }
            }
            catch
            {

                capacity = -1;
            }
            finally
            {
                connection.Close();
            }
            return capacity;
        }

        public int AddReservation(int campingspotid,string eventid, int numberofpeople , double price)
        {

            String sql = "INSERT INTO reservation (CampingSpotID,EventID,NumberofPeople,Price,EventReservation) VALUES (@campingspotid,@eventid,@numberofpeople,@price,@eventreservation)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@campingspotid", campingspotid);
            command.Parameters.AddWithValue("@eventid", eventid);
            command.Parameters.AddWithValue("@numberofpeople", numberofpeople);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@eventreservation", "Yes");
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


        public int AddNewBalance(string eventid, double newbalance)
        {

            String sql = "UPDATE visitor SET Balance = @balance WHERE EventId = @eventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@balance", newbalance);
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

        public int AddLogCheckedIn(string eventid)
        {

            String sql = "INSERT INTO trackinglog (EventID,Activity) VALUES (@eventid,@activity)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            command.Parameters.AddWithValue("@activity", "campcheckin");

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
            command.Parameters.AddWithValue("@activity", "campcheckout");

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


        public int AddLogReservation(string eventid)
        {

            String sql = "INSERT INTO trackinglog (EventID,Activity) VALUES (@eventid,@activity)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            command.Parameters.AddWithValue("@activity", "reservation");

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
