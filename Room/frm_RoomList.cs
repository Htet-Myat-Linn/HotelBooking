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

namespace HRS1.Room
{
    public partial class frm_RoomList : Form
    {
        public frm_RoomList()
        {
            InitializeComponent();
        }
        clsMainDB obj_clsMainDB = new clsMainDB();
        clsRoom obj_clsCustomer = new clsRoom();
        string SPString = "";
        DataTable DT = new DataTable();

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Room N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            dgvRoom.DataSource = obj_clsMainDB.SelectData(SPString);


            dgvRoom.Columns[0].Width = (dgvRoom.Width / 100) * 10;
            dgvRoom.Columns[1].Visible = false;
            dgvRoom.Columns[2].Width = (dgvRoom.Width / 100) * 10;
            dgvRoom.Columns[3].Width = (dgvRoom.Width / 100) * 20;
            dgvRoom.Columns[4].Width = (dgvRoom.Width / 100) * 10;
            dgvRoom.Columns[5].Width = (dgvRoom.Width / 100) * 20;
            dgvRoom.Columns[6].Width = (dgvRoom.Width / 100) * 10;
            dgvRoom.Columns[7].Width = (dgvRoom.Width / 100) * 20;
           


            dgvRoom.Columns[1].ReadOnly = true;
            dgvRoom.Columns[2].ReadOnly = true;
            dgvRoom.Columns[3].ReadOnly = true;
            dgvRoom.Columns[4].ReadOnly = true;
            dgvRoom.Columns[5].ReadOnly = true;
            dgvRoom.Columns[6].ReadOnly = true;
            dgvRoom.Columns[6].ReadOnly = true;

            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "RoomNo");
            tslLabel.Text = "RoomNo";
        }
         private void ShowEntry()
        {
            if (dgvRoom.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frm_Room frm = new frm_Room();
                frm._RoomID = Convert.ToInt32(dgvRoom.CurrentRow.Cells["RoomID"].Value.ToString());
                frm.cboEmployeeName.SelectedValue=dgvRoom.CurrentRow.Cells["EmployeeID"].Value.ToString();
                frm.cboEmployeeName.Text = dgvRoom.CurrentRow.Cells["EmployeeName"].Value.ToString();
                frm.cboRoomType.SelectedValue = dgvRoom.CurrentRow.Cells["RoomID"].Value.ToString();
                frm.cboRoomType.Text = dgvRoom.CurrentRow.Cells["RoomType"].Value.ToString();
                frm.txtRoomNo.Text = dgvRoom.CurrentRow.Cells["RoomNo"].Value.ToString();
                frm.cboStatus.Text = dgvRoom.CurrentRow.Cells["Status"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
         }

        private void frm_RoomList_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRoom_DoubleClick(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string _RoomID = dgvRoom.CurrentRow.Cells["RoomID"].Value.ToString();
            if (_RoomID == string.Empty)
            {
                MessageBox.Show("There Is No Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    obj_clsCustomer.ROOMID = Convert.ToInt32(_RoomID);
                    obj_clsCustomer.ACTION = 2;
                    obj_clsCustomer.SaveData();
                    MessageBox.Show("Successfully Delete", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }
        }
        private void roomTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "RoomNo";
            SPString = string.Format("SP_Select_Room N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "RoomNo");
        }
        private void roomTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tslLabel.Text = "RoomType";
            SPString = string.Format("SP_Select_Room N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "RoomType");
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslLabel.Text == "RoomNo")
            {
                SPString = string.Format("SP_Select_Room N'{0}',N'{1}',N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "3");
            }
            else  if (tslLabel.Text == "RoomType")
            {
                SPString = string.Format("SP_Select_Room N'{0}',N'{1}',N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "2");
            }
            dgvRoom.DataSource = obj_clsMainDB.SelectData(SPString);
        }


        private void tsbNew_Click(object sender, EventArgs e)
        {
            frm_Room frm = new frm_Room();
            frm.ShowDialog();
            ShowData();
        }
    }
}
