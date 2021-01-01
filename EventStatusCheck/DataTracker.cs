using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EventStatusCheck
{
    class DataTracker
    {
        public MySqlConnection connection;

        public DataTracker()
        {
            String connectionInfo = "server=studmysql01.fhict.local;" +//the hera-server
                                   "database=dbi387149;" +
                                   "user id=dbi387149;" +
                                   "password=PROP;" +
                                   "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public string AddCheckedinSelect()
        {

            String sql = "SELECT * FROM trackinglog WHERE EventID IN(SELECT EventID FROM visitor) ORDER BY TrackNr";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string checkedin = "";
           
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    checkedin = "Checked into Event";
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

        public string AddCheckedoutSelect()
        {

            String sql = "SELECT * FROM trackinglog WHERE EventID IN(SELECT EventID FROM visitor) ORDER BY TrackNr";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string checkedout = "";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    checkedout = "Checked out of Event";
                }
            }
            catch
            {
                checkedout = "Error";
            }
            finally
            {
                connection.Close();
            }
            return checkedout;
        }

        public string AddCampCheckedinSelect()
        {

            String sql = "SELECT * FROM trackinglog WHERE EventID IN(SELECT EventID FROM reservation WHERE VisitorCheckedIn = @checkedin) ORDER BY TrackNr";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@checkedin", "Yes");
            string checkedin = "";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    checkedin = "Checked into Camping Site";
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

        public string AddCampCheckedoutSelect()
        {

            String sql = "SELECT * FROM trackinglog WHERE EventID IN(SELECT EventID FROM reservation WHERE VisitorCheckedIn = @checkedin) ORDER BY TrackNr";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@checkedin", "No");
            string checkedout = "";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    checkedout = "Checked out of Camping Site";
                }
            }
            catch
            {
                checkedout = "Error";
            }
            finally
            {
                connection.Close();
            }
            return checkedout;
        }

        public string AddPurchaseSelect()
        {

            String sql = "SELECT * FROM trackinglog WHERE EventID IN(SELECT EventID FROM purchaseditem) ORDER BY TrackNr";
            MySqlCommand command = new MySqlCommand(sql, connection); 
            string purchase = "";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    purchase = "Purchased an Item";
                }
            }
            catch
            {
                purchase = "Error";
            }
            finally
            {
                connection.Close();
            }
            return purchase;
        }

        public string AddLoanSelect()
        {

            String sql = "SELECT * FROM trackinglog WHERE EventID IN(SELECT EventID FROM loaneditem) ORDER BY TrackNr";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string loan = "";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    loan = "Loaned an Item";
                }
            }
            catch
            {
                loan = "Error";
            }
            finally
            {
                connection.Close();
            }
            return loan;
        }

        public string AddReservationSelect()
        {

            String sql = "SELECT * FROM trackinglog WHERE EventID IN(SELECT EventID FROM reservation) ORDER BY TrackNr";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string reservation = "";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    reservation = "Made a reservation at the Camping Site";
                }
            }
            catch
            {
                reservation = "Error";
            }
            finally
            {
                connection.Close();
            }
            return reservation;
        }

    }
}
