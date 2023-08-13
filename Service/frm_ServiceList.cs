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

namespace HRS1.Service
{
    public partial class frm_ServiceList : Form
    {
        public frm_ServiceList()
        {
            InitializeComponent();
        }
        clsMainDB obj_clsMainDB = new clsMainDB();
        clsService obj_clsService = new clsService();
        string SPString = "";
        DataTable DT = new DataTable();

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Service N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            dgvService.DataSource = obj_clsMainDB.SelectData(SPString);


            dgvService.Columns[0].Width = (dgvService.Width / 100) * 15;
            dgvService.Columns[1].Visible = false;
            dgvService.Columns[2].Width = (dgvService.Width / 100) * 50;
            dgvService.Columns[3].Width = (dgvService.Width / 100) * 35;

            dgvService.Columns[0].ReadOnly = true;
            dgvService.Columns[1].ReadOnly = true;
            dgvService.Columns[2].ReadOnly = true;
            dgvService.Columns[3].ReadOnly = true;

            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "ServiceName");
            tslLabel.Text = "ServiceName";
        }

        private void ShowEntry()
        {
            if (dgvService.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frm_Service frm = new frm_Service();
                frm._ServiceID = Convert.ToInt32(dgvService.CurrentRow.Cells["ServiceID"].Value.ToString());
                frm.txtServiceName.Text = dgvService.CurrentRow.Cells["ServiceName"].Value.ToString();
                frm.txtPrice.Text = dgvService.CurrentRow.Cells["ServicePrice"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void frm_ServiceList_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frm_Service frm = new frm_Service();
            frm.ShowDialog();
            ShowData();
        }

        private void dgvService_DoubleClick(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslLabel.Text == "ServiceName")
            {
                SPString = string.Format("SP_Select_Service N'{0}',N'{1}',N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "2");
            }
            dgvService.DataSource = obj_clsMainDB.SelectData(SPString);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string _ServiceID = dgvService.CurrentRow.Cells["ServiceID"].Value.ToString();
            if (_ServiceID == string.Empty)
            {
                MessageBox.Show("There Is No Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    obj_clsService.SERVICEID = Convert.ToInt32(_ServiceID);
                    obj_clsService.ACTION = 2;
                    obj_clsService.SaveData();
                    MessageBox.Show("Successfully Delete", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
