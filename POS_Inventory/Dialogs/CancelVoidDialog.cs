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
    public partial class CancelVoidDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        CancelSaleDialog frm;
        
        public CancelVoidDialog(CancelSaleDialog f)
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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string userName;
                conn.Open();
                cmd = new SqlCommand("select * from tbUser where username = @username and password = @password and role like 'System Administrator%'", conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                
                if (dr.HasRows)
                {
                               

                    userName = dr["name"].ToString();
                    conn.Close();
                    SaveCancelOrder(userName);
                    if (frm.cbAdd2Invent.Text == "Yes")
                    {
                       UpdateData("update tbProduct set qty = qty + " + int.Parse(frm.txtCancelQty.Text) + " where pcode = '" + frm.txtPCode.Text + "'; ");
                    }
                    UpdateData("update tbCart set qty = qty - " + int.Parse(frm.txtCancelQty.Text) + " where id = '" + frm.txtID.Text + "'; ");
                    MessageBox.Show("Order transaction successfully cancelled!", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Dispose();
                    frm.RefreshList();
                    frm.Dispose();

                }
                else
                {
                    MessageBox.Show("Wrong Credential!", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                dr.Close();
               
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SaveCancelOrder(string _userName)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("insert into tbCancelOrder (transno,pcode,price,qty,sdate,voidby,cancelby,reason,action) values (@transno,@pcode,@price,@qty,@sdate,@voidby,@cancelby,@reason,@action)", conn);
                cmd.Parameters.AddWithValue("@transno", frm.txtTransno.Text);
                cmd.Parameters.AddWithValue("@pcode", frm.txtPCode.Text);
                cmd.Parameters.AddWithValue("@price", Double.Parse(frm.txtPrice.Text));
                cmd.Parameters.AddWithValue("@qty", frm.txtCancelQty.Text);
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@voidby",_userName);
                cmd.Parameters.AddWithValue("@cancelby", frm.txtCancelBy.Text);
                cmd.Parameters.AddWithValue("@reason", frm.txtReason.Text);
                cmd.Parameters.AddWithValue("@action", frm.cbAdd2Invent.Text);
                cmd.ExecuteNonQuery();
                conn.Close();                
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateData(string sql)
        {
            try
            {               
                conn.Open();
                cmd = new SqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
