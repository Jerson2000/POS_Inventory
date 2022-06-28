using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using POS_Inventory.Classes;
using POS_Inventory.Dialogs;
using POS_Inventory.ControlsCashier;


namespace POS_Inventory.Dialogs
{
    public partial class SearchProductDialog : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        Cashier tr;
        public SearchProductDialog(Cashier frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            this.tr = frm;
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
        public void LoadData(string input)
        {
            /*
             * Select Query - select tbProduct.pcode,tbProduct.pdesc,tbBrand.brand,tbCategory.category,tbProduct.price,tbProduct.qty from tbProduct 
             * left join tbBrand on tbProduct.brand_id = tbBrand.brand_id left join tbCategory on tbProduct.cat_id = tbCategory.cat_id;
             */
            dataGridView1.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("select tbProduct.pcode,tbProduct.pdesc,tbBrand.brand,tbCategory.category,tbProduct.price,tbProduct.qty from tbProduct " +
                "left join tbBrand on tbProduct.brand_id = tbBrand.brand_id left join tbCategory on tbProduct.cat_id = tbCategory.cat_id where (pdesc like '%" + input + "%' or pcode like '%" + input + "%' or brand like '%" + input + "%' or category like '%" + input + "%')", conn);
            dr = cmd.ExecuteReader();
            int i = 1; // Number of items/Rows
            while (dr.Read())
            {
                dataGridView1.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["brand"].ToString(), dr["category"].ToString(), dr["price"].ToString(), dr["qty"].ToString());
                i++;
            }

            dr.Close();
            conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colCart")
            {

                if(Cashier._transNo != "000000000000000000000")
                {
                    conn.Open();
                    cmd = new SqlCommand("select pcode from tbCart where pcode = '"+ dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("Item is already in the list", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        QtyDialog f = new QtyDialog(tr);
                        f.GetDetails(Cashier._transNo, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                        f.ShowDialog();
                    }
                    conn.Close();
                  
                }
                else
                {
                    MessageBox.Show("Don't have a current transaction, cannot proceed!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

            }
        }

        private void metroTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            LoadData(metroTextBox1.Text);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }
    }

}
