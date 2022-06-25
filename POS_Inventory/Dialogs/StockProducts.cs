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
using POS_Inventory.ControlsAdmin;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace POS_Inventory.Dialogs
{
    public partial class StockProducts : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        StockIn f;
        public StockProducts(StockIn f)
        {
            InitializeComponent();
            this.f = f;
            conn = new SqlConnection(dbcon.DBConn());
            LoadData("");
        }
        #region Drag Form 
        // Drag Form 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colSelect")
            {
                if (f.txtRefno.Text == String.Empty || f.txtStockBy.Text == String.Empty)
                {
                    MessageBox.Show("Missing Required fields!", dbcon.GetTitle());
                }
                else if (MessageBox.Show("Add this item ?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into tbStock (refno,pcode,sdate,stock_in_by) values (@refno,@pcode,@sdate,@stockby)", conn);
                    cmd.Parameters.AddWithValue("@refno", f.txtRefno.Text);
                    cmd.Parameters.AddWithValue("@pcode", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@sdate", f.dtStockDate.Value);
                    cmd.Parameters.AddWithValue("@stockby", f.txtStockBy.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully Added", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadData();
                }
            }
        }
        public void LoadData(string input)
        {
            dataGridView1.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("select tbProduct.pcode,tbProduct.pdesc, tbProduct.qty from tbProduct " +
                "where (pdesc like '%" + input + "%' or pcode like '%" + input + "%' or qty like '%" + input + "%')", conn);
            dr = cmd.ExecuteReader();
            int i = 1; // Number of items/Rows
            while (dr.Read())
            {
                dataGridView1.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString());
                i++;
            }

            dr.Close();
            conn.Close();
        }

        private void metroTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            LoadData(metroTextBox1.Text);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
