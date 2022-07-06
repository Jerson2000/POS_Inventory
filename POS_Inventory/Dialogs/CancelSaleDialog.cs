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

namespace POS_Inventory.Dialogs
{
    public partial class CancelSaleDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        DailySalesDialog f;
        public CancelSaleDialog(DailySalesDialog f)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAdd2Invent.Text != String.Empty || txtReason.Text != String.Empty || txtCancelQty.Text != String.Empty)
                {
                    if(int.Parse(txtQty.Text) >= int.Parse(txtCancelQty.Text))
                    {
                        CancelVoidDialog frm = new CancelVoidDialog(this);
                        frm.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("empty");
                }
            }
            
            catch(Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }
        }
        public void RefreshList()
        {
            f.LoadData();
        }
    }
}
