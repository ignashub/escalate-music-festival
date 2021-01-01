using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidget22;
using Phidget22.Events;

namespace LoanStands
{
    public partial class Form1 : Form
    {
        private RFID myRFIDReader;
        private DataHelper dh;
        private string tag = "";
        int orgSize;
        public Form1()
        {
            InitializeComponent();
            orgSize = this.Width;
            this.Text = "LoanStand";
            dh = new DataHelper();
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(Attached);
                myRFIDReader.Detach += new DetachEventHandler(Detached);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagID);


                lbxIDscan.Items.Add("Startup successfull");

            }
            catch (PhidgetException) { lbxIDscan.Items.Add("Error at startup"); }
        }

        public void Attached(object sender, AttachEventArgs e) //for when RFID is plugged in
        {
            lbxIDscan.Items.Add("RFID Reader attached");
        }

        public void Detached(object sender, DetachEventArgs e) //for when RFID is unplugged
        {
            lbxIDscan.Items.Add("RFID Reader detached");
        }

        public void ReadTagID(object sender, RFIDTagEventArgs e)
        {
            //lblCopiedID.Text = e.Tag;
            this.tag = e.Tag;
            lbxIDscan.Items.Clear();
            lbxIDscan.Items.Add("Scanned ID: " + e.Tag);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblLoan_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                myRFIDReader.Open();
                lbxIDscan.Items.Add("Connection opened");

            }
            catch (PhidgetException)
            {
                lbxIDscan.Items.Clear();
                lbxIDscan.Items.Add("Connection failed:Please try again");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            myRFIDReader.Close();
            lbxIDscan.Items.Add("Connection closed");
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            if (dh.BalanceSelect(this.tag) > dh.PriceSelect(Convert.ToInt32(tbItemID.Text)))
            {

                double change = dh.BalanceSelect(this.tag) - dh.PriceSelect(Convert.ToInt32(tbItemID.Text));
                int catchnr = dh.AddLoanedItem(this.tag, Convert.ToInt32(tbLoanStandID.Text), Convert.ToInt32(tbItemID.Text));
                int catchnr2 = dh.AddNewBalance(this.tag, change);
                if (catchnr > 0 && catchnr2 > 0)
                {


                    lblLoan.Text = "Successfully loaned";
                    dh.AddLoan(this.tag);

                }
                else
                {
                    lblLoan.Text = "Payment Failed";
                }

            }
            else if (dh.BalanceSelect(this.tag) < dh.PriceSelect(Convert.ToInt32(tbItemID.Text)))
            {
                lblLoan.Text = "Not Enough Funds";
            }
            else
            {
                lblLoan.Text = "Error Fetching numbers for payment";
            }

        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (this.Width == orgSize)
            {
                timer1.Interval = 15;
                timer1.Enabled = true;
                timer1.Tick += new System.EventHandler(timer1_Tick);
                rlbManual.Text = "• Click the button “Open Connection” to connect the RFID scanner to the application. This must be done before using the RFID scanner.\n" +
                    "•  Click the button “Close Connection” to disconnect the RFID scanner from the application. \n" +
                    "•  Using the RFID Scanner, scan the visitor’s bracelet then enter your loan stand’s ID in the upper textbox and enter the item’s ID in the lower textbox, Click the button “Loan” to complete the payment. You will be notified of the situation of the payment.\n" +
                    "•  Click the button “Back” to comeback to main menu.";
            }
            else
            {
                timer2.Interval = 15;
                timer2.Enabled = true;
                timer2.Tick += new System.EventHandler(timer2_Tick);
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnManual.Enabled = false;
            this.Width += 3;
            if (this.Width > 1002)
            {
                timer1.Enabled = false;
                btnManual.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            btnManual.Enabled = false;
            this.Width -= 3;
            if (this.Width == orgSize)
            {
                timer2.Enabled = false;
                btnManual.Enabled = true;
                rlbManual.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int l = Application.StartupPath.ToString().Length;
            System.Diagnostics.Process.Start(Application.StartupPath.ToString().Remove(l - 21) + @"\EscalateMusicFestival\bin\Debug\EscalateMusicFestival.exe");
            this.Close();
        }
    }
}
