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
using Microsoft.Reporting.WinForms;

namespace POS_Inventory.Dialogs
{
    public partial class SoldItemsReport : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        DailySalesDialog f;
        public SoldItemsReport(DailySalesDialog f)
        {
            InitializeComponent();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
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
        private void SoldItemsReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }


        public void LoadData()
        {
            try
            {
                ReportDataSource reportDataSource;
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_Inventory.SoldItemsReport.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                conn.Open();
                if (f.cbCashier.Text == "All Cashier")
                {
                    da.SelectCommand = new SqlCommand("select tbCart.id,tbCart.transno,tbCart.pcode,tbProduct.pdesc,tbCart.price,tbCart.qty,tbCart.disc,tbCart.total from tbCart left join tbProduct on tbCart.pcode = tbProduct.pcode where status like 'Sold%' and tbCart.sdate between '" + f.dateStart.Value.ToString("yyyy-MM-dd") + "' and '" + f.dateEnd.Value.ToString("yyyy-MM-dd") + "';", conn);
                }
                else
                {
                    da.SelectCommand = new SqlCommand("select tbCart.id,tbCart.transno,tbCart.pcode,tbProduct.pdesc,tbCart.price,tbCart.qty,tbCart.disc,tbCart.total from tbCart left join tbProduct on tbCart.pcode = tbProduct.pcode where status like 'Sold%' and tbCart.sdate between '" + f.dateStart.Value.ToString("yyyy-MM-dd") + "' and '" + f.dateEnd.Value.ToString("yyyy-MM-dd") + "' and cashier like '" + f.cbCashier.Text + "';", conn);
                }
                    da.Fill(ds.Tables["dtSoldItemsReport"]);
                conn.Close();

                ReportParameter pCashier = new ReportParameter("pCashier", f.cbCashier.Text);
                ReportParameter pDate = new ReportParameter("pDate", "Date From: ''"+f.dateStart.Value.ToShortDateString()+"'' To ''"+f.dateEnd.Value.ToShortDateString()+"''");
                ReportParameter pHeader = new ReportParameter("pHeader", "SALES REPORT");

                reportViewer1.LocalReport.SetParameters(pCashier);
                reportViewer1.LocalReport.SetParameters(pDate);
                reportViewer1.LocalReport.SetParameters(pHeader);

                reportDataSource = new ReportDataSource("DataSet1", ds.Tables["dtSoldItemsReport"]);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 75;
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
          
           

        }


    }
}
