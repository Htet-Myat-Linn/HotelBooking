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

namespace HRS1.LogIn
{
    public partial class frm_LogIn : Form
    {
        public frm_LogIn()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        DataTable DT = new DataTable();
        public int _EmployeeID = 0;
        String SPString = "";

        private void txtUserName_Click(object sender, EventArgs e)
        {

            txtUserName.Clear();
            txtUserName.Focus();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Main frm = new frm_Main();
            frm.Show();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            clsMainDB obj_clsMainDB = new clsMainDB();
            frm_LogIn obj_frmLogin = new frm_LogIn();
            DataTable DT = new DataTable();
            //String username = "";
            //String password = "";

            if (txtUserName.Text.Trim().ToString() == string.Empty || txtUserName.Text.Trim().ToString() == "UserName")
            {
                MessageBox.Show("Please Enter UserName!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserName.Focus();
            }
            else if (txtPassword.Text.Trim().ToString() == string.Empty || txtPassword.Text.Trim().ToString() == "PassWord")
            {
                MessageBox.Show("Please Enter Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus(); 
            }
            else if (cboUserLevel.Text.Trim().ToString() == "UserLevel")
            {
                MessageBox.Show("Please Choose UserLevel!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboUserLevel.Focus();
            }
            else
            {
                SPString = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", txtUserName.Text.Trim().ToString(), "0", "0", "3");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count == 0)
                {
                    MessageBox.Show("Invaild UserName!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUserName.Focus();
                    txtUserName.DeselectAll();
                }
                else
                {
                    SPString = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", txtPassword.Text.Trim().ToString(), "0", "0", "4");
                    DT = obj_clsMainDB.SelectData(SPString);
                    if (DT.Rows.Count == 0)
                    {
                        MessageBox.Show("Invaild Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPassword.Focus();
                        txtPassword.DeselectAll();
                    }
                    else
                    {
                        SPString = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", cboUserLevel.Text.Trim().ToString(), "0", "0", "5");
                        DT = obj_clsMainDB.SelectData(SPString);
                        if (DT.Rows.Count == 0)
                        {
                            MessageBox.Show("Invaild UserLevel!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboUserLevel.Focus();
                        }
                        else
                        {
                            SPString = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", txtUserName.Text.Trim().ToString(), txtPassword.Text.Trim().ToString(), cboUserLevel.Text.Trim().ToString(), "6");
                            DT = obj_clsMainDB.SelectData(SPString);
                            if (DT.Rows.Count > 0)
                            {
                                switch (cboUserLevel.Text)
                                {
                                    case "Manager":
                                        {
                                            MessageBox.Show("LogIn Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            frm_ManagerBoard frm = new frm_ManagerBoard();
                                            frm.Show();
                                            this.Hide();
                                        }
                                        break;
                                    case "Staff":
                                        {
                                            MessageBox.Show("LogIn Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            frm_StaffBoard frm = new frm_StaffBoard();
                                            frm.Show();
                                            this.Hide();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("LoginFail", "LogInError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void frm_LogIn_Load(object sender, EventArgs e)
        {
            txtUserName.DeselectAll();
            txtPassword.DeselectAll();
        }

    }
}
