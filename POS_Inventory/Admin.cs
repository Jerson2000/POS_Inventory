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
namespace POS_Inventory
{
    public partial class Admin : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public Admin()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            SetActivePanel(dashboard1);
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
            this.Dispose();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion
        // Active UserControl Container Panel
        public void SetActivePanel(UserControl control)
        {
            
            brand1.Visible = false;
            dashboard1.Visible = false;
            category1.Visible = false;
            product1.Visible = false;
            stockIn1.Visible = false;

            control.Visible = true;


            // Brand
            if (brand1.Visible == true)
            {
                btnBrand.IconColor = System.Drawing.Color.White;
                btnBrand.BackColor = System.Drawing.Color.FromArgb(52, 74, 96);
            }
            else if (brand1.Visible == false)
            {
                btnBrand.IconColor = System.Drawing.Color.FromArgb(52, 152, 219);
                btnBrand.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            }
            //Dashboard
            if (dashboard1.Visible == true)
            {
                btnDashboard.IconColor = System.Drawing.Color.White;
                btnDashboard.BackColor = System.Drawing.Color.FromArgb(52, 74, 96);
               
            }
            else if (dashboard1.Visible == false)
            {
                btnDashboard.IconColor = System.Drawing.Color.FromArgb(52, 152, 219);
                btnDashboard.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
                
            }

            //Category
            if (category1.Visible == true)
            {
                btnCategory.IconColor = System.Drawing.Color.White;
                btnCategory.BackColor = System.Drawing.Color.FromArgb(52, 74, 96);

            }
            else if (category1.Visible == false)
            {
                btnCategory.IconColor = System.Drawing.Color.FromArgb(52, 152, 219);
                btnCategory.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);

            }
            //Product
            if (product1.Visible == true)
            {
                btnProduct.IconColor = System.Drawing.Color.White;
                btnProduct.BackColor = System.Drawing.Color.FromArgb(52, 74, 96);

            }
            else if (product1.Visible == false)
            {
                btnProduct.IconColor = System.Drawing.Color.FromArgb(52, 152, 219);
                btnProduct.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);

            }

            //Stock In
            if (stockIn1.Visible == true)
            {
                btnStockIn.IconColor = System.Drawing.Color.White;
                btnStockIn.BackColor = System.Drawing.Color.FromArgb(52, 74, 96);

            }
            else if (stockIn1.Visible == false)
            {
                btnStockIn.IconColor = System.Drawing.Color.FromArgb(52, 152, 219);
                btnStockIn.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);

            }

        }

        // Toggle Menu Btn
        private void menuBtn_Click(object sender, EventArgs e)
        {
            // w x h - 259, 539 - panel2 size
            if (panel2.Size.Width == 259)
            {
                panel2.Size = new System.Drawing.Size(0, 539);
            }
            else if (panel2.Size.Width == 0)
            {
                panel2.Size = new System.Drawing.Size(259, 539);
            }
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            
            SetActivePanel(dashboard1);
            
        }
        private void btnBrand_Click(object sender, EventArgs e)
        {
            
            SetActivePanel(brand1);
           
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            SetActivePanel(category1);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SetActivePanel(product1);
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            SetActivePanel(stockIn1);
        }
    }

}

