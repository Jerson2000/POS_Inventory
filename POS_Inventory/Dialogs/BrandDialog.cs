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
    public partial class BrandDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        GetString dbcon = new GetString();
        Brand f;
        public BrandDialog(Brand f)
        {
            InitializeComponent();
            this.f = f;
            conn = new SqlConnection(dbcon.DBConn());
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
            textBox1.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("Missing Required Field!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(MessageBox.Show("Add Brand ?",dbcon.GetTitle(),MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into tbBrand (brand) values(@brand);", conn);
                    cmd.Parameters.AddWithValue("@brand", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Brand Added!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadData();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("Missing Required Field!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (MessageBox.Show("Update Brand ?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("update tbBrand set brand = @brand where brand_id = @id;", conn);
                    cmd.Parameters.AddWithValue("@brand", textBox1.Text);
                    cmd.Parameters.AddWithValue("@id", lbID.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Brand Updated!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                    f.LoadData();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
    }
}
