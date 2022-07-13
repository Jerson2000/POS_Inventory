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
namespace POS_Inventory.ControlsAdmin
{
    public partial class StockAdjustment : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        int _qty;
        int refno;
        public StockAdjustment()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            LoadData("");
            GeneRefNo();
            CheckRefNo();
        }

        public void LoadData(string input)
        {            
            dataGridView1.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("select tbProduct.pcode,tbProduct.pdesc,tbBrand.brand,tbCategory.category,tbProduct.price,tbProduct.qty from tbProduct " +
                "left join tbBrand on tbProduct.brand_id = tbBrand.brand_id left join tbCategory on tbProduct.cat_id = tbCategory.cat_id where (pdesc like '%" + input + "%' or pcode like '%" + input + "%' or brand like '%" + input + "%' or category like '%" + input + "%')", conn);
            dr = cmd.ExecuteReader();
            int i = 1; // Number of items/Rows
            while (dr.Read())
            {
                dataGridView1.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["brand"].ToString(), dr["category"].ToString(), dr["price"].ToString(), dr["qty"].ToString());
                i++;
            }

            dr.Close();
            conn.Close();

        }

        private void metroTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            LoadData(metroTextBox1.Text);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "colSelect")
            {
                txtPcode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPDesc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() +" - "+ dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + " - " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtUser.Text = Admin._user;
                _qty = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            }
        }
        public void GeneRefNo()
        {                        
            Random rand = new Random();            
            txtRefNo.Text += rand.Next();
            refno = int.Parse(txtRefNo.Text);

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtQty.Text == String.Empty || cbAction.Text == String.Empty || txtRemarks.Text == String.Empty)
                {
                    MessageBox.Show("Missing required fields to fill!", "MISSING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void SqlHehe(string sql)
        {
            conn.Open();
            cmd = new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void CheckRefNo()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from tbAjustment where referenceno = '"+refno+"'");
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    GeneRefNo();
                }
                dr.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

    }
}
