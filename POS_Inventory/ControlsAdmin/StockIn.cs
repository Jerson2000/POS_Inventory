using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_Inventory.Classes;
using POS_Inventory.Dialogs;
using System.Data.SqlClient;
namespace POS_Inventory.ControlsAdmin
{
    public partial class StockIn : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public StockIn()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            LoadData();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            StockProducts f = new StockProducts(this);
            f.ShowDialog();
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("select tbStock.id,tbStock.refno,tbStock.pcode,tbProduct.pdesc,tbStock.qty,tbStock.sdate,tbStock.stock_in_by from tbStock left join tbProduct on tbStock.pcode = tbProduct.pcode where status = 'Pending';", conn);             
            dr = cmd.ExecuteReader();
            int i = 1; // Number of items/Rows
            while (dr.Read())
            {
                dataGridView1.Rows.Add(i, dr["refno"].ToString(), dr["pcode"].ToString(),dr["pdesc"].ToString(), dr["qty"].ToString(), dr["sdate"].ToString(), dr["stock_in_by"].ToString(),dr["id"].ToString());
                i++;
            }
            dr.Close();
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colDelete")
            {
                if (MessageBox.Show("Delete this item ?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from tbStock where id = '" + dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() + "';", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Deleted Successfully", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
