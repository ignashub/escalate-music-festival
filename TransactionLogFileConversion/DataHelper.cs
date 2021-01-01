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
    class DataHelper
    {
        public MySqlConnection connection;
        DataTracker dt = new DataTracker();
        string startdate;
        string enddate;
        string deposits;
        string eventIDfromLog;
        string amountfromLog;
        string eventID;
        double amount;
        


        List<string> rofl = new List<string>();
        public DataHelper()
        {
            String connectionInfo = "server=studmysql01.fhict.local;" +//the hera-server
                                   "database=dbi387149;" +
                                   "user id=dbi387149;" +
                                   "password=PROP;" +
                                   "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public void Transaction(String filename)
        {            
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream("transactions.txt", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                
                rofl.Clear();
                startdate = sr.ReadLine();
                enddate = sr.ReadLine();
                deposits = sr.ReadLine();
                rofl.Add(startdate);
                rofl.Add(enddate);
                rofl.Add(deposits);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] linelist = line.Split(' ');
                    eventIDfromLog = linelist[0];
                    this.eventID = eventIDfromLog;
                    amountfromLog = linelist[1];
                    this.amount = Convert.ToDouble(amountfromLog);
                    double newbalance = this.amount + dt.BalanceSelect(this.eventID);
                    dt.AddNewBalance(this.eventID, newbalance);
                    rofl.Add(eventIDfromLog);
                    rofl.Add(amountfromLog);
                }

                //String sql = "UPDATE visitor SET Balance = @amount WHERE EventID = @eventid";
                ////String sql = "UPDATE transaction SET Startdate =  @startdate, Enddate = @enddate, Deposits = @deposits, EventID = @eventid, Amount = @amount  ";
                //MySqlCommand command = new MySqlCommand(sql, connection);
                ////command.Parameters.AddWithValue("@startdate", startdate);
                ////command.Parameters.AddWithValue("@enddate", enddate);
                ////command.Parameters.AddWithValue("@deposits", deposits);
                //command.Parameters.AddWithValue("@eventid", eventID);
                //command.Parameters.AddWithValue("@amount", amount);

                //connection.Open();
                //int nrOfRecordsChanged = command.ExecuteNonQuery();
                //return nrOfRecordsChanged;
                
                //String sql = "INSERT INTO visitor (EventID) VALUES (@eventid)";
                //MySqlCommand command = new MySqlCommand(sql, connection);
               
            }
            
            catch (IOException ex)
            {
                MessageBox.Show("something went wrong when reading file");
                //return -1;
            }
            finally
            {
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();
                //connection.Close();
            }
        }
        public List<string> ReturnTransactionlog()
        {
            return rofl;
        }


        public string GetEventId(string id)
        {
            String sql = "Select EventID FROM visitor WHERE EventID = @eventid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@eventid", id);
            string eventID = "";
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();//for SELECT


                while (reader.Read())
                {
                    eventID = Convert.ToString(reader["EventID"]);
                }
            }
            catch
            {

                eventID = "error";
            }
            finally
            {
                connection.Close();
            }
            return eventID;
        }




    }
}
