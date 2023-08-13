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
    class clsRoomType
    {
        public int ROOMTYPEID { get; set; }
        public string ROOMTYPE { get; set; }
        public int PRICE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseConn();
                SqlCommand Sql = new SqlCommand("SP_Insert_RoomType", obj_clsMainDB.con);
                Sql.CommandType = CommandType.StoredProcedure;
                Sql.Parameters.AddWithValue("@RoomTypeID", ROOMTYPEID);
                Sql.Parameters.AddWithValue("@RoomType", ROOMTYPE);
                Sql.Parameters.AddWithValue("@Price", PRICE);
                Sql.Parameters.AddWithValue("@action", ACTION);
                Sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In RoomType SaveType");
            }
            finally
            {
                obj_clsMainDB.con.Close();
            }
        }
    }
}
