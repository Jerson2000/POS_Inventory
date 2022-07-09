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
    public partial class ProductDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        Product f;
        public ProductDialog(Product f)
        {
            InitializeComponent();
            this.f = f;
            conn = new SqlConnection(dbcon.DBConn());
            LoadCat();
            LoadBrand();
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
        public void LoadCat()
        {
            cbPCat.Items.Clear();
            conn.Open();
            cmd = new SqlCommand("select * from tbCategory", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbPCat.Items.Add(dr["category"]);
            }
            dr.Close();
            conn.Close();
        }
        public void LoadBrand()
        {
            cbPBrand.Items.Clear();
            conn.Open();
            cmd = new SqlCommand("select * from tbBrand", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbPBrand.Items.Add(dr["brand"]);
            }
            dr.Close();
            conn.Close();

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string bid="", cid="";
            try
            {
                ;
                if (txtPCode.Text == string.Empty || txtPDes.Text == String.Empty || cbPBrand.Text == String.Empty || cbPCat.Text =="")
                {
                    MessageBox.Show("Missing Required Field!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (MessageBox.Show("Add Product ?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("select * from tbBrand where brand='"+cbPBrand.Text+"'", conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        bid = dr["brand_id"].ToString();
                    }
                    dr.Close();
                    conn.Close();

                    conn.Open();
                    cmd = new SqlCommand("select * from tbCategory where category='" + cbPCat.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        cid = dr["cat_id"].ToString();
                    }
                    dr.Close();
                    conn.Close();



                    conn.Open();
                    cmd = new SqlCommand("insert into tbProduct (pcode,pdesc,brand_id,cat_id,price,date_added,reorder) values(@pcode,@pdesc,@brand_id,@cat_id,@price,CURRENT_TIMESTAMP,@reorder);", conn);
                    cmd.Parameters.AddWithValue("@pcode", txtPCode.Text);
                    cmd.Parameters.AddWithValue("@pdesc", txtPDes.Text);
                    cmd.Parameters.AddWithValue("@brand_id", bid);
                    cmd.Parameters.AddWithValue("@cat_id", cid);
                    cmd.Parameters.AddWithValue("@price", numPrice.Value);
                    cmd.Parameters.AddWithValue("@reorder", int.Parse(txtROrder.Text));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product Added!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadData("");
                }
            }
            catch (Exception ex)
            {
               if(ex.Message.ToString().Contains("duplicate key"))
                {
                    MessageBox.Show("Record is already in the list!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString(), dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                conn.Close();
            }
        }

        private void Clear()
        {
            txtPCode.Clear();
            txtPDes.Clear();
            cbPBrand.Text = "";
            cbPCat.Text = "";
            numPrice.Value = numPrice.Minimum;
            txtROrder.Clear();

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string bid = "", cid = "";
            try
            {
                ;
                if (txtPCode.Text == string.Empty || txtPDes.Text == String.Empty || cbPBrand.Text == String.Empty || cbPCat.Text == "")
                {
                    MessageBox.Show("Missing Required Field!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (MessageBox.Show("Update Product ?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("select * from tbBrand where brand='" + cbPBrand.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        bid = dr["brand_id"].ToString();
                    }
                    dr.Close();
                    conn.Close();

                    conn.Open();
                    cmd = new SqlCommand("select * from tbCategory where category='" + cbPCat.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        cid = dr["cat_id"].ToString();
                    }
                    dr.Close();
                    conn.Close();



                    conn.Open();
                    cmd = new SqlCommand("update tbProduct set pdesc = @pdesc,brand_id = @brand_id, cat_id=@cat_id,price=@price ,reorder=@reorder where  pcode = @pcode", conn);                    
                    cmd.Parameters.AddWithValue("@pdesc", txtPDes.Text);
                    cmd.Parameters.AddWithValue("@brand_id", bid);
                    cmd.Parameters.AddWithValue("@cat_id", cid);
                    cmd.Parameters.AddWithValue("@price", numPrice.Value);
                    cmd.Parameters.AddWithValue("@reorder", int.Parse(txtROrder.Text));
                    cmd.Parameters.AddWithValue("@pcode", txtPCode.Text);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product Updated!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadData("");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Contains("duplicate key"))
                {
                    MessageBox.Show("Record is already in the list!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString(), dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }
        }
    }
}
