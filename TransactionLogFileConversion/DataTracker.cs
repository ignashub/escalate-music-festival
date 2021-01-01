using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace TransactionLogFileConversion
{

    class DataTracker
    {
        public MySqlConnection connection;
        double balanceLogFile;
        double amountLogFile;

        public DataTracker()
        {
            String connectionInfo = "server=studmysql01.fhict.local;" +//the hera-server
                                    "database=dbi387149;" +
                                    "user id=dbi387149;" +
                                    "password=PROP;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
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
                MySqlDataReader reader = command.ExecuteReader();//for SELECT


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
       

        public int AddNewBalance(string eventid, double newbalance)
        {

            String sql = "UPDATE visitor SET Balance = @balance WHERE EventID = @eventid";
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



    }
}
