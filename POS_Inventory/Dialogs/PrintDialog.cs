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

        string _store = "Jerson Convience Store";
        string _address = "Davao City";

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
        public void LoadReport(string cash,string change)
        {
            ReportDataSource reportDataSource;
            try
            {
                if(Cashier._transNo != "000000000000000000000")
                {                   
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_Inventory.Report3.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Clear();

                    DataSet1 ds = new DataSet1();
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();                    
                    da.SelectCommand = new SqlCommand("select tbCart.id,tbCart.transno,tbCart.pcode,tbProduct.pdesc,tbCart.price,tbCart.qty,tbCart.disc,tbCart.total,tbCart.sdate,tbCart.status from tbCart left join tbProduct on tbCart.pcode = tbProduct.pcode where transno = '" + Cashier._transNo + "';", conn);
                    
                    da.Fill(ds.Tables["TableSold"]);
                    conn.Close();


                    ReportParameter pVatable = new ReportParameter("pVatable", f.lbVatable.Text);
                    ReportParameter pVat = new ReportParameter("pVat", f.lbVat.Text);
                    ReportParameter pDiscount = new ReportParameter("pDiscount", f.lbDiscount.Text);
                    ReportParameter pTotal = new ReportParameter("pTotal", f.lbSalesAmount.Text);
                    ReportParameter pCash = new ReportParameter("pCash", cash);
                    ReportParameter pChange = new ReportParameter("pChange", change);
                    ReportParameter pStore = new ReportParameter("pStore", _store);
                    ReportParameter pAddress = new ReportParameter("pAddress", _address);
                    ReportParameter pTransaction = new ReportParameter("pTransaction","Invoice #:" + f.lbTransNo.Text);
                    ReportParameter pCashier = new ReportParameter("pCashier",f.lbUser.Text);

                    reportViewer1.LocalReport.SetParameters(pVatable);
                    reportViewer1.LocalReport.SetParameters(pVat);
                    reportViewer1.LocalReport.SetParameters(pDiscount);
                    reportViewer1.LocalReport.SetParameters(pTotal);
                    reportViewer1.LocalReport.SetParameters(pCash);
                    reportViewer1.LocalReport.SetParameters(pChange);
                    reportViewer1.LocalReport.SetParameters(pStore);
                    reportViewer1.LocalReport.SetParameters(pAddress);
                    reportViewer1.LocalReport.SetParameters(pTransaction);
                    reportViewer1.LocalReport.SetParameters(pCashier);

                    reportDataSource = new ReportDataSource("DataSet1", ds.Tables["TableSold"]);
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 75;
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
