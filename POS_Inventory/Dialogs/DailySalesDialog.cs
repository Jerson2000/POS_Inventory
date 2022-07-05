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

namespace POS_Inventory.Dialogs
{
    public partial class DailySalesDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public DailySalesDialog()
        {
            InitializeComponent();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            conn = new SqlConnection(dbcon.DBConn());
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;
            LoadData();
            LoadCashier();
            if (Cashier._cashier != String.Empty)
            {
                cbCashier.Text = Cashier._cashier;
            }
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;


            }
            else
            {


                this.WindowState = FormWindowState.Maximized;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;

            }
        }
        public void LoadData()
        {
            try
            {
                double _total = 0;
                dataGridView1.Rows.Clear();
                conn.Open();
                if(cbCashier.Text == "All Cashier")
                {
                    cmd = new SqlCommand("select tbCart.id,tbCart.transno,tbCart.pcode,tbProduct.pdesc,tbCart.price,tbCart.qty,tbCart.disc,tbCart.total from tbCart left join tbProduct on tbCart.pcode = tbProduct.pcode where status like 'Sold%' and tbCart.sdate between '" + dateStart.Value.ToString("yyyy-MM-dd") + "' and '" + dateEnd.Value.ToString("yyyy-MM-dd") + "';", conn); //
                }
                else
                {
                    cmd = new SqlCommand("select tbCart.id,tbCart.transno,tbCart.pcode,tbProduct.pdesc,tbCart.price,tbCart.qty,tbCart.disc,tbCart.total from tbCart left join tbProduct on tbCart.pcode = tbProduct.pcode where status like 'Sold%' and tbCart.sdate between '" + dateStart.Value.ToString("yyyy-MM-dd") + "' and '" + dateEnd.Value.ToString("yyyy-MM-dd") + "'  and cashier like '" + cbCashier.Text + "';", conn); //
                }
                
                dr = cmd.ExecuteReader();
                int i = 1;
                while (dr.Read())
                {
                    i++;
                    _total += Double.Parse(dr["total"].ToString());
                    dataGridView1.Rows.Add(i, dr["id"].ToString(),dr["transno"].ToString(),dr["pcode"].ToString(),dr["pdesc"].ToString(),dr["price"].ToString(),dr["qty"].ToString(),dr["disc"].ToString(),dr["total"]);
                }
                dr.Close();
                conn.Close();
                lbTotal.Text = _total.ToString("#,##0.00");
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, dbcon.GetTitle());

            }
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
      

        private void iconButton2_Click(object sender, EventArgs e)
        {
            SoldItemsReport f = new SoldItemsReport(this);
            f.LoadData();
            f.ShowDialog();
        }

        private void cbCashier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public void LoadCashier()
        {
            try
            {
                cbCashier.Items.Clear();
                conn.Open();
                cmd = new SqlCommand("select * from tbUser where role ='Cashier'",conn);
                dr = cmd.ExecuteReader();
                cbCashier.Items.Add("All Cashier");
                while (dr.Read())
                {
                    cbCashier.Items.Add(dr["name"].ToString());
                }
                dr.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cbCashier_SelectedIndexChanged(object sender, EventArgs e)
        {         
            
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "colCancel")
            {
                CancelSaleDialog f = new CancelSaleDialog();
                f.txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.txtTransno.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                f.txtPCode.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                f.txtPDesc.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.txtQty.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                f.txtDisc.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                f.txtTotal.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                f.txtCancelBy.Text = Cashier._cashier;
                f.ShowDialog();
            }

        }
    }
}
