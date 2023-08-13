using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRS1.DBA;
using HRS1.Room;


namespace HRS1.Booking
{
    public partial class frm_Booking : Form
    {
        clsBooking obj_clsBooking = new clsBooking();
        clsMainDB obj_MainDB = new clsMainDB();
        clsRoom obj_Room = new clsRoom();
        clsBookingDetial obj_BookingDetail = new clsBookingDetial();
        DataTable DT = new DataTable();
        public bool _isEdit = false;
        public int _BookingID = 0;
        string SPString = "";

        public frm_Booking()
        {
            InitializeComponent();
        }

        private void frm_Booking_Load(object sender, EventArgs e)
        {
            string Day = string.Format("{0:D2}", DateTime.Now.Day);
            string Month = string.Format("{0:D2}", DateTime.Now.Month);
            string Year = string.Format("{0:D2}", DateTime.Now.Year);
            lblBookingDate.Text = Month + "/" + Day + "/" + Year;
            lblRoomPrice.Text = "0";
            lblTotalAmount.Text = "0";
            ShowData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowData()
        {
            SPString = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", "0", "0", "0", "9");
            obj_MainDB.AddCombo(ref cboEmployee, SPString, "EmployeeName", "EmployeeID");

            SPString = string.Format("SP_Select_Customer N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            obj_MainDB.AddCombo(ref cboCusName, SPString, "CusName", "CusID");

            SPString = string.Format("SP_Select_RoomType N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            obj_MainDB.AddCombo(ref cboRoomType, SPString, "RoomType", "RoomTypeID");

           

            SPString = string.Format("SP_Select_Service N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            obj_MainDB.AddCombo(ref cboService, SPString, "ServiceName", "ServiceID");
        }

        private void cboRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (cboRoomType.Text == ".....Select.....")
            {
                MessageBox.Show("Please Choose RoomType");
                cboRoomType.Focus();
            }
            else 
            {
                lblRoomPrice.Text = "0";

                if (e.KeyChar.Equals('\r'))
                {
                    if (cboEmployee.Text == ".....Select.....")
                    {
                        MessageBox.Show("Please Choose EmployeeName");
                        cboEmployee.Focus();
                    }
                    else if (cboCusName.Text == ".....Select.....")
                    {
                        MessageBox.Show("Please Choose CustomerName");
                        cboCusName.Focus();
                    }
                    else
                    {
                        SPString = string.Format("SP_Select_RoomType N'{0}',N'{1}',N'{2}'", cboRoomType.Text.Trim().ToString(), "0", "4");
                        DT = obj_MainDB.SelectData(SPString);
                        if (DT.Rows.Count > 0)
                        { 
                        lblRoomPrice.Text=(DT.Rows[0]["Price"]).ToString();
                        }

                    }
                }
            }*/
        }

       private void dtpCheckOutDate_KeyPress(object sender, KeyPressEventArgs e)
        {

           /* if (Convert.ToInt32(dtpCheckInDate.Text)< Convert.ToInt32(lblBookingDate.Text))
            {
                MessageBox.Show("Check In Date Should be Greater than Today");
                dtpCheckInDate.Focus();
            }
            else
            {
                lblTotalNight.Text = "0";

                if (e.KeyChar.Equals('\r'))
                {
                    if (dtpCheckOutDate.Text == string.Empty)
                    {
                        MessageBox.Show("Please Choose CheckOutDate");
                        dtpCheckOutDate.Focus();
                    }
                    else if (Convert.ToInt32(dtpCheckOutDate.Text)-Convert.ToInt32(dtpCheckInDate.Text)==0)
                    {
                        MessageBox.Show("Checkout Date Should be Greater than CheckIn Date");
                        cboCusName.Focus();
                    }
                    else
                    {
                        lblTotalNight.Text = (Convert.ToInt32(dtpCheckOutDate.Text) - Convert.ToInt32(dtpCheckInDate.Text)).ToString();
                    }
                }

            }*/
        }

      /* private void txtTotalNight_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (lblRoomPrice.Text == "0")
           {
               MessageBox.Show("Please Choose Room!");
               cboRoomType.Focus();
           }
           else
           {
               int ok;

               lblTotalAmount.Text = "0";

               if (e.KeyChar.Equals('\r'))
               {
                   if (lblTotalNight.Text == string.Empty)
                   {
                       MessageBox.Show("Please Type TotalNight");
                       lblTotalNight.Focus();
                   }
                   else if ((dtpCheckOutDate.Text) ==(dtpCheckInDate.Text))
                   {
                       MessageBox.Show("Checkout Date Should be Greater than CheckIn Date");
                       cboCusName.Focus();
                   }
                   else if (int.TryParse(lblTotalNight.Text, out ok) == false)
                   {
                       MessageBox.Show("TotalNight Should Be Number!");
                       lblTotalNight.Focus();
                   }
                   else
                   {
                       lblTotalAmount.Text = (Convert.ToInt32(lblRoomPrice.Text) * Convert.ToInt32(lblTotalNight.Text)).ToString();
                       
                   }
               }
           }
       }*/

       private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (lblTotalAmount.Text == "0")
           {
               MessageBox.Show("Please Claculate Total Amount!");
               lblTotalNight.Focus();
           }
           else
           {
               
               int ok;

               if (e.KeyChar.Equals('\r'))
               {
                   if (txtPayment.Text == string.Empty)
                   {
                       MessageBox.Show("Please Type Payment!");
                       txtPayment.Focus();
                   }
                   else if (Convert.ToInt32(txtPayment.Text) < Convert.ToInt32(lblTotalAmount.Text))
                   {
                       MessageBox.Show("Payment Amount Should Be Above "+lblTotalAmount.Text);
                       txtPayment.Focus();
                   }
                   else if (int.TryParse(txtPayment.Text, out ok) == false)
                   {
                       MessageBox.Show("Payment Should Be Number!");
                       txtPayment.Focus();
                       txtPayment.SelectAll();
                   }
                   else if(Convert.ToInt32(txtPayment.Text) > Convert.ToInt32(lblTotalAmount.Text)+10000)
                   {
                       MessageBox.Show("Payment Amount Should Be Below "+(Convert.ToInt32(lblTotalAmount.Text)+10000));
                       txtPayment.Focus();
                       txtPayment.SelectAll();
                   }
                   else
                   {
                       lblRefund.Text = (Convert.ToInt32(txtPayment.Text) - Convert.ToInt32(lblTotalAmount.Text)).ToString();
                   }
               }
           }
       }
       List<String> List_Service = new List<string>(); 
       private void btnAddService_Click(object sender, EventArgs e)
       {
           if (cboService.Text == ".....Select.....")
           {
               MessageBox.Show("Please Choose Service","Error",MessageBoxButtons.YesNo,MessageBoxIcon.Error);           
           }
           else
           {
               String Add = "Add";
               int index = lstService.SelectedIndex;

               if (index >= 0)
               {
                   if (MessageBox.Show("Do you Want To insert New Data At Index " + index + "?", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                       Add = "Insert";
               }

               String Str_Service = cboService.Text;
               if (List_Service.Contains(Str_Service))
                   MessageBox.Show("This Service Is Already Exist", "Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
               else
               {
                   if (Add == "Add")
                       List_Service.Add(Str_Service);
                   else
                       List_Service.Insert(index, Str_Service);
               }

               lstService.Items.Clear();
               foreach (String DN in List_Service)
                   lstService.Items.Add(DN);

               SPString = string.Format("SP_Select_Service N'{0}',N'{1}',N'{2}'", cboService.Text.Trim().ToString(), "0", "1");
               DT = obj_MainDB.SelectData(SPString);
               int SerPrice = Convert.ToInt32(DT.Rows[0]["ServicePrice"]);
               int tot = Convert.ToInt32(lblTotalAmount.Text);
               lblTotalAmount.Text = ((SerPrice*Convert.ToInt32(lblTotalNight.Text)) + tot).ToString();
               cboService.Focus();
           }
       }

       private void btnRemove_Click(object sender, EventArgs e)
       {
           int index = lstService.SelectedIndex;
           if (index >= 0)
           {
               List_Service.RemoveAt(index);

               lstService.Items.Clear();
               foreach (String DN in List_Service)
               {
                   lstService.Items.Add(DN);
               }
               cboService.Focus();
           }
           else
               MessageBox.Show("Please choose for remove");


           SPString = string.Format("SP_Select_Service N'{0}',N'{1}',N'{2}'", cboService.Text.Trim().ToString(), "0", "1");
           DT = obj_MainDB.SelectData(SPString);
           int SerPrice = Convert.ToInt32(DT.Rows[0]["ServicePrice"]);
           int tot = Convert.ToInt32(lblTotalAmount.Text);
           lblTotalAmount.Text = (tot-SerPrice).ToString();
           cboService.Focus();
       }

       private void cboRoomType_KeyPress(object sender, KeyPressEventArgs e)
       {
          /* if (cboRoomType.Text == ".....Select.....")
           {
               MessageBox.Show("Please Choose RoomType");
               cboRoomType.Focus();
           }
           else
           {
               lblRoomPrice.Text = "0";

               if (e.KeyChar.Equals('\r'))
               {
                   if (cboEmployee.Text == ".....Select.....")
                   {
                       MessageBox.Show("Please Choose EmployeeName");
                       cboEmployee.Focus();
                   }
                   else if (cboCusName.Text == ".....Select.....")
                   {
                       MessageBox.Show("Please Choose CustomerName");
                       cboCusName.Focus();
                   }
                   else
                   {
                       SPString = string.Format("SP_Select_RoomType N'{0}',N'{1}',N'{2}'", cboRoomType.Text.Trim().ToString(), "0", "4");
                       DT = obj_MainDB.SelectData(SPString);
                       if (DT.Rows.Count > 0)
                       {
                           lblRoomPrice.Text = (DT.Rows[0]["Price"]).ToString();
                       }

                   }
               }
           }*/
       }

       private void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
       {
           SPString = string.Format("SP_Select_Room N'{0}',N'{1}',N'{2}'",cboRoomType.Text.Trim().ToString(), "0", "4");
           obj_MainDB.AddCombo(ref cboRoom, SPString, "RoomNo", "RoomID");

               SPString = string.Format("SP_Select_RoomType N'{0}',N'{1}',N'{2}'", cboRoomType.Text.Trim().ToString(), "0", "4");
               DT = obj_MainDB.SelectData(SPString);
               if (DT.Rows.Count > 0)
               {
                   lblRoomPrice.Text = (DT.Rows[0]["Price"]).ToString();
               }
       }

       private void txtTotalNight_TextChanged(object sender, EventArgs e)
       {

       }

       private void dtpCheckOutDate_ValueChanged(object sender, EventArgs e)
       {
           SPString = string.Format("SP_Select_Service N'{0}',N'{1}',N'{2}'",dtpCheckInDate.Value.ToShortDateString(),dtpCheckOutDate.Value.ToShortDateString(),"2");
           DT = obj_MainDB.SelectData(SPString);
           int DateD = Convert.ToInt32(DT.Rows[0]["No"]);
           if (DateD < 0)
           {
               MessageBox.Show("Please Check Check Out Date!", "Checking", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
               dtpCheckInDate.Text = DateTime.Now.ToShortDateString();
               dtpCheckOutDate.Text = DateTime.Now.ToShortDateString();
               return;
           }
           else
           {
               lblTotalNight.Text = DT.Rows[0]["No"].ToString();
           }
       }

       private void lblTotalNight_TextChanged(object sender, EventArgs e)
       {
           int ok;
           if (lblTotalNight.Text == string.Empty)
           {
               MessageBox.Show("Please Type TotalNight");
               lblTotalNight.Focus();
           }
           else if ((dtpCheckOutDate.Text) == (dtpCheckInDate.Text))
           {
               MessageBox.Show("Checkout Date Should be Greater than CheckIn Date");
               cboCusName.Focus();
           }
           else if (int.TryParse(lblTotalNight.Text, out ok) == false)
           {
               MessageBox.Show("TotalNight Should Be Number!");
               lblTotalNight.Focus();
           }
           else
           {
               lblTotalAmount.Text = (Convert.ToInt32(lblRoomPrice.Text) * Convert.ToInt32(lblTotalNight.Text)).ToString();

           }
       }

       private void btnSave_Click(object sender, EventArgs e)
       {
                    int ok;
                   if (cboEmployee.Text.Trim().ToString() == ".....Select.....")
                   {
                       MessageBox.Show("Please Choose EmployeeName ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       cboEmployee.Focus();
                   }
                   else if (cboCusName.Text.Trim().ToString() == ".....Select.....")
                   {
                       MessageBox.Show("Please Choose CustomerName ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       cboCusName.Focus();
                   }
                   else if (cboRoomType.Text.Trim().ToString() == ".....Select.....")
                   {
                       MessageBox.Show("Please Choose RoomType ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       cboRoomType.Focus();
                   }
                   else if (lblRoomPrice.Text.Trim().ToString() == string.Empty)
                   {
                       MessageBox.Show("Please Type Room Price ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       lblRoomPrice.Focus();
                   }
                   else if (cboRoom.Text.Trim().ToString() == ".....Select.....")
                   {
                       MessageBox.Show("Please Choose RoomNo ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       cboRoom.Focus();
                   }
                   else if ((dtpCheckOutDate.Text) == (dtpCheckInDate.Text))
                   {
                       MessageBox.Show("Checkout Date Should be Greater than CheckIn Date", "Same Date", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                       cboCusName.Focus();
                   }
                   else if (lblTotalNight.Text.Trim().ToString() == string.Empty)
                   {
                       MessageBox.Show("Please Choose Total Night ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       lblTotalNight.Focus();
                   }
                   else if (lblTotalAmount.Text.Trim().ToString() == string.Empty)
                   {
                       MessageBox.Show("Please Type TotalAmount ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       lblTotalAmount.Focus();
                   }
                   else if (lblBookingDate.Text.Trim().ToString() == string.Empty)
                   {
                       MessageBox.Show("Please Type Booking Date ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       lblBookingDate.Focus();
                   }
                   else if (txtPayment.Text.Trim().ToString() == string.Empty)
                   {
                       MessageBox.Show("Please Type Payment ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       txtPayment.Focus();
                   }
                   else if (lblRefund.Text.Trim().ToString() == string.Empty)
                   {
                       MessageBox.Show("Please Type Refund ", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       lblRefund.Focus();
                   }
                   else
                   {
                       obj_clsBooking.BID = _BookingID;
                       obj_clsBooking.EMPID = Convert.ToInt32(cboEmployee.SelectedValue);
                       obj_clsBooking.CUSID = Convert.ToInt32(cboCusName.SelectedValue);
                       obj_clsBooking.ROOMTYPEID = Convert.ToInt32(cboRoomType.SelectedValue);
                       obj_clsBooking.ROOID = Convert.ToInt32(cboRoom.SelectedValue);
                       obj_clsBooking.CHECKINDAT = dtpCheckInDate.Value.ToShortDateString();
                       obj_clsBooking.CHECKOUTDATE = dtpCheckOutDate.Value.ToShortDateString();
                       obj_clsBooking.TOTALNIGHT = Convert.ToInt32(lblTotalNight.Text);
                       string service = string.Empty;
                       foreach (String DN in List_Service)
                       {
                           service = service + DN.ToString() + ",";
                        }
                        if (lstService.Text == string.Empty)
                        {
                            MessageBox.Show("Are you sure no Service! ", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            service = "null";
                        }
                       obj_clsBooking.SERVICE = service;
                       obj_clsBooking.TOTALAMOUNT = Convert.ToInt32(lblTotalAmount.Text.ToString());
                       obj_clsBooking.BOOKINGDATE = lblBookingDate.Text.Trim().ToString();
                       obj_clsBooking.PAYMENT = Convert.ToInt32(txtPayment.Text.ToString());
                       obj_clsBooking.REFUND = Convert.ToInt32(lblRefund.Text.ToString());
                       obj_clsBooking.ACTION = 0;
                       obj_clsBooking.SaveData();

                       obj_Room.ROOMNO = cboRoom.Text.Trim().ToString();
                       obj_Room.STATUS = "Booked";
                       obj_Room.ACTION = 3;
                       obj_Room.SaveData();


                       SPString = string.Format("SP_Select_Booking N'{0}',N'{1}',N'{2}'", "0", "0", "2");
                       DT = obj_MainDB.SelectData(SPString);
                       _BookingID = Convert.ToInt32(DT.Rows[0]["BookingID"].ToString());
                       obj_BookingDetail.BID = _BookingID;
                       obj_BookingDetail.ROOMID = Convert.ToInt32(cboRoom.SelectedValue);
                       obj_BookingDetail.CUSID = Convert.ToInt32(cboCusName.SelectedValue);
                       obj_BookingDetail.TOTALPRICE = Convert.ToInt32(lblTotalAmount.Text.ToString());
                       obj_BookingDetail.SERVICE = service;
                       obj_BookingDetail.ACTION = 0;
                       obj_BookingDetail.SaveData();

                       MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       this.Close();


                   }
               
           
       }

       private void txtPayment_TextChanged(object sender, EventArgs e)
       {

       }      
    }
}
