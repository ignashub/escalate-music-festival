using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventStatusCheck
{

    public partial class Form1 : Form
    {
        private DataHelper dh;
        private double totalspent = 0;
        int orgSize;
        public Form1()
        {
            InitializeComponent();
            orgSize = this.Width;
            dh = new DataHelper();
            List<string> shops;
            shops = dh.StandsSelect();

            lbxShops.Items.Clear();
            foreach (string s in shops)
            {

                lbxShops.Items.Add(s);

            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnMoneymade_Click(object sender, EventArgs e)
        {
            lblMoneymade.Text = "Amount Made: "+ dh.ShopMoneyMadeSelect(lbxShops.SelectedItem.ToString()) + " euros";
            if (dh.ShopMoneyMadeSelect(lbxShops.SelectedItem.ToString()) == -1)
            {
            lblMoneymade.Text = "Amount Made: " + dh.LoanStandMoneyMadeSelect(lbxShops.SelectedItem.ToString()) + " euros";
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalamountvisitors_Click(object sender, EventArgs e)
        {

        }

        private void btnShowvisitors_Click(object sender, EventArgs e)
        {
            List<string> visitors;
            visitors = dh.PresentVisitorsSelect();

            lbxVisitorspresent.Items.Clear();
            foreach (string v in visitors)
            {

                lbxVisitorspresent.Items.Add(v);

            }
        }

        private void btnVisitorsinfo_Click(object sender, EventArgs e)
        {
            this.totalspent = dh.TotalSpentLoanedSum() + dh.TotalSpentPurchasedSum() + dh.TotalSpentReserved();

            lbxVisitorspresent.Items.Clear();
            lbxVisitorspresent.Items.Add("Total Amount of Visitors: " + dh.TotalVisitorsCount());
            lbxVisitorspresent.Items.Add("Total Balance of all Visitors: " + dh.TotalBalanceSum() + " euros");
            lbxVisitorspresent.Items.Add("Total Amount Spent by Visitors: " + this.totalspent + " euros");

        }

        private void btnCampstats_Click(object sender, EventArgs e)
        {
            lbxCampingstats.Items.Clear();
            lbxCampingstats.Items.Add("Total Amount of Reserved Spots: " + dh.TotalReservedCount());
            lbxCampingstats.Items.Add("Total Amount Made for Camping: " + dh.TotalMoneyMadeReserved()+" euros");
            lbxCampingstats.Items.Add("Total Amount of Visitors at CampingSpots: " + dh.TotalVisitorsSpots());
            lbxCampingstats.Items.Add("Average Amount of Visitors per CampingSpot: " + dh.AvgVisitorsSpots());
            lbxCampingstats.Items.Add("Average Amount Made per CampingSpot: " + dh.AvgMadeSpots() + " euros");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAmountsold_Click(object sender, EventArgs e)
        {
            lblAmountsold.Text = "A Total Amount of: " + dh.AmountSoldSelect(tbItem.Text)+ " was sold";
        }

        private void btnShowVisitorInfo_Click(object sender, EventArgs e)
        {
            List<string> history;
            history = dh.HistoryOrder(tbVisitorID.Text);

            lbxVisitorHistory.Items.Clear();
            foreach (string h in history)
            {
                lbxVisitorHistory.Items.Add(h);

            }

            if (lbxVisitorHistory.Items.Count > 0)
            {
                lblVisitorStatus.Text = "Visitor has just " + lbxVisitorHistory.Items[lbxVisitorHistory.Items.Count - 1].ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int l = Application.StartupPath.ToString().Length;
            System.Diagnostics.Process.Start(Application.StartupPath.ToString().Remove(l - 27) + @"\EscalateMusicFestival\bin\Debug\EscalateMusicFestival.exe");
            this.Close();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (this.Width == orgSize)
            {
                timer1.Interval = 15;
                timer1.Enabled = true;
                timer1.Tick += new System.EventHandler(timer1_Tick);
                rlbManual.Text = "• “Visitor” Section : Enter the Event ID of the respective visitor in the textbox then Click the button button “Show Info” to view the status and history of visitor.\n" +
                    "•  “Camping Spots” Section: Click the button “View Camping Statistics” to view some of the statistics of the activity in the camping area.\n" +
                    "•  “Visitors” Section: Click the button “Show Visitors Present”  to view all the present visitors in the event.\n " +
                    "Click the button “View Visitors Statistics” to view balance of all visitors together & total spent money by all visitors\n" +
                    "•  “Stands” Section : Click a stand from the list and Click the button “Show Total Amount of Money Made” shows total money made per shop.\n" +
                    "•  “Shop Items” Section : Enter the Item ID of the respective item in the textbox then Click the button “Show Amount Sold” to view the amount of that item sold.\n" +
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
            if (this.Width > 1540)
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
