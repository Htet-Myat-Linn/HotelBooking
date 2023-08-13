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
    class clsEmployee
    {
        public int EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string USERLEVEL { get; set; }
        public string ADDRESS { get; set; }
        public string PHNO { get; set; }
        public string NRC { get; set; }
        public string EMAIL { get; set; }
        public string JOINDATE { get; set; }
        public int SALARY { get; set; }
        public string UPDATE { get; set; }
        public int ACTION { get; set; }

        clsMainDB obj_clsMainBD = new clsMainDB();

        public void SaveData()
        {
            try
            {
                obj_clsMainBD.DataBaseConn();
                SqlCommand sql = new SqlCommand("SP_Insert_Employee", obj_clsMainBD.con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@EmployeeID", EMPID);
                sql.Parameters.AddWithValue("@EmployeeName", EMPNAME);
                sql.Parameters.AddWithValue("@UserName", USERNAME);
                sql.Parameters.AddWithValue("@Password", PASSWORD);
                sql.Parameters.AddWithValue("@UserLevel", USERLEVEL);
                sql.Parameters.AddWithValue("@Address", ADDRESS);
                sql.Parameters.AddWithValue("@PhNo", PHNO);
                sql.Parameters.AddWithValue("@NRC", NRC);
                sql.Parameters.AddWithValue("@Email", EMAIL);
                sql.Parameters.AddWithValue("@JoinDate", JOINDATE);
                sql.Parameters.AddWithValue("@Salary", SALARY);
                sql.Parameters.AddWithValue("@UpdateDate", UPDATE);
                sql.Parameters.AddWithValue("@action", ACTION);
                sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error In Employee SaveData");
            }
            finally
            {
                obj_clsMainBD.con.Close();
            }
        }
    }
}
