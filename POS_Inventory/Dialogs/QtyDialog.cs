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
using POS_Inventory.ControlsCashier;
using POS_Inventory.Classes;
using System.Runtime.InteropServices;

namespace POS_Inventory.Dialogs
{
    public partial class QtyDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        private string _transno;
        private double _price;
        private string _pcode;
        Cashier f;
        public QtyDialog(Cashier f)
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
        public void GetDetails(string transno,string pcode,string price)
        {
            this._transno = transno;
            this._pcode = pcode;
            this._price = double.Parse(price);
        }       

        private void numQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13) && (numQty.Text != String.Empty))
            {                
                conn.Open();
                cmd = new SqlCommand("insert into tbCart(transno,pcode,price,qty,sdate,cashier) values(@transno,@pcode,@price,@qty,@sdate,@cashier)", conn);
                cmd.Parameters.AddWithValue("@transno", _transno);
                cmd.Parameters.AddWithValue("@pcode", _pcode);
                cmd.Parameters.AddWithValue("@price", _price);
                cmd.Parameters.AddWithValue("@qty", int.Parse(numQty.Text));
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@cashier", f.lbUser.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Item Added!",dbcon.GetTitle(),MessageBoxButtons.OK,MessageBoxIcon.Information);
                f.LoadTransaction();
                this.Close();
            }
        }
    }
}
