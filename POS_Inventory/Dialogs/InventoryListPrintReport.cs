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
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using POS_Inventory.Classes;

namespace POS_Inventory.Dialogs
{
    public partial class InventoryListPrintReport : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public InventoryListPrintReport()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            LoadReport();
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
        #region Custom Control Box
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;


            }
            else
            {


                this.WindowState = FormWindowState.Maximized;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;

            }
        }
        #endregion
        
        public void LoadReport()
        {
            try
            {
                ReportDataSource reportDataSource;
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_Inventory.InventoryListReport.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                conn.Open();
                da.SelectCommand = new SqlCommand("select tbProduct.pcode,tbProduct.pdesc,tbBrand.brand,tbCategory.category,tbProduct.price,tbProduct.reorder,tbProduct.qty from tbProduct left join tbBrand on tbProduct.brand_id = tbBrand.brand_id left join tbCategory on tbProduct.cat_id = tbCategory.cat_id;", conn);

                da.Fill(ds.Tables["dtInventoryList"]);
                conn.Close();


                
                reportDataSource = new ReportDataSource("DataSet1", ds.Tables["dtInventoryList"]);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }

        }

    }
}
