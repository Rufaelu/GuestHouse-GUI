﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestHouse_GUI
{
    public partial class DashBoard : Form
    {
     
      
        public DashBoard()
        {
            InitializeComponent();
            CountBooked();
            CountCustomers();
          //  CountBooking();
         //   GetCustomer();
            bookedcheck();
           
        }
        void populatenamecombo()
        {
            CusNameCb.Items.Clear();
           
            if(Program.guest!=null)
            foreach(Guest gue in Program.guest)
            {
                if(gue!=null)
                CusNameCb.Items.Add(gue.FullName);
            }
           
           
        }

        private void R1_Paint(object sender, PaintEventArgs e)
        {
            roomnumtb.Text = 1.ToString();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=RAFA;Initial Catalog=GuestHouse;Integrated Security=True");
        int free, Booked;
        int BPer, FreePer;

        void bookedcheck()
        {
            for (int i = 1; i <= 20; i++)
            {
                string panelName = "R" + i;
                Panel roomPanel = this.Controls[panelName] as Panel;
                if (roomPanel != null)
                {
                    if (Program.list!=null&&Program.list.Isbooked(i))
                    {
                        roomPanel.BackColor = Color.LightGray;

                        // Make it unclickable
                        roomPanel.Enabled = false;
                    }
                    else
                    {
                        roomPanel.BackColor =Color.LightCyan;

                        // Make it clickable
                        roomPanel.Enabled = true;
                    }
                }
            }
        }
        private void CountBooked()
        {
            string Status = "occupied";
            if (Program.list != null)
            {
                free = 20 - Program.list.TotalBooking;
                Booked = Program.list.TotalBooking;
                BPer = (Booked / 20) * 100;
                FreePer = (free / 20) * 100;
                BLbl.Text = Booked + " Booked Rooms";//Number of booked rooms(booked label)
                AVllbl.Text = free + " Free Rooms";//NUmber of free rooms(availible label)
                AvLbl1.Text = free + "";//this shows the number of free rooms from the freeRoomsProgressbar
                BProgress.Value = BPer;//shows the progress bar amount for booked spaces
                AVLProgress.Value = FreePer;//shows the progress bar amount for free spaces
                FreeRoomsProgress.Value = FreePer;//shows the progress bar amount of the of free spaces left
            }
        }
        private void CountCustomers()
        { 
           
            if(Program.list!=null)
            CustNumLbl.Text = Program.list.TotalBooking.ToString() + " Customers";
            
        
        }
        
        int RoomNumber = 0;
      
        
        string RType;
        int RC;
       
       
        private void Reset()
        {
            CusNameCb.Text = "";
            CusNumofDaysTb.Text = "";
            RoomNumber = 0;
            roomnumtb.Text = string.Empty;
        }
       
        private void BookBtn_Click(object sender, EventArgs e)
        {
            Guest singleguest=null;

            if (CusNumofDaysTb.Text == "" || RoomNumber == 0||CusNameCb.Text=="")
            {
                MessageBox.Show("Select a Room and a Customer");
            } else
            {
                foreach(Guest g in Program.guest)
                {
                   
                    if(g != null&&g.FullName== CusNameCb.Text)
                    {
                    singleguest= new Guest(g.FullName,g.PhoneNumber,g.Dob,g.gender);
                        singleguest.CheckInDate = DateTime.Now.ToString("yyyy-MM-dd");
                        singleguest.CheckOutDate = DateTime.Parse(singleguest.CheckInDate).AddDays(int.Parse(CusNumofDaysTb.Text)).ToString("yyyy-MM-dd");



                    }
                }

                try
                {
                    
                    Program.list.AddBooking(RoomNumber,singleguest, Program.list.getPrice(RoomNumber) * int.Parse(CusNumofDaysTb.Text));
                    for (int i=0;i< Program.guest.Length;i++)
                    {

                        if (Program.guest[i].FullName==singleguest.FullName)
                        {
                            Program.guest[i] = null;


                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    bookedcheck();
                    Reset();
                }

                
            }
        }

        private void CusIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //GetCusName();
        }

        private void R2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R9_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R10_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R12_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R13_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void R14_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R15_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R16_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R17_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R18_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R19_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R20_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void R1_Click(object sender, EventArgs e)
        {
          
            roomnumtb.Text = 1.ToString();
        }

        private void R2_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 2.ToString();

        }

        private void R3_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 3.ToString();
        }

        private void R4_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 4.ToString();
        }

        private void R5_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 5.ToString();
        }

        private void R6_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 6.ToString();
        }

        private void R7_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 7.ToString();
        }

        private void R8_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 8.ToString();
        }

        private void R9_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 9.ToString();
        }

        private void R10_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 10.ToString();
        }

        private void R11_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 11.ToString();
        }

        private void R12_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 12.ToString();
        }

        private void R13_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 13.ToString();
        }

        private void R14_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 14.ToString();
        }

        private void R15_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 15.ToString();
        }

        private void R16_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 16.ToString();
        }

        private void R17_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 17.ToString();
        }

        private void R18_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 18.ToString();
        }

        private void R19_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 19.ToString();
        }

        private void R20_Click(object sender, EventArgs e)
        {
            roomnumtb.Text = 20.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
         Program.   objcustomer.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
          Program.  objbooking.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Program.objlogin.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
       
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           Program. objuser.Show();
            this.Hide();
        }

        private void AVllbl_Click(object sender, EventArgs e)
        {

        }

        private void DashBoard_Enter(object sender, EventArgs e)
        {
          //  populatenamecombo();
        }

        private void DashBoard_VisibleChanged(object sender, EventArgs e)
        {
            populatenamecombo();

        }

        private void R1lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=1.ToString();
        }

        private void R2lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=2.ToString();
        }

        private void R3lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=3.ToString();
        }

        private void R4lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=4.ToString();
        }

        private void R5lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=5.ToString();
        }

        private void R6lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=6.ToString();
        }

        private void R7lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=7.ToString();
        }

        private void R8lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=8.ToString();
        }

        private void R9lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=9.ToString();
        }

        private void R10lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=10.ToString();
        }

        private void R11lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=11.ToString();
        }

        private void R12lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=12.ToString();
        }

        private void R13lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=13.ToString();

        }

        private void R14lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=14.ToString();
        }

        private void R15lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=15.ToString();
        }

        private void R16lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=16.ToString();
        }

        private void R17lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=17.ToString();
        }

        private void R18lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=18.ToString();
        }

        private void R19lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=19.ToString();
        }

        private void R20lbl_Click(object sender, EventArgs e)
        {
            roomnumtb.Text=20.ToString();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
           // Program.list = new LinkedProgram.list();
            populatenamecombo();

        }
    }
}
