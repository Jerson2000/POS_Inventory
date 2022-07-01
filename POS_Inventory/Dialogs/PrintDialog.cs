using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using POS_Inventory.Classes;
namespace POS_Inventory.Dialogs
{
    public partial class PrintDialog : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        Cashier f;
        public PrintDialog(Cashier f)
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            this.f = f;
        }

        private void PrintDialog_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
        }
        public void LoadReport()
        {
            ReportDataSource reportDataSource;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report1.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                conn.Open();
                da.SelectCommand = new SqlCommand("select tbCart.id,tbCart.pcode,tbProduct.pdesc,tbCart.price,tbCart.qty,tbCart.disc,tbCart.total from tbCart left join tbProduct on tbCart.pcode = tbProduct.pcode where transno like '" + f.lbTransNo.Text + "%' and status='Pending';", conn);
                da.Fill(ds.Tables["dtSold"]);
                conn.Close();

                reportDataSource = new ReportDataSource("DataSet1",ds.Tables["dtSold"]);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 30;
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
