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
    public partial class frm_Service : Form
    {
        public frm_Service()
        {
            InitializeComponent();
        }
        clsMainDB obj_clsMainDB = new clsMainDB();
        clsService obj_clsService = new clsService();
        DataTable DT = new DataTable();
        public bool _IsEdit = false;
        public int _ServiceID = 0;
        string SPString = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
            int OK;
            if (txtServiceName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type ServiceName", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtServiceName.Focus();
            }
            else if (txtPrice.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Price", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
            }
            else if (int.TryParse(txtPrice.Text, out OK) == false)
            {
                MessageBox.Show("Price Should Be Number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                txtPrice.SelectAll();
            }
            else if (Convert.ToInt32(txtPrice.Text) == 0 && (Convert.ToInt32(txtPrice.Text) < 50000 || Convert.ToInt32(txtPrice.Text) > 100000))
            {
                MessageBox.Show("Price Should Be Between 50000 And 1Lakh", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                txtPrice.SelectAll();
            }
            else
            {
                SPString = string.Format("SP_Select_Service N'{0}',N'{1}',N'{2}'", txtServiceName.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && _ServiceID != Convert.ToInt32(DT.Rows[0]["ServiceID"]))
                {
                    MessageBox.Show("This Service Type Already Exist", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtServiceName.Focus();
                    txtServiceName.SelectAll();
                }
                else
                {
                    obj_clsService.SERVICEID = _ServiceID;
                    obj_clsService.SERVICENAME = txtServiceName.Text;
                    obj_clsService.SERVICEPRICE = Convert.ToInt32(txtPrice.Text);

                    if (_IsEdit)
                    {
                        obj_clsService.ACTION = 1;
                        obj_clsService.SaveData();
                        MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        obj_clsService.ACTION = 0;
                        obj_clsService.SaveData();
                        MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void frm_Service_Load(object sender, EventArgs e)
        {
            txtServiceName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
