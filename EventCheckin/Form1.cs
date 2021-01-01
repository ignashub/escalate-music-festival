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

namespace EventCheckin
{
    public partial class Form1 : Form
    {
        private RFID myRFIDReader;
        private DataHelper dh;
        private Looper l;
        int orgSize;
        public Form1()
        {
            InitializeComponent();
            orgSize = this.Width;
            l = new Looper();
            dh = new DataHelper();
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(Attached);
                myRFIDReader.Detach += new DetachEventHandler(Detached);
                myRFIDReader.Tag += new RFIDTagEventHandler(ReadTagNewID);

                lbxNewidscan.Items.Add("Startup successfull");
               
            }
            catch (PhidgetException) { lbxNewidscan.Items.Add("Error at startup"); }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e) //opens connection to RFID
        {
            try
            {
                myRFIDReader.Open();
                lbxNewidscan.Items.Add("Connection opened");

            }
            catch (PhidgetException)
            {
                lbxNewidscan.Items.Clear();
                lbxNewidscan.Items.Add("Connection failed:Please try again");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) //closes connection to RFID
        {
            myRFIDReader.Close();
            lbxNewidscan.Items.Add("Connection closed");
        }

        public void Attached(object sender, AttachEventArgs e) //for when RFID is plugged in
        {
            lbxNewidscan.Items.Add("RFID Reader attached");
        }

        public void Detached(object sender, DetachEventArgs e) //for when RFID is unplugged
        {
            lbxNewidscan.Items.Add("RFID Reader detached");
        }

        public void ReadTagNewID(object sender, RFIDTagEventArgs e)
        {


            int catchnr = dh.AddNewVisitorID(tbID.Text, e.Tag);
            if (catchnr > 0)
            {

                lbxNewidscan.Items.Clear();
                lbxNewidscan.Items.Add("Checked In with bracelet: " + e.Tag);
                dh.AddLogCheckedIn(e.Tag); 
            } 
            else
            {   
                if (dh.CheckedinCheckoutSelect(e.Tag) == "No")
                {
                    int catchnr2 = dh.Checkin(e.Tag);
                   
                    if (catchnr2 > 0)
                    {
                        lbxNewidscan.Items.Clear();
                        lbxNewidscan.Items.Add("Checked In Visitor: " + e.Tag);
                        dh.AddLogCheckedIn(e.Tag);
                    }
                    else
                    {
                        lbxNewidscan.Items.Add("Checked In Failed" /*+ e.Tag*/);
                    }
                    
                }
                else if (dh.CheckedinCheckoutSelect(e.Tag) == "Yes")
                {
                    int catchnr2 = dh.Checkout(e.Tag);
                   
                    if (catchnr2 > 0)
                    {

                        lbxNewidscan.Items.Clear();
                        lbxNewidscan.Items.Add("Checked Out Visitor: " + e.Tag);
                        dh.AddLogCheckedOut(e.Tag);
                    }
                    else
                    {
                        lbxNewidscan.Items.Add("Checked Out Failed" /*+ e.Tag*/);
                    }
                    
                }

            }
        }

            private void lbxNewidscan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGenerateID_Click(object sender, EventArgs e)
        {
           lblGeneratedIDnr.Text = l.LoopID();
             
        }

        private void btnStoreid_Click(object sender, EventArgs e)
        {
            int catchnr = dh.AddVisitor(lblGeneratedIDnr.Text);

            if (catchnr > 0)
            {

                lblStored.Text = "Stored Visitor: " + lblGeneratedIDnr.Text;


            }
            else
            {
                lblStored.Text = "Failed to store Visitor";
            }


            }

        private void lblGeneratedIDnr_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int l = Application.StartupPath.ToString().Length;
            System.Diagnostics.Process.Start(Application.StartupPath.ToString().Remove(l - 23) + @"\EscalateMusicFestival\bin\Debug\EscalateMusicFestival.exe");
            this.Close();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (this.Width == orgSize)
            { 
                timer1.Interval = 15;
                timer1.Enabled = true;
                timer1.Tick += new System.EventHandler(timer1_Tick);
                rlbManual.Text = "• Click the button “Open Connection” to connect the RFID scanner to the application. This must be done before using the RFID scanner.\n" +
                    "•  Click the button “Close Connection” to disconnect the RFID scanner from the application.\n" +
                    "•  Enter the respective visitor’s Event ID in the text box then using the RFID scanner scan the bracelet that will be assigned to the visitor.\n" +
                    "•  In the event that the visitor has not purchased a ticket:\n" +
                    "Click the button “Generate ticket #” generate a new ticket #.\n" +
                    "Click the button “Store ID” to store the generated ticket #.\n" +
                    "Enter the generated Event ID in the text box then using the RFID scanner scan the bracelet that will be assigned to the visitor.\n" +
                    "•  In the event that the visitor is checking out:\n" +
                    "Using the RFID Scanner, scan the visitor’s bracelet to check them out.\n" +
                    "•  Click the button “Back” to return to main menu.";
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
            if (this.Width > 1370)
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
    }
}
