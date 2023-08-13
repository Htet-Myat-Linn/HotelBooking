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
    class clsBookingDetial
    {
        public int BID { get; set; }
        public int ROOMID { get; set;}
        public int CUSID { get; set; }
        public int TOTALPRICE { get; set; }
        public string SERVICE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();
    

      public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_BookingDetail", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@BookingID", BID);
                sql.Parameters.AddWithValue("@RoomID",ROOMID);
                sql.Parameters.AddWithValue("@CusID",CUSID );
                sql.Parameters.AddWithValue("@TotalPrice", TOTALPRICE);
                sql.Parameters.AddWithValue("@Service", SERVICE);
                sql.Parameters.AddWithValue("action",ACTION);
                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error In Save Data");
            }
            finally
            {
                obj_clsMainDB.con.Close();
            }
        }
    }
}
