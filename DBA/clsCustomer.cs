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
    class clsCustomer
    {
        public int CUSID { get; set; }
        public string CUSNAME { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string NRC { get; set; }
        public string PHNO { get; set; }
        public int ACTION { get; set; }


        clsMainDB obj_clsMainDB = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainDB.DataBaseConn();
                SqlCommand Sql = new SqlCommand("SP_Insert_Customer", obj_clsMainDB.con);
                Sql.CommandType = CommandType.StoredProcedure;
                Sql.Parameters.AddWithValue("@CusID", CUSID);
                Sql.Parameters.AddWithValue("@CusName", CUSNAME);
                Sql.Parameters.AddWithValue("@Address", ADDRESS);
                Sql.Parameters.AddWithValue("@Email", EMAIL);
                Sql.Parameters.AddWithValue("@NRC", NRC);
                Sql.Parameters.AddWithValue("PhNo", PHNO);
                Sql.Parameters.AddWithValue("@action", ACTION);
                Sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In Customer SaveData");
            }
            finally
            {
                obj_clsMainDB.con.Close();
            }
        }
    }
}
