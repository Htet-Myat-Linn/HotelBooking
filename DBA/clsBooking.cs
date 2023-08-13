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
    class clsBooking
    {
        public int BID { get; set; }
        public int EMPID { get; set; }
        public int  CUSID{ get; set; }
        public int  ROOMTYPEID{ get; set; }
        public int ROOID  { get; set; }
        public string CHECKINDAT { get; set; }
        public string CHECKOUTDATE { get; set; }
        public int TOTALNIGHT { get; set; }
        public string SERVICE{ get; set; }
        public int TOTALAMOUNT { get; set; }
        public string BOOKINGDATE { get; set; }
        public int PAYMENT { get; set; }
        public int REFUND { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_Booking", obj_clsMainDB.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@BookingID", BID);
                sql.Parameters.AddWithValue("EmployeeID",EMPID);
                sql.Parameters.AddWithValue("CusID",CUSID);
                sql.Parameters.AddWithValue("RoomTypeID",ROOMTYPEID);
                sql.Parameters.AddWithValue("RoomID",ROOID);
                sql.Parameters.AddWithValue("CheckInDate",CHECKINDAT);
                sql.Parameters.AddWithValue("CheckOutDate",CHECKOUTDATE);
                sql.Parameters.AddWithValue("TotalNight",TOTALNIGHT);
                sql.Parameters.AddWithValue("Service",SERVICE);
                sql.Parameters.AddWithValue("TotalAmount",TOTALAMOUNT);
                sql.Parameters.AddWithValue("BookingDate",BOOKINGDATE);
                sql.Parameters.AddWithValue("Payment",PAYMENT);
                sql.Parameters.AddWithValue("Refund",REFUND);
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
