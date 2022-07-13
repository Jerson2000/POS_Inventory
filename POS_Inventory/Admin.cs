﻿using System;
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
namespace POS_Inventory
{
    public partial class Admin : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        Login sec;
        public static string _user = "";
        public Admin(Login f)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            SetActivePanel(dashboard1);
            this.sec = f;
            
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
        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Logging out? click YES to confirm!","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Login f = new Login();
                f.Show();
            }
            else
            {
                e.Cancel = true;
            }
            
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
            userSettings1.Visible = false;
            records1.Visible = false;
            vendor1.Visible = false;
            stockAdjustment1.Visible = false;

            
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

            //Records
            if (records1.Visible == true)
            {
                btnRecords.IconColor = System.Drawing.Color.White;
                btnRecords.BackColor = System.Drawing.Color.FromArgb(52, 74, 96);

            }
            else if (records1.Visible == false)
            {
                btnRecords.IconColor = System.Drawing.Color.FromArgb(52, 152, 219);
                btnRecords.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);

            }


            //Vendor
            if (vendor1.Visible == true)
            {
                btnVendor.IconColor = System.Drawing.Color.White;
                btnVendor.BackColor = System.Drawing.Color.FromArgb(52, 74, 96);

            }
            else if (vendor1.Visible == false)
            {
                btnVendor.IconColor = System.Drawing.Color.FromArgb(52, 152, 219);
                btnVendor.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);

            }
            // Stock Adjustment
            if (stockAdjustment1.Visible == true)
            {
                btnStockAdjustment.IconColor = System.Drawing.Color.White;
                btnStockAdjustment.BackColor = System.Drawing.Color.FromArgb(52, 74, 96);
            }
            else if (stockAdjustment1.Visible == false)
            {
                btnStockAdjustment.IconColor = System.Drawing.Color.FromArgb(52, 152, 219);
                btnStockAdjustment.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
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
            brand1.LoadData();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            SetActivePanel(category1);
            category1.LoadData();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SetActivePanel(product1);
            product1.LoadData("");
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            SetActivePanel(stockIn1);
            stockIn1.LoadData();
        }

        private void btnUSettings_Click(object sender, EventArgs e)
        {
            SetActivePanel(userSettings1);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            DailySalesDialog f = new DailySalesDialog();
            f.Show();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            SetActivePanel(records1);
            records1.LoadTopSelling();
            records1.LoadSoldItems();
            records1.LoadCriticalStocks();
            records1.LoadInventory();
            records1.LoadCancelOrder();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            SetActivePanel(vendor1);
            vendor1.LoadVendor();
        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            _user = lbName.Text;
            SetActivePanel(stockAdjustment1);
            stockAdjustment1.LoadData("");

        }
    }

}

