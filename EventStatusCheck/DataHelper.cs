using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace EventStatusCheck
{
    class DataHelper
    {
        public MySqlConnection connection;
        public DataTracker dt = new DataTracker();

        public DataHelper()
        {
            String connectionInfo = "server=studmysql01.fhict.local;" +//the hera-server
                                    "database=dbi387149;" +
                                    "user id=dbi387149;" +
                                    "password=PROP;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public List<string> PresentVisitorsSelect()
        {

            String sql = "SELECT EventID FROM visitor WHERE CheckedIn = @checkedin";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@checkedin", "Yes");
            List<string> visitors = new List<string>();
            string present = "";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    present = Convert.ToString(reader["EventID"]);
                    visitors.Add(present);
                }
            }
            catch
            {

                visitors.Add("No present visitors");

            }
            finally
            {
                connection.Close();
            }

            return visitors;
        }

        public int TotalVisitorsCount()
        {

            String sql = "SELECT COUNT(EventID) FROM visitor";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int amount = 0;
            try
            {
                connection.Open();
                amount  = Convert.ToInt32(command.ExecuteScalar());
                
            }
            catch
            {

                amount = -1;
            }
            finally
            {
                connection.Close();
            }
            return amount;
        }

        public double TotalBalanceSum()
        {

            String sql = "SELECT SUM(Balance) FROM visitor";
            MySqlCommand command = new MySqlCommand(sql, connection);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

        public double TotalSpentPurchasedSum()
        {
            String sql = "SELECT SUM(Price) FROM eventitem WHERE ItemID IN(SELECT ItemID FROM purchaseditem)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

        public double TotalSpentLoanedSum()
        {

            String sql = "SELECT SUM(Price) FROM eventitem WHERE ItemID IN(SELECT ItemID FROM loaneditem)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

        public double TotalSpentReserved()
        {

            String sql = "SELECT SUM(Price) FROM reservation WHERE EventReservation = @eventreservation";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventreservation", "Yes");
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

        public int TotalReservedCount()
        {

            String sql = "SELECT COUNT(*) FROM reservation";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int amount = 0;
            try
            {
                connection.Open();
                amount = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                amount = -1;
            }
            finally
            {
                connection.Close();
            }
            return amount;
        }

        public double TotalMoneyMadeReserved()
        {

            String sql = "SELECT SUM(Price) FROM reservation";
            MySqlCommand command = new MySqlCommand(sql, connection);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

        public int TotalVisitorsSpots()
        {

            String sql = "SELECT SUM(NumberofPeople) FROM reservation";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

        public int AvgVisitorsSpots()
        {

            String sql = "SELECT AVG(NumberofPeople) FROM reservation";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

        public int AvgMadeSpots()
        {

            String sql = "SELECT AVG(Price) FROM reservation";
            MySqlCommand command = new MySqlCommand(sql, connection);
            int total = 0;
            try
            {
                connection.Open();
                total = Convert.ToInt32(command.ExecuteScalar());

            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

        public List<string> StandsSelect()
        {

            String sql = "SELECT Name FROM eventstand";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<string> shops = new List<string>();
            string shop = "";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    shop = Convert.ToString(reader["Name"]);
                    shops.Add(shop);
                }
            }
            catch
            {

                shops.Add("No Stands");

            }
            finally
            {
                connection.Close();
            }

            return shops;
        }


        public double ShopMoneyMadeSelect(string name)
        {

            String sql = "SELECT SUM(Price) FROM eventitem WHERE ItemID IN(SELECT ItemID FROM purchaseditem WHERE StandID IN(SELECT StandID FROM eventstand WHERE Name = @name))";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());
            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

        public double LoanStandMoneyMadeSelect(string name)
        {

            String sql = "SELECT SUM(Price) FROM eventitem WHERE ItemID IN(SELECT ItemID FROM loaneditem WHERE StandID IN(SELECT StandID FROM eventstand WHERE Name = @name))";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            double total = 0;
            try
            {
                connection.Open();
                total = Convert.ToDouble(command.ExecuteScalar());
            }
            catch
            {

                total = -1;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }


        public int AmountSoldSelect(string itemname)
        {

            String sql = "SELECT COUNT(*) FROM purchaseditem WHERE ItemID IN(SELECT ItemID FROM eventitem WHERE Itemname = @itemname)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@itemname", itemname);
            int amount = 0;
            try
            {
                connection.Open();
                amount = Convert.ToInt32(command.ExecuteScalar());
            }
            catch
            {

                amount = -1;
            }
            finally
            {
                connection.Close();
            }
            return amount;
        }
        
        public List<string> HistoryOrder(string eventid)
        {

            String sql = "SELECT Activity FROM trackinglog WHERE EventID = @eventid ORDER BY TrackNr";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", eventid);
            List<string> history = new List<string>();
            string activity = "";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    activity = Convert.ToString(reader["Activity"]);
                    if (activity == "eventcheckin")
                    {
                       history.Add(dt.AddCheckedinSelect());
                    }
                    else if (activity == "eventcheckout")
                    {
                       history.Add(dt.AddCheckedoutSelect());
                    }
                    else if (activity == "campcheckin")
                    {
                       history.Add(dt.AddCampCheckedinSelect());
                    }
                    else if (activity == "campcheckout")
                    {
                        history.Add(dt.AddCampCheckedoutSelect());
                    }
                    else if (activity == "purchase")
                    {
                        history.Add(dt.AddPurchaseSelect());
                    }
                    else if (activity == "loan")
                    {
                       history.Add(dt.AddLoanSelect());
                    }
                     else if (activity == "reservation")
                    {
                        history.Add(dt.AddReservationSelect());
                    }
                    
                } 
                     
            }
            catch
            {

                history.Add("Visitor has no history");

            }
            finally
            {
                connection.Close();
            }

            return history;
        }


    }
}

