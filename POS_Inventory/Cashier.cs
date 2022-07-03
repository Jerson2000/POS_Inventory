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
using POS_Inventory.Dialogs;
using System.Data.SqlClient;
using POS_Inventory.Classes;
namespace POS_Inventory
{
    public partial class Cashier : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public static string _transNo ="";
        string _id = "";
        string _price;
        string _desc;
        public Cashier()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            lbDate.Text = DateTime.Now.ToLongDateString();
            LoadTransaction();
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

        #region Control Box
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;


            }
            else
            {


                this.WindowState = FormWindowState.Maximized;
                iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        #endregion
        // Toggle Menu Btn
        private void menuBtn_Click(object sender, EventArgs e)
        {
            // w x h - 279, 599 - panel2 size
            if (panel2.Size.Width == 279)
            {
                panel2.Size = new System.Drawing.Size(0, 599);
            }
            else if (panel2.Size.Width == 0)
            {
                panel2.Size = new System.Drawing.Size(279, 599);
            }
        }

        private void btnNewTransac_Click(object sender, EventArgs e)
        {
            if(lbTransNo.Text == "000000000000000000000")
            {
                GetTransNo();
                btnNewTransac.Enabled = false;
            }           
                    
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {

            SearchProductDialog f = new SearchProductDialog(this);
            _transNo = lbTransNo.Text;
            f.ShowDialog();


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
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message.ToString(), dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void LoadTransaction()
        {
            try
            {
                bool hasRecord = false;
                dataGridView1.Rows.Clear();
                double total = 0;
                double discount = 0;
                conn.Open();
                cmd = new SqlCommand("select tbCart.id,tbCart.pcode,tbProduct.pdesc,tbCart.price,tbCart.qty,tbCart.disc,tbCart.total from tbCart left join tbProduct on tbCart.pcode = tbProduct.pcode where transno like '" + lbTransNo.Text + "%' and status='Pending';", conn); //
                dr = cmd.ExecuteReader();
                int i = 1; // Number of items/Rows
                while (dr.Read())
                {
                    total += Double.Parse(dr["total"].ToString());
                    discount += Double.Parse(dr["disc"].ToString());
                    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), Double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                    i++;
                    hasRecord = true;
                }

                dr.Close();
                conn.Close();
                lbDiscount.Text = discount.ToString("#,##0.00");
                lbSalesAmount.Text = total.ToString("#,##0.00");
                GetTotal();
                
                if(hasRecord == true) 
                { 
                    btnSettlePayment.Enabled = true; btnDiscount.Enabled = true; 
                }
                else 
                {
                    btnSettlePayment.Enabled = false;
                    btnDiscount.Enabled = false;
                }
                
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message.ToString(), dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           

        }
        private void GetTotal()
        {
            double sales, discount, vat, vatable,subtotal;

            subtotal = Double.Parse(lbSalesAmount.Text);
            discount = Double.Parse(lbDiscount.Text);
            sales = Double.Parse(lbSalesAmount.Text) - discount;            
            vat = sales * dbcon.GetVat();
            vatable = sales - vat;
            lbSalesAmount.Text = sales.ToString("#,##0.00");
            lbTotalAmount.Text = sales.ToString("#,##0.00");
            lbVat.Text = vat.ToString("#,##0.00");
            lbVatable.Text = vatable.ToString("#,##0.00");
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colDelete")
            {
                if (MessageBox.Show("Remove this item from the list?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from tbCart where id ='" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Item successfully removed", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransaction();
                }

            }
            if (colName == "colMinusQty")
            {

                int qty = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                if (qty > 1)
                {
                    conn.Open();
                    cmd = new SqlCommand("update tbCart set qty-=1 where id ='" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadTransaction();
                }
                else
                {
                    MessageBox.Show("Quantity cannot be less than 1!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

            if (colName == "colAddQty")
            {

                int qty = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                conn.Open();
                cmd = new SqlCommand("update tbCart set qty+=1 where id ='" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadTransaction();


            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            if(_id != String.Empty)
            {
                DiscountDialog f = new DiscountDialog(this);
                f.lbID.Text = _id;
                f.lbItemD.Text = _desc;
                f.txtPrice.Text = _price;
                f.ShowDialog();

            }
            else
            {
                MessageBox.Show("No current item/s selected!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            _id = dataGridView1[1, i].Value.ToString();
            _desc = dataGridView1[3,i].Value.ToString();
            _price = dataGridView1[4, i].Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbDateNow.Text = DateTime.Now.ToLongDateString();
            lbTime.Text = DateTime.Now.ToString("hh:MM:ss tt");
        }

        private void btnSettlePayment_Click(object sender, EventArgs e)
        {
            if (lbTransNo.Text == "000000000000000000000")
            {
                MessageBox.Show("No current transaction!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SettlePaymentDialog f = new SettlePaymentDialog(this);
                f.txtSales.Text = lbTotalAmount.Text;
                f.ShowDialog();
            }
           
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            DailySalesDialog f = new DailySalesDialog();
            f.ShowDialog();
        }
    }

}
