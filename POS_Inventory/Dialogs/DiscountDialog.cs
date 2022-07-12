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
using System.Runtime.InteropServices;

namespace POS_Inventory.Dialogs
{
    public partial class DiscountDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        Cashier f;
        public DiscountDialog(Cashier f)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            this.f = f;
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

        private void txtPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double discount = Double.Parse(txtPrice.Text) * Double.Parse(txtPercent.Text);
                txtDAmount.Text = discount.ToString("#,##.00");
            }
            catch(Exception ex)
            {
                txtPercent.Text = "0.00";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Add discount to this item?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("update tbCart set disc_percent = '"+Double.Parse(txtPercent.Text)+"' where id = '" + lbID.Text + "'",conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Discount successfully added!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadTransaction();
                    this.Close();

                }
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message.ToString(), dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
