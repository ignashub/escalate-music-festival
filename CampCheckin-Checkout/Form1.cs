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

namespace CampCheckin_Checkout
{
    public partial class Form1 : Form
    {
        private RFID myRFIDReader;
        private DataHelper dh;
        private string tag = "";
        private double total = 0;
        int orgSize;
        public Form1()
        {
            InitializeComponent();
            orgSize = this.Width;
            this.Text = "Camp CheckIn - CheckOut";
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
            tbAmountofPersons.Text = Convert.ToString(0);
            
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            myRFIDReader.Close();
            lbxIDscan.Items.Add("Connection closed");
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
            this.tag = e.Tag;
            if(dh.CheckReservationSelect(e.Tag) == true)
            {
                lbxIDscan.Items.Clear();
                lbxIDscan.Items.Add("Checked in Visitor: " + e.Tag);
                dh.AddLogCheckedIn(e.Tag);
                if (dh.CheckedinCheckoutSelect(e.Tag) == "No")
                {
                    int catchnr2 = dh.Checkin(e.Tag);
                    if (catchnr2 > 0)
                    {

                        lbxIDscan.Items.Clear();
                        lbxIDscan.Items.Add("Checked In Visitor: " + e.Tag);
                        dh.AddLogCheckedIn(e.Tag);

                        // lblCheckincheckout.Text = "Checked in Visitor: " + e.Tag;


                    }
                    else
                    {
                        // lblCheckincheckout.Text = "Check in failed";
                        lbxIDscan.Items.Add("Checked In Failed" /*+ e.Tag*/);

                    }

                }
                else if (dh.CheckedinCheckoutSelect(e.Tag) == "Yes")
                {
                    int catchnr2 = dh.Checkout(e.Tag);
                    if (catchnr2 > 0)
                    {

                        lbxIDscan.Items.Clear();
                        lbxIDscan.Items.Add("Checked Out Visitor: " + e.Tag);
                        dh.AddLogCheckedOut(e.Tag);
                        // lblCheckincheckout.Text = "Checked out Visitor: " + e.Tag;


                    }
                    else
                    {
                        // lblCheckincheckout.Text = "Checkout failed";
                        lbxIDscan.Items.Add("Checked Out Failed" /*+ e.Tag*/);
                    }

                }

            }
            else
            {

                lbxIDscan.Items.Clear();
                lbxIDscan.Items.Add("Visitor: "+ e.Tag + " has no reservation, please make one");
                groupBox2.Visible = true;
                List<string> spots;
                spots = dh.NonReservedSelect();
               
                lbxAvailablecampingspots.Items.Clear();
                foreach (string s in spots)
                {

                    lbxAvailablecampingspots.Items.Add(s);
                    
                }
                lbxAvailablecampingspots.SelectedIndex = 0;


            }


        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {
            if(dh.BalanceSelect(this.tag) > this.total)
            {
                double change = dh.BalanceSelect(this.tag) - this.total;
                int catchnr = dh.AddReservation(dh.CampingIDSelect(lbxAvailablecampingspots.SelectedItem.ToString()),this.tag,Convert.ToInt32(tbAmountofPersons.Text),this.total);
                int catchnr2 = dh.AddNewBalance(this.tag, change);
                dh.AddLogReservation(this.tag);
                if (catchnr > 0 && catchnr2 > 0)
                { 
                    MessageBox.Show("Camping Spot Reserved, please Check in Visitor");
                    groupBox2.Visible = false;

                }
                else
                {
                    MessageBox.Show("Payment Failed");
                }
            }
            else if (dh.BalanceSelect(this.tag) < this.total)
            {
                MessageBox.Show("Not Enough Funds");
            }


        }

        private void btnShowtotalprice_Click(object sender, EventArgs e)
        {
            this.total = (Convert.ToInt32(tbAmountofPersons.Text) * dh.PricePerPersonSelect(lbxAvailablecampingspots.SelectedItem.ToString())) + 10;
            lblTotalPrice.Text = Convert.ToString(this.total);       // Convert.ToString(this.total);
        }

        private void lbxAvailablecampingspots_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            
            lblInfo.Text = "Capacity of " + dh.CampingCapacitySelect(lbxAvailablecampingspots.SelectedItem.ToString()) + " persons at " + dh.PricePerPersonSelect(lbxAvailablecampingspots.SelectedItem.ToString()) + " euros per person";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            
            if (this.Width == orgSize)
            {
                rlbManual.Text = "• Click the button “Open Connection” to connect the RFID scanner to the application. This must be done before using the RFID scanner. \n" +
                    "•  Click the button “Close Connection” to disconnect the RFID scanner from the application. \n" +
                    "•  Using the RFID Scanner, scan the visitor’s bracelet to check them in or out.\n" +
                    "•  After being notified that there is no reservation: \nClick the chosen camping spot from the list then Click the button “Show Info” to view the capacity and price per person for that camping spot.\n" +
                    "Enter the amount of persons in the textbox then Click the button “Show Price” to view the total price for the reservation.\n" +
                    "Click the button “Make purchase” to complete the payment.You will be notified of the situation of the payment.\n" +
                    "•  Click the button “Back” to return to main menu.";
                timer1.Interval = 15;
                timer1.Enabled = true;
                timer1.Tick += new System.EventHandler(timer1_Tick);
                
            }
            else
            {
                timer2.Interval = 15;
                timer2.Enabled = true;
                timer2.Tick += new System.EventHandler(timer2_Tick);
                
            }


            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int l = Application.StartupPath.ToString().Length;
            System.Diagnostics.Process.Start(Application.StartupPath.ToString().Remove(l - 31) + @"\EscalateMusicFestival\bin\Debug\EscalateMusicFestival.exe");
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnManual.Enabled = false;
            this.Width += 3;
            if (this.Width > 1150)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
