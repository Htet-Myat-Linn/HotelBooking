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
    class clsService
    {
        public int SERVICEID { get; set; }
        public string SERVICENAME { get; set; }
        public int SERVICEPRICE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseConn();
                SqlCommand Sql = new SqlCommand("SP_Insert_Service", obj_clsMainDB.con);
                Sql.CommandType = CommandType.StoredProcedure;
                Sql.Parameters.AddWithValue("@ServiceID", SERVICEID);
                Sql.Parameters.AddWithValue("@ServiceName", SERVICENAME);
                Sql.Parameters.AddWithValue("@ServicePrice", SERVICEPRICE);
                Sql.Parameters.AddWithValue("@action", ACTION);
                Sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Service SaveType");
            }
            finally
            {
                obj_clsMainDB.con.Close();
            }
        }
    }
}
