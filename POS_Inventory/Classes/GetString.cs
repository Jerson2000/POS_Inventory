using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory.Classes
{
    public class GetString
    {
        public string DBConn()
        {
            string conn = @"Data Source=DESKTOP-F25K07A\SQLEXPRESS;Initial Catalog=POS_Inventory;Integrated Security=True";
            return conn;
        }

        public string GetTitle()
        {
            string _title = "POS & Inventory System";
            return _title;
        }
    }
}
