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

namespace HRS1.Customer
{
    public partial class frm_CustomerList : Form
    {
        public frm_CustomerList()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsCustomer obj_clsCustomer = new clsCustomer();
        string SPString = "";
        DataTable DT = new DataTable();

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Customer N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            dgvCustomer.DataSource = obj_clsMainDB.SelectData(SPString);


            dgvCustomer.Columns[0].Width = (dgvCustomer.Width / 100) * 10;
            dgvCustomer.Columns[1].Visible = false;
            dgvCustomer.Columns[2].Width = (dgvCustomer.Width / 100) * 10;
            dgvCustomer.Columns[3].Width = (dgvCustomer.Width / 100) * 10;
            dgvCustomer.Columns[4].Width = (dgvCustomer.Width / 100) * 30;
            dgvCustomer.Columns[5].Width = (dgvCustomer.Width / 100) * 20;
            dgvCustomer.Columns[6].Width = (dgvCustomer.Width / 100) * 20;


            dgvCustomer.Columns[0].ReadOnly = true;
            dgvCustomer.Columns[1].ReadOnly = true;
            dgvCustomer.Columns[2].ReadOnly = true;
            dgvCustomer.Columns[3].ReadOnly = true;
            dgvCustomer.Columns[4].ReadOnly = true;
            dgvCustomer.Columns[5].ReadOnly = true;
            dgvCustomer.Columns[6].ReadOnly = true;

            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "CusName");
            tslLabel.Text = "CustomerName";
        }
        private void ShowEntry()
        {
            if (dgvCustomer.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frm_Customer frm = new frm_Customer();
                frm._CusID = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["CusID"].Value.ToString());
                frm.txtCusName.Text = dgvCustomer.CurrentRow.Cells["CusName"].Value.ToString();
                frm.txtEmail.Text = dgvCustomer.CurrentRow.Cells["Email"].Value.ToString();
                frm.txtAddress.Text = dgvCustomer.CurrentRow.Cells["Address"].Value.ToString();
                frm.txtNRC.Text = dgvCustomer.CurrentRow.Cells["NRC"].Value.ToString();
                frm.txtPhNo.Text = dgvCustomer.CurrentRow.Cells["PhNo"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void frm_CustomerList_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frm_Customer frm = new frm_Customer();
            frm.ShowDialog();
            ShowData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string _CusID = dgvCustomer.CurrentRow.Cells["CusID"].Value.ToString();
            if (_CusID == string.Empty)
            {
                MessageBox.Show("There Is No Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    obj_clsCustomer.CUSID = Convert.ToInt32(_CusID);
                    obj_clsCustomer.ACTION = 2;
                    obj_clsCustomer.SaveData();
                    MessageBox.Show("Successfully Delete", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslLabel.Text == "CustomerName")
            {
                SPString = string.Format("SP_Select_Customer N'{0}',N'{1}',N'{2}'", tstSearchWith.Text.Trim().ToString(), "0", "2");
            }
            dgvCustomer.DataSource = obj_clsMainDB.SelectData(SPString);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
