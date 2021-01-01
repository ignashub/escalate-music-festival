using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace TransactionLogFileConversion
{
    public partial class Form1 : Form
    {
        private DataHelper dh;
        public MySqlConnection connection;
        Timer timer = new Timer();
        int orgSize;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Transaction";
            dh = new DataHelper();
            orgSize = this.Width;

        }
        void timer_Tick(object sender, EventArgs e)
        {
            lbxLogs.Items.Clear();

            //MessageBox.Show("Database updated");
            dh.Transaction("transaction.txt");
            
            //lbxLogs.DataSource = dh.ReturnTransactionlog();
            for (int i = 0; i < dh.ReturnTransactionlog().Count; i++)
            {
                
                lbxLogs.Items.Add(dh.ReturnTransactionlog().ElementAt(i));
            }
        }
        private void btnStartLog_Click(object sender, EventArgs e)
        {
            
            timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            dh.Transaction("transaction.txt");

            for (int i = 0; i < dh.ReturnTransactionlog().Count; i++)
            {

                lbxLogs.Items.Add(dh.ReturnTransactionlog().ElementAt(i));
            }
            timer.Interval = (1000) * (108000);             // Timer will tick evert 10 seconds
            timer.Enabled = true;           // Enable the timer
            timer.Start();                              // Start the timer
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (this.Width == orgSize)
            {
                timer2.Interval = 15;
                timer2.Enabled = true;
                timer2.Tick += new System.EventHandler(timer2_Tick);
                rlbManual.Text = "• Click the button “Start” to start completing all visitor deposits.\n" +
                    "•  Click the button “Back” to return to main menu.";
            }
            else
            {
                timer3.Interval = 15;
                timer3.Enabled = true;
                timer3.Tick += new System.EventHandler(timer3_Tick);
            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            btnManual.Enabled = false;
            this.Width += 3;
            if (this.Width > 600)
            {
                timer2.Enabled = false;
                btnManual.Enabled = true;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            btnManual.Enabled = false;
            this.Width -= 3;
            if (this.Width == orgSize)
            {
                timer3.Enabled = false;
                btnManual.Enabled = true;
                rlbManual.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int l = Application.StartupPath.ToString().Length;
            System.Diagnostics.Process.Start(Application.StartupPath.ToString().Remove(l - 39) + @"\EscalateMusicFestival\bin\Debug\EscalateMusicFestival.exe");
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
