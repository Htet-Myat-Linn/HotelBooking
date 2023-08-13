using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRS1.Room;
using HRS1.Customer;
using HRS1.LogIn;
using HRS1.Service;
using HRS1.Employee;
using HRS1.Booking;

namespace HRS1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_ManagerBoard());
        }
    }
}
