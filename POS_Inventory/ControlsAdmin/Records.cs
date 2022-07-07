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
using POS_Inventory.Dialogs;

namespace POS_Inventory.ControlsAdmin
{
    public partial class Records : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public Records()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            LoadTopSelling();
            LoadCriticalStocks();
        }

        #region Top Selling
        public void LoadTopSelling()
        {
            try
            {
                conn.Open();
                dgvTopSelling.Rows.Clear();
                cmd = new SqlCommand("select c.pcode,p.pdesc, sum(c.qty) as qty,sum(c.total) as total from tbCart as c left join tbProduct as p on p.pcode = c.pcode where c.sdate between '" + dateStart.Value.ToString("yyyy-MM-dd") + "' and '" + dateEnd.Value.ToString("yyyy-MM-dd") + "' and c.status = 'Sold' group by c.pcode,p.pdesc ", conn); //
                dr = cmd.ExecuteReader();
                int i =1;
                while (dr.Read())
                {
                    dgvTopSelling.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), Double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                    i++;
                }
                dr.Close();
                conn.Close();

            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            LoadTopSelling();
        }
        #endregion
        #region Sold Items

        public void LoadSoldItems()
        {
            try
            {
                conn.Open();
                dgvSoldItems.Rows.Clear();
                cmd = new SqlCommand("select c.pcode,p.pdesc, sum(c.qty) as qty,sum(c.total) as total from tbCart as c left join tbProduct as p on p.pcode = c.pcode where c.sdate between '" + dtSoldItemStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtSoldItemEnd.Value.ToString("yyyy-MM-dd") + "' and c.status = 'Sold' group by c.pcode,p.pdesc ", conn); //
                dr = cmd.ExecuteReader();
                int i = 1;
                while (dr.Read())
                {
                    dgvSoldItems.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), Double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                    i++;
                }
                dr.Close();
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            LoadSoldItems();
        }

        #endregion
        #region Critical Stocks
        public void LoadCriticalStocks()
        {
            try
            {
                dgvCriticalStocks.Rows.Clear();
                conn.Open();
                cmd = new SqlCommand("select tbProduct.pcode,tbProduct.pdesc,tbBrand.brand,tbCategory.category,tbProduct.price,tbProduct.reorder,tbProduct.qty from tbProduct left join tbBrand on tbProduct.brand_id = tbBrand.brand_id left join tbCategory on tbProduct.cat_id = tbCategory.cat_id where tbProduct.qty <= reorder", conn);
                dr = cmd.ExecuteReader();
                int i = 1;
                while (dr.Read())
                {
                    dgvCriticalStocks.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["brand"].ToString(),dr["category"].ToString(),dr["price"].ToString(),dr["reorder"].ToString(),dr["qty"].ToString());
                    i++;
                }
                dr.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
