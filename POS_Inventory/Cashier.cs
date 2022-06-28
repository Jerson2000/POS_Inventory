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
        public Cashier()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
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
          
            dataGridView1.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("select tbCart.id,tbProduct.pdesc,tbCart.price,tbCart.qty,tbCart.disc,tbCart.total from tbCart left join tbProduct on tbCart.pcode = tbProduct.pcode where transno like '" + lbTransNo.Text + "%' and status='Pending';", conn); //
            dr = cmd.ExecuteReader();
            int i = 1; // Number of items/Rows
            while (dr.Read())
            {
                dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
                i++;
            }

            dr.Close();
            conn.Close();
           

        }
    }

}
