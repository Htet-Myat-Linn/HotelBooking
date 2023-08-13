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
    public partial class frm_Room : Form
    {
        public frm_Room()
        {
            InitializeComponent();
        }

        clsRoom obj_Room = new clsRoom();
        clsMainDB obj_clsMain = new clsMainDB();
       public int _RoomID = 0;
        string SPString = "";
        DataTable DT = new DataTable();
        public bool _IsEdit = false;


        public void ShowData()
        {
            SPString = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", "0", "0", "0", "7");
            obj_clsMain.AddCombo(ref cboEmployeeName, SPString, "EmployeeName", "EmployeeID");

            SPString = string.Format("SP_Select_RoomType N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            obj_clsMain.AddCombo(ref cboRoomType, SPString, "RoomType", "RoomTypeID");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboEmployeeName.Text.Trim().ToString() == ".....Select.....")
            {
                MessageBox.Show("Please Choose EmployeeName!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEmployeeName.Focus();
            }
            else if (cboRoomType.Text.Trim().ToString() == ".....Select.....")
            {
                MessageBox.Show("Please Choose RoomType!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboRoomType.Focus();
            }
            else if (txtRoomNo.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Enter RoomNo!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRoomNo.Focus();
            }
            else if (cboStatus.Text.Trim().ToString() == ".....Select.....")
            {
                MessageBox.Show("Please Choose Status!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboStatus.Focus();
            }
            else
            {
                SPString = string.Format("SP_Select_Room N'{0}',N'{1}',N'{2}'", txtRoomNo.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMain.SelectData(SPString);

                if (DT.Rows.Count > 0 && _RoomID != Convert.ToInt32(DT.Rows[0]["RoomID"]))
                {
                    MessageBox.Show("This RoomNo Already Exist!");
                    txtRoomNo.Focus();
                    txtRoomNo.SelectAll();
                }
                else
                {
                    obj_Room.ROOMID = _RoomID;
                    //string SPString1 = string.Format("SP_Select_Employee N'{0}',N'{1}',N'{2}',N'{3}'", cboEmployeeName.SelectedItem.ToString(), "0", "0", "8");
                    // DT = obj_clsMain.SelectData(SPString1);
                    obj_Room.EMPLOYEEID = Convert.ToInt32(cboEmployeeName.SelectedValue);
                    obj_Room.EMPLOYEENAME = cboEmployeeName.Text.Trim().ToString();
                    // string SPString2 = string.Format("SP_Select_RoomType N'{0}',N'{1}',N'{2}'", cboRoomType.SelectedItem.ToString(), "0", "3");
                    // DT = obj_clsMain.SelectData(SPString2);
                    obj_Room.ROOMTYPEID = Convert.ToInt32(cboRoomType.SelectedValue);
                    obj_Room.ROOMTYPE = cboRoomType.Text.Trim().ToString();
                    obj_Room.ROOMNO = txtRoomNo.Text.Trim().ToString();
                    obj_Room.STATUS = cboStatus.Text.Trim().ToString();

                    if (_IsEdit)
                    {
                         if (cboEmployeeName.Text.Trim().ToString() == ".....Select.....")
                        {
                            MessageBox.Show("Please Choose EmployeeName!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboEmployeeName.Focus();
                        }
                        else if (cboRoomType.Text.Trim().ToString() == ".....Select.....")
                        {
                            MessageBox.Show("Please Choose RoomType!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboRoomType.Focus();
                        }
                        else
                        {
                            obj_Room.ACTION = 1;
                            obj_Room.SaveData();
                            MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        obj_Room.ACTION = 0;
                        obj_Room.SaveData();
                        MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void frm_Room_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
