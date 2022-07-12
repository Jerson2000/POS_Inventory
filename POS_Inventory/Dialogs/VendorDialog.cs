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
using POS_Inventory.ControlsAdmin;
using System.Runtime.InteropServices;

namespace POS_Inventory.Dialogs
{
    public partial class VendorDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        Vendor f;
        public VendorDialog(Vendor f)
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
        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear()
        {
            txtFax.Clear();
            txtVendor.Clear();
            txtAddress.Clear();
            txtContactPerson.Clear();
            txtEmail.Clear();
            txtTelephone.Clear();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtVendor.Text != String.Empty || txtAddress.Text != String.Empty || txtContactPerson.Text != String.Empty || txtEmail.Text != String.Empty
                    || txtFax.Text != String.Empty || txtTelephone.Text != String.Empty)
                {
                    if (MessageBox.Show("Save this vendor? click Yes to confirm.", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        conn.Open();
                        cmd = new SqlCommand("insert into tbVendor (vendor,address,contact_person,telephone,email,fax) values(@vendor,@address,@contact_person,@telephone,@email,@fax) ", conn);
                        cmd.Parameters.AddWithValue("@vendor", txtVendor.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@contact_person", txtContactPerson.Text);
                        cmd.Parameters.AddWithValue("@telephone", txtTelephone.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@fax", txtFax.Text);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Vendor Successfully Saved!", "Vender Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        f.LoadVendor();
                    }

                }
                else
                {
                    MessageBox.Show("Missing Required Fields!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtVendor.Text != String.Empty || txtAddress.Text != String.Empty || txtContactPerson.Text != String.Empty || txtEmail.Text != String.Empty
                    || txtFax.Text != String.Empty || txtTelephone.Text != String.Empty)
                {
                    if (MessageBox.Show("Update this vendor? click Yes to confirm.", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        conn.Open();
                        cmd = new SqlCommand("update tbVendor set vendor = @vendor,address = @address,contact_person = @contact_person,telephone = @telephone,email = @email ,fax = @fax where id = @id;", conn);
                        cmd.Parameters.AddWithValue("@vendor", txtVendor.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@contact_person", txtContactPerson.Text);
                        cmd.Parameters.AddWithValue("@telephone", txtTelephone.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@fax", txtFax.Text);
                        cmd.Parameters.AddWithValue("@id", lbID.Text);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Vendor Successfully Updated!", "Vender Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        f.LoadVendor();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Missing Required Fields!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
