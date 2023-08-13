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

namespace HRS1.Employee
{
    public partial class frm_Employee : Form
    {
        public frm_Employee()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();
        clsEmployee obj_clsEmployee = new clsEmployee();
        DataTable DT = new DataTable();
        public bool _IsEdit = false;
        public int _EmpID = 0;
        string SPString = "";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ok;
            if (txtEmpName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type EmployeeName", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmpName.Focus();
            }
            else if (txtUsername.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type UserName", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else if (txtPassword.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Password", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
            else if (cboUserlevel.Text.Trim().ToString() ==".....Select.....")
            {
                MessageBox.Show("Please Choose UserLevel ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboUserlevel.Focus();
            }

            else if (txtNRC.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type NRC ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNRC.Focus();
            }
            else if (txtAddress.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Address", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
            }
            else if (txtPhno.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Phone Number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhno.Focus();
            }
            else if (txtEmail.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Eamil", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
            else if (txtSalary.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Salary", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalary.Focus();
            }
            else if (int.TryParse(txtSalary.Text, out ok) == false)
            {
                MessageBox.Show("Salary Should Be Number!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalary.Focus();
            }
            else
            {
                SPString = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", txtEmpName.Text.Trim().ToString(), "0", "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && _EmpID != Convert.ToInt32(DT.Rows[0]["EmpID"]))
                {
                    MessageBox.Show("This Employee Already Exist", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEmpName.Focus();
                    txtEmpName.SelectAll();
                }
                else
                {
                    obj_clsEmployee.EMPID = _EmpID;
                    obj_clsEmployee.EMPNAME = txtEmpName.Text;
                    obj_clsEmployee.USERNAME = txtUsername.Text;
                    obj_clsEmployee.PASSWORD = txtPassword.Text;
                    obj_clsEmployee.USERLEVEL = cboUserlevel.Text;
                    obj_clsEmployee.ADDRESS = txtAddress.Text;
                    obj_clsEmployee.PHNO = txtPhno.Text;
                    obj_clsEmployee.NRC = txtNRC.Text;
                    obj_clsEmployee.EMAIL = txtEmail.Text;
                    obj_clsEmployee.JOINDATE = lblJoindate.Text;
                    obj_clsEmployee.SALARY = Convert.ToInt32(txtSalary.Text);
                    obj_clsEmployee.UPDATE = lblUpdate.Text;

                    if (_IsEdit)
                    {
                        obj_clsEmployee.ACTION = 1;
                        obj_clsEmployee.SaveData();
                        MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        obj_clsEmployee.ACTION = 0;
                        obj_clsEmployee.SaveData();
                        MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void frm_Employee_Load(object sender, EventArgs e)
        {
            string Day = string.Format("{0:D2}", DateTime.Now.Day);
            string Month = string.Format("{0:D2}", DateTime.Now.Month);
            string Year = string.Format("{0:D2}", DateTime.Now.Year);
            lblUpdate.Text = Month + "/" + Day + "/" + Year;
            lblJoindate.Text = Month + "/" + Day + "/" + Year;
        }

      
    }
}
