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
    public partial class frm_RoomType : Form
    {
        public frm_RoomType()
        {
            InitializeComponent();
        }
        clsMainDB obj_clsMainDB = new clsMainDB();
        clsRoomType obj_clsRoomType = new clsRoomType();
        DataTable DT = new DataTable();
        public bool _IsEdit = false;
        public int _RoomTypeID = 0;
        string SPString = "";

        private void frm_RoomType_Load(object sender, EventArgs e)
        {
            txtRoomType.Text = "";
            txtPrice.Text = "";
            txtRoomType.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int OK;
            if (txtRoomType.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type RoomType", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoomType.Focus();
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
            else if (Convert.ToInt32(txtPrice.Text) == 0 && (Convert.ToInt32(txtPrice.Text) < 100000 || Convert.ToInt32(txtPrice.Text) > 300000))
            {
                MessageBox.Show("Price Should Be Between 1Lakh And 3Lakh", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                txtPrice.SelectAll();
            }
            else
            {
                SPString = string.Format("SP_Select_RoomType N'{0}',N'{1}',N'{2}'", txtRoomType.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && _RoomTypeID != Convert.ToInt32(DT.Rows[0]["RoomTypeID"]))
                {
                    MessageBox.Show("This Room Type Already Exist", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRoomType.Focus();
                    txtRoomType.SelectAll();
                }
                else
                {
                    obj_clsRoomType.ROOMTYPEID = _RoomTypeID;
                    obj_clsRoomType.ROOMTYPE = txtRoomType.Text;
                    obj_clsRoomType.PRICE = Convert.ToInt32(txtPrice.Text);

                    if (_IsEdit)
                    {
                        obj_clsRoomType.ACTION = 1;
                        obj_clsRoomType.SaveData();
                        MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        obj_clsRoomType.ACTION = 0;
                        obj_clsRoomType.SaveData();
                        MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
