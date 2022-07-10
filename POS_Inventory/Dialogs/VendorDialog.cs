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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVendor.Text != String.Empty || txtAddress.Text != String.Empty || txtContactPerson.Text != String.Empty || txtEmail.Text != String.Empty
                    || txtFax.Text != String.Empty || txtTelephone.Text != String.Empty)
                {
                    if(MessageBox.Show("Add this vendor? click Yes to confirm.","Question?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //conn.Open();
                        //cmd = new SqlCommand("insert into vendor()")
                        //conn.Close();
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
    }
}
