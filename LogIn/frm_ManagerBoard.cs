using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRS1.Room;
using HRS1.Service;
using HRS1.Customer;
using HRS1.Employee;
using HRS1.Booking;
using HRS1.DBA;


namespace HRS1.LogIn
{
    public partial class frm_ManagerBoard : Form
    {
        public frm_ManagerBoard()
        {
            InitializeComponent();
        }
        clsBooking obj_clsBooking = new clsBooking();
        clsBookingDetial obj_clsBookingDetail = new clsBookingDetial();
        clsRoom obj_clsRoom = new clsRoom();
        clsMainDB obj_clsMainDB = new clsMainDB();
        public UserControl Booking;

        string SPString = "";
        private void mnuRoomType_Click(object sender, EventArgs e)
        {
            frm_RoomTypeList frm = new frm_RoomTypeList();
            frm.Show();
        }

        private void mnuRoom_Click(object sender, EventArgs e)
        {
            frm_RoomList frm = new frm_RoomList();
            frm.ShowDialog();
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            frm_CustomerList frm = new frm_CustomerList();
            frm.Show();
        }

        private void mnuService_Click(object sender, EventArgs e)
        {
            frm_ServiceList frm = new frm_ServiceList();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuEmployee_Click(object sender, EventArgs e)
        {
            frm_EmployeeList frm = new frm_EmployeeList();
            frm.Show();
        }

        private void mnuBooking_Click(object sender, EventArgs e)
        {
            frm_Booking frm = new frm_Booking();
            frm.ShowDialog();
        }


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
            Controls.SetChildIndex(Booking, 0);

        }


        private void frm_ManagerBoard_Load(object sender, EventArgs e)
        {
            ShowBooking();
            ShowBookingDetail();
        }

        private void mnuDetailHide_Click(object sender, EventArgs e)
        {
            Booking.Hide();
        }


        private void dgvBooking_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
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
    }
}
