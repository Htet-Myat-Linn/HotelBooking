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
    public partial class frm_EmployeeList : Form
    {
        public frm_EmployeeList()
        {
            InitializeComponent();
        }
        clsMainDB obj_clsMainDB = new clsMainDB();
        clsEmployee obj_clsEmployee = new clsEmployee();
        string SPString = "";
        DataTable DT = new DataTable();


        private void ShowData()
        {
            SPString = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", "0", "0", "0","0");
            dgvEmployee.DataSource = obj_clsMainDB.SelectData(SPString);


            dgvEmployee.Columns[0].Width = (dgvEmployee.Width / 100) * 2;
            dgvEmployee.Columns[1].Visible = false;
            dgvEmployee.Columns[2].Width = (dgvEmployee.Width / 100) * 8;
            dgvEmployee.Columns[3].Width = (dgvEmployee.Width / 100) * 5;
            dgvEmployee.Columns[4].Width = (dgvEmployee.Width / 100) * 5;
            dgvEmployee.Columns[5].Width = (dgvEmployee.Width / 100) * 10;
            dgvEmployee.Columns[6].Width = (dgvEmployee.Width / 100) * 10;
            dgvEmployee.Columns[7].Width = (dgvEmployee.Width / 100) * 10;
            dgvEmployee.Columns[8].Width = (dgvEmployee.Width / 100) * 10;
            dgvEmployee.Columns[9].Width = (dgvEmployee.Width / 100) * 15;
            dgvEmployee.Columns[10].Width = (dgvEmployee.Width / 100) * 10;
            //dgvEmployee.Columns[11].Width = (dgvEmployee.Width / 100) * 5;
            dgvEmployee.Columns[12].Width = (dgvEmployee.Width / 100) * 10;
          

            dgvEmployee.Columns[0].ReadOnly = true;
            dgvEmployee.Columns[1].ReadOnly = true;
            dgvEmployee.Columns[2].ReadOnly = true;
            dgvEmployee.Columns[3].ReadOnly = true;
            dgvEmployee.Columns[4].ReadOnly = true;
            dgvEmployee.Columns[5].ReadOnly = true;
            dgvEmployee.Columns[6].ReadOnly = true;
            dgvEmployee.Columns[7].ReadOnly = true;
            dgvEmployee.Columns[8].ReadOnly = true;
            dgvEmployee.Columns[9].ReadOnly = true;
            dgvEmployee.Columns[10].ReadOnly = true;
            dgvEmployee.Columns[11].ReadOnly = true;
            dgvEmployee.Columns[12].ReadOnly = true;


            obj_clsMainDB.ToolStripTextBoxData(ref tstSearchWith, SPString, "EmployeeName");
            tslLabel.Text = "EmployeeName";
        }

        private void frm_EmployeeList_Load(object sender, EventArgs e)
        {
            ShowData();
        }
        private void ShowEntry()
        {
            if (dgvEmployee.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There Is No Data", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frm_EmployeeUpdate frm = new frm_EmployeeUpdate();
                frm._EmpID = Convert.ToInt32(dgvEmployee.CurrentRow.Cells["EmployeeID"].Value.ToString());
                frm.txtEmpName.Text = dgvEmployee.CurrentRow.Cells["EmployeeName"].Value.ToString();
                frm.txtUsername.Text = dgvEmployee.CurrentRow.Cells["UserName"].Value.ToString();
                frm.txtPassword.Text = dgvEmployee.CurrentRow.Cells["Password"].Value.ToString();
                frm.cboUserlevel.Text = dgvEmployee.CurrentRow.Cells["Userlevel"].Value.ToString();
                frm.txtAddress.Text = dgvEmployee.CurrentRow.Cells["Address"].Value.ToString();
                frm.txtPhno.Text = dgvEmployee.CurrentRow.Cells["PhNo"].Value.ToString();
                frm.txtNRC.Text = dgvEmployee.CurrentRow.Cells["NRC"].Value.ToString();
                frm.txtEmail.Text = dgvEmployee.CurrentRow.Cells["Email"].Value.ToString();
                frm.lblJoindate.Text = dgvEmployee.CurrentRow.Cells["JoinDate"].Value.ToString();
                frm.txtSalary.Text = dgvEmployee.CurrentRow.Cells["Salary"].Value.ToString();
                frm.lblUpdate.Text = dgvEmployee.CurrentRow.Cells["UpdateDate"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEmployee_DoubleClick(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string _EmpID = dgvEmployee.CurrentRow.Cells["EmployeeID"].Value.ToString();
            if (_EmpID == string.Empty)
            {
                MessageBox.Show("There Is No Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    obj_clsEmployee.EMPID = Convert.ToInt32(_EmpID);
                    obj_clsEmployee.ACTION = 2;
                    obj_clsEmployee.SaveData();
                    MessageBox.Show("Successfully Delete", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frm_Employee frm = new frm_Employee();
            frm.ShowDialog();
            ShowData();
        }

        private void tstSearchWith_TextChanged(object sender, EventArgs e)
        {
            if (tslLabel.Text == "EmployeeName")
            {
                SPString = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", tstSearchWith.Text.Trim().ToString(), "0","0", "2");
            }
            dgvEmployee.DataSource = obj_clsMainDB.SelectData(SPString);
        }
    }
}
