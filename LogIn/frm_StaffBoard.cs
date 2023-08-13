using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRS1.Customer;
using HRS1.Employee;
using HRS1.DBA;
using HRS1.Booking;
using HRS1.Room;

namespace HRS1.LogIn
{
    public partial class frm_StaffBoard : Form
    {
        public frm_StaffBoard()
        {
            InitializeComponent();
        }
        clsBooking obj_clsBooking = new clsBooking();
        clsBookingDetial obj_clsBookingDetail = new clsBookingDetial();
        clsRoom obj_clsRoom = new clsRoom();
        clsMainDB obj_clsMainDB = new clsMainDB();
        public UserControl Booking;

        string SPString = "";

        private void ShowBooking()
        {
                DataGridViewTextBoxColumn DGCol = new DataGridViewTextBoxColumn();
               
                SPString = string.Format("SP_Select_BookingDetail N'{0}',N'{1}',N'{2}'", "0", "0", "0");
                dgvBooking.DataSource = obj_clsMainDB.SelectData(SPString);

                dgvBooking.Columns[0].Width = (dgvBooking.Width / 100) * 5;
                dgvBooking.Columns[1].Width = (dgvBooking.Width / 100) * 10;
                dgvBooking.Columns[2].Width = (dgvBooking.Width / 100) * 10;
                dgvBooking.Columns[3].Width = (dgvBooking.Width / 100) * 10;
                dgvBooking.Columns[4].Width = (dgvBooking.Width / 100) * 20;
                dgvBooking.Columns[5].Width = (dgvBooking.Width / 100) * 40;

                dgvBooking.Columns[0].ReadOnly = true;
                dgvBooking.Columns[1].ReadOnly = true;
                dgvBooking.Columns[2].ReadOnly = true;
                dgvBooking.Columns[3].ReadOnly = true;
                dgvBooking.Columns[4].ReadOnly = true;
                dgvBooking.Columns[5].ReadOnly = true;
               
          
        }
        private void ShowBookingDetail()
        {
            Booking = new ctl_Booking();
            Booking.Hide();
            Controls.Add(Booking);
            Controls.SetChildIndex(Booking,0);

        }



        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            frm_CustomerList frm = new frm_CustomerList();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string _BookingID = dgvBooking.CurrentRow.Cells["BookingID"].Value.ToString();
            string _RoomID = dgvBooking.CurrentRow.Cells["RoomID"].Value.ToString();
            if (_BookingID == string.Empty)
            {
                MessageBox.Show("There Is No Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want to Check OUt", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    obj_clsBooking.BID = Convert.ToInt32(_BookingID);
                    obj_clsBooking.ACTION = 1;
                    obj_clsBooking.SaveData();

                    obj_clsRoom.ROOMID = Convert.ToInt32(_RoomID);
                    obj_clsRoom.STATUS = "Avaliable";
                    obj_clsRoom.ACTION = 4;
                    obj_clsRoom.SaveData();


                    obj_clsBookingDetail.BID = Convert.ToInt32(_BookingID);
                    obj_clsBookingDetail.ACTION = 1;
                    obj_clsBookingDetail.SaveData();


                    MessageBox.Show("Successfully CheckOut", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowBooking();
                    ShowBookingDetail();
                }
            }
        }

        private void mnuRooms_Click(object sender, EventArgs e)
        {
            frm_RoomList1 frm = new frm_RoomList1();
            frm.ShowDialog();
        }

        private void frm_StaffBoard_Load(object sender, EventArgs e)
        {
            ShowBooking();
            ShowBookingDetail();
        }

        private void mnuBooking_Click(object sender, EventArgs e)
        {
            frm_Booking frm = new frm_Booking();
            frm.ShowDialog();
            ShowBooking();
        }

        private void dgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (e.ColumnIndex == 0)
            {
    
                Rectangle cellBounds = dgvBooking.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point offsetLocation = new Point(cellBounds.X, cellBounds.Y + cellBounds.Height);
                offsetLocation.Offset(dgvBooking.Location);
                Booking.Location = offsetLocation;
                int BookingID = (Convert.ToInt32(dgvBooking.CurrentRow.Cells["BookingID"].Value.ToString()));

                DataGridView DGV = ((HRS1.Booking.ctl_Booking)(Booking)).dgvBooking1;
                SPString = string.Format("SP_Select_BookingDetail N'{0}',N'{1}',N'{2}'", BookingID, "0", "1");
                DGV.DataSource = obj_clsMainDB.SelectData(SPString);
                DGV.Columns[0].Visible = false;
                DGV.Columns[1].Width = (DGV.Width / 100) * 17;
                DGV.Columns[2].Width = (DGV.Width / 100) * 17;
                DGV.Columns[3].Width = (DGV.Width / 100) * 10;
                DGV.Columns[4].Width = (DGV.Width / 100) * 10;
                DGV.Columns[5].Width = (DGV.Width / 100) * 10;
                DGV.Columns[6].Width = (DGV.Width / 100) * 15;
                DGV.Columns[7].Width = (DGV.Width / 100) * 10;
                DGV.Columns[8].Width = (DGV.Width / 100) * 10;


                Booking.Show();
                dgvBooking[e.ColumnIndex, e.RowIndex].Value = "-";
            
            }*/
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBooking_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {

                Rectangle cellBounds = dgvBooking.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point offsetLocation = new Point(cellBounds.X, cellBounds.Y + cellBounds.Height);
                offsetLocation.Offset(dgvBooking.Location);
                Booking.Location = offsetLocation;
                int BookingID = (Convert.ToInt32(dgvBooking.CurrentRow.Cells["BookingID"].Value.ToString()));

                DataGridView DGV = ((HRS1.Booking.ctl_Booking)(Booking)).dgvBooking1;
                SPString = string.Format("SP_Select_BookingDetail N'{0}',N'{1}',N'{2}'", BookingID, "0", "1");
                DGV.DataSource = obj_clsMainDB.SelectData(SPString);
                DGV.Columns[0].Visible = false;
                DGV.Columns[1].Width = (DGV.Width / 100) * 17;
                DGV.Columns[2].Width = (DGV.Width / 100) * 17;
                DGV.Columns[3].Width = (DGV.Width / 100) * 10;
                DGV.Columns[4].Width = (DGV.Width / 100) * 10;
                DGV.Columns[5].Width = (DGV.Width / 100) * 10;
                DGV.Columns[6].Width = (DGV.Width / 100) * 15;
                DGV.Columns[7].Width = (DGV.Width / 100) * 10;
                DGV.Columns[8].Width = (DGV.Width / 100) * 10;


                Booking.Show();

            }
        }

        private void detailHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Booking.Hide();
        }
    }
}
