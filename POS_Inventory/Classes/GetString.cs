using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace POS_Inventory.Classes
{
    public class GetString
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
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
        public double GetVat()
        {
            double _vat = 0;
            conn = new SqlConnection(DBConn());
            conn.Open();
            cmd = new SqlCommand("select * from tbVat",conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _vat = Double.Parse(dr["vat"].ToString());
            }
            dr.Close();
            conn.Close();

            return _vat;
        }
    }
}
