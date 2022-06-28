using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using POS_Inventory.Classes;


namespace POS_Inventory.ControlsCashier
{
    public partial class Transaction : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public Transaction()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            lbDate.Text = DateTime.Now.ToLongDateString();           
        }
        public void GetTransNo()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                string transno;
                int count;

                conn.Open();
                cmd = new SqlCommand("select top 1 transno from tbCart where transno like '" + sdate + "%' order by id desc", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transno = dr["transno"].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    lbTransNo.Text = sdate + (count + 1);
                }
                else
                {
                    transno = sdate + "1001";
                    lbTransNo.Text = transno;
                }
                dr.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message.ToString(),dbcon.GetTitle(),MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }
        public void LoadTransaction()
        {
            if (Cashier._transNo != "000000000000000000000")
            {
                dataGridView1.Rows.Clear();
                conn.Open();
                cmd = new SqlCommand("select tbCart.id,tbProduct.pdesc,tbCart.price,tbCart.qty,tbCart.disc,tbCart.total from tbCart left join tbProduct on tbCart.pcode = tbProduct.pcode where transno like '&" + lbTransNo.Text + "%' and status='Pending';", conn);
                dr = cmd.ExecuteReader();
                int i = 1; // Number of items/Rows
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
                    i++;
                }

                dr.Close();
                conn.Close();
            }
            
        }
    }
}
