using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace HRS1.DBA
{
    class clsRoom
    {
        public int ROOMID { get; set; }
        public int EMPLOYEEID { get; set; }
        public string EMPLOYEENAME { get; set; }
        public int ROOMTYPEID { get; set; }
        public string ROOMTYPE { get; set; }
        public string ROOMNO { get; set; }
        public string STATUS { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_Room", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@RoomID", ROOMID);
                sql.Parameters.AddWithValue("@EmployeeID", EMPLOYEEID);
                sql.Parameters.AddWithValue("@EmployeeName", EMPLOYEENAME);
                sql.Parameters.AddWithValue("@RoomTypeID", ROOMTYPEID);
                sql.Parameters.AddWithValue("@RoomType", ROOMTYPE);
                sql.Parameters.AddWithValue("@RoomNo", ROOMNO);
                sql.Parameters.AddWithValue("@Status", STATUS);
                sql.Parameters.AddWithValue("@action", ACTION);
                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error In Sava Data");
            }
            finally
            {
                obj_clsMainDB.con.Close();
            }
        }
    }
}
