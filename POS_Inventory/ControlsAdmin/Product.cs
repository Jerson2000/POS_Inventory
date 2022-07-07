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
    public partial class Product : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public Product()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            LoadData("");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ProductDialog f = new ProductDialog(this);
            f.btnSave.Enabled = true;
            f.btnUpdate.Enabled = false;
            f.txtPCode.Enabled = true;            
            f.ShowDialog();
        }
        public void LoadData(string input)
        {
            /*
             * Select Query - select tbProduct.pcode,tbProduct.pdesc,tbBrand.brand,tbCategory.category,tbProduct.price,tbProduct.qty from tbProduct 
             * left join tbBrand on tbProduct.brand_id = tbBrand.brand_id left join tbCategory on tbProduct.cat_id = tbCategory.cat_id;
             */
            dataGridView1.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("select tbProduct.pcode,tbProduct.pdesc,tbBrand.brand,tbCategory.category,tbProduct.price,tbProduct.reorder from tbProduct " +
                "left join tbBrand on tbProduct.brand_id = tbBrand.brand_id left join tbCategory on tbProduct.cat_id = tbCategory.cat_id where (pdesc like '%"+input+ "%' or pcode like '%" + input + "%' or brand like '%" + input + "%' or category like '%" + input + "%')", conn);
            dr = cmd.ExecuteReader();
            int i = 1; // Number of items/Rows
            while (dr.Read())
            {                
                dataGridView1.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["brand"].ToString(),dr["category"].ToString(),dr["price"].ToString(),dr["reorder"].ToString());
                i++;
            }

            dr.Close();
            conn.Close();

        }

        private void metroTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            LoadData(metroTextBox1.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                ProductDialog f = new ProductDialog(this);
                conn.Open();
                cmd = new SqlCommand("select tbProduct.pcode,tbProduct.pdesc,tbBrand.brand,tbCategory.category,tbProduct.price,tbProduct.reorder from tbProduct " +
                    "left join tbBrand on tbProduct.brand_id = tbBrand.brand_id left join tbCategory on tbProduct.cat_id = tbCategory.cat_id where pcode = '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "';", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    f.txtPCode.Text = dr["pcode"].ToString();
                    f.txtPDes.Text = dr["pdesc"].ToString();
                    f.cbPBrand.Text = dr["brand"].ToString();
                    f.cbPCat.Text = dr["category"].ToString();
                    f.numPrice.Value = Convert.ToDecimal(dr["price"].ToString());
                    f.txtROrder.Text = dr["reorder"].ToString();                    
                }
                dr.Close();
                conn.Close();
                f.txtPCode.Enabled = false;
                f.btnSave.Enabled = false;
                f.btnUpdate.Enabled = true;
                f.ShowDialog();
            }
            if (colName == "colDelete")
            {
                if (MessageBox.Show("Delete this product ?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from tbProduct where pcode = '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "';", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product Deleted", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData("");
                }
            }
        }
    }
}
