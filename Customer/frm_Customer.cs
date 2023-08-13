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
    public partial class frm_Customer : Form
    {
        public frm_Customer()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsCustomer obj_clsCustomer = new clsCustomer();
        DataTable DT = new DataTable();
        public bool _IsEdit = false;
        public int _CusID = 0;
        string SPString = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCusName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type CustomerName", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCusName.Focus();
            }
            else if (txtEmail.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Email", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
            else if (txtAddress.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Address", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
            }
            else if (txtNRC.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type NRC", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNRC.Focus();
            }
            else if (txtPhNo.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Phone Number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhNo.Focus();
            }
            else
            {
                SPString = string.Format("SP_Select_Customer N'{0}',N'{1}',N'{2}'", txtCusName.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && _CusID != Convert.ToInt32(DT.Rows[0]["CusID"]))
                {
                    MessageBox.Show("This Customer Already Exist", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCusName.Focus();
                    txtCusName.SelectAll();
                }
                else
                {
                    obj_clsCustomer.CUSID = _CusID;
                    obj_clsCustomer.CUSNAME = txtCusName.Text;
                    obj_clsCustomer.EMAIL = txtEmail.Text;
                    obj_clsCustomer.ADDRESS = txtAddress.Text;
                    obj_clsCustomer.NRC = txtNRC.Text;
                    obj_clsCustomer.PHNO = txtPhNo.Text;

                    if (_IsEdit)
                    {
                        obj_clsCustomer.ACTION = 1;
                        obj_clsCustomer.SaveData();
                        MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        obj_clsCustomer.ACTION = 0;
                        obj_clsCustomer.SaveData();
                        MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void frm_Customer_Load(object sender, EventArgs e)
        {
            txtCusName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
