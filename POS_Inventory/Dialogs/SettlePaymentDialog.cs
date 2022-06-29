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
using POS_Inventory.ControlsAdmin;
namespace POS_Inventory.Dialogs
{
    public partial class SettlePaymentDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        Cashier frm;
        public SettlePaymentDialog(Cashier f)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            this.frm = f;

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

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double sale = Double.Parse(txtSales.Text);
                double cash = Double.Parse(txtCash.Text);
                double change = cash - sale;
                txtChange.Text = change.ToString("#,##0.00");

            }
            catch(Exception ex)
            {
                txtChange.Text = "0.00";
            }
        }
        #region Keys - Buttons
        private void btn1_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn3.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn4.Text;

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn6.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn9.Text;
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn00.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn0.Text;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtCash.Focus();
            txtCash.Clear();
        }

        #endregion

        // Disable Text Input
        private void txtSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            double change = Double.Parse(txtChange.Text);
            if(change < 0 || txtChange.Text == String.Empty)
            {
                MessageBox.Show("Insufficient amount. Please enter the correct amount!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    for (int i = 0;i < frm.dataGridView1.Rows.Count; i++)
                    {
                        conn.Open();
                        cmd = new SqlCommand("update tbProduct set qty = qty +"+int.Parse(frm.dataGridView1.Rows[i].Cells[5].Value.ToString())+" where pcode = '"+frm.dataGridView1.Rows[i].Cells[2].Value.ToString()+"';", conn);
                        cmd.ExecuteNonQuery();                      
                        conn.Close();

                        conn.Open();
                        cmd = new SqlCommand("update tbCart set status = 'Sold' where id = '"+ frm.dataGridView1.Rows[i].Cells[1].Value.ToString() + "'; ", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    MessageBox.Show("Payment successfully saved!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.LoadTransaction();
                    frm.btnNewTransac.Enabled = true;
                    frm.lbTransNo.Text = "000000000000000000000";
                    this.Dispose();
                }
                catch(Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message,dbcon.GetTitle(),MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
