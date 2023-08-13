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
    public partial class frm_RoomTypeList : Form
    {
        public frm_RoomTypeList()
        {
            InitializeComponent();
        }
        clsMainDB obj_clsMainDB = new clsMainDB();
        clsRoomType obj_clsRoomType = new clsRoomType();
        string SPString = "";
        DataTable DT = new DataTable();


        private void ShowData()
        {
            SPString = string.Format("SP_Select_RoomType N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            dgvRoomType.DataSource = obj_clsMainDB.SelectData(SPString);


            dgvRoomType.Columns[0].Width = (dgvRoomType.Width / 100) * 15;
            dgvRoomType.Columns[1].Visible = false;
            dgvRoomType.Columns[2].Width = (dgvRoomType.Width / 100) * 50;
            dgvRoomType.Columns[3].Width = (dgvRoomType.Width / 100) * 35;

            dgvRoomType.Columns[0].ReadOnly = true;
            dgvRoomType.Columns[1].ReadOnly = true;
            dgvRoomType.Columns[2].ReadOnly = true;
            dgvRoomType.Columns[3].ReadOnly = true;

            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "RoomType");
            tslLabel.Text = "RoomType";
        }
        private void ShowEntry()
        {
            if (dgvRoomType.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frm_RoomUpdate frm = new frm_RoomUpdate();
                frm._RoomTypeID = Convert.ToInt32(dgvRoomType.CurrentRow.Cells["RoomTypeID"].Value.ToString());
                frm.txtRoomType.Text = dgvRoomType.CurrentRow.Cells["RoomType"].Value.ToString();
                frm.txtPrice.Text = dgvRoomType.CurrentRow.Cells["Price"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslLabel.Text == "RoomType")
            {
                SPString = string.Format("SP_Select_RoomType N'{0}',N'{1}',N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "2");
            }
            dgvRoomType.DataSource = obj_clsMainDB.SelectData(SPString);
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
           frm_RoomType frm = new frm_RoomType();
            frm.ShowDialog();
            ShowData();
        }

        private void dgvRoomType_DoubleClick(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string _RoomTypeID = dgvRoomType.CurrentRow.Cells["RoomTypeID"].Value.ToString();
            if (_RoomTypeID == string.Empty)
            {
                MessageBox.Show("There Is No Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    obj_clsRoomType.ROOMTYPEID = Convert.ToInt32(_RoomTypeID);
                    obj_clsRoomType.ACTION = 2;
                    obj_clsRoomType.SaveData();
                    MessageBox.Show("Successfully Delete", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_RoomTypeList_Load(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
