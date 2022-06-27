using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_Inventory.Classes;
using POS_Inventory.Dialogs;
using System.Data.SqlClient;
namespace POS_Inventory.ControlsAdmin
{
    public partial class StockIn : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        Product f;
        public StockIn()
        {
            InitializeComponent();            
            conn = new SqlConnection(dbcon.DBConn());
            LoadData();
            LoadHistory();
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;
            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            StockProducts f = new StockProducts(this);
            f.ShowDialog();
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("select tbStock.id,tbStock.refno,tbStock.pcode,tbProduct.pdesc,tbStock.qty,tbStock.sdate,tbStock.stock_in_by from tbStock left join tbProduct on tbStock.pcode = tbProduct.pcode where status = 'Pending';", conn);             
            dr = cmd.ExecuteReader();
            int i = 1; // Number of items/Rows
            while (dr.Read())
            {
                dataGridView1.Rows.Add(i, dr["refno"].ToString(), dr["pcode"].ToString(),dr["pdesc"].ToString(), dr["qty"].ToString(), dr["sdate"].ToString(), dr["stock_in_by"].ToString(),dr["id"].ToString());
                i++;
            }
            dr.Close();
            conn.Close();
        }

        public void LoadHistory()
        {
            
            dataGridView2.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("select tbStock.id,tbStock.refno,tbStock.pcode,tbProduct.pdesc,tbStock.qty,tbStock.sdate,tbStock.stock_in_by from tbStock left join tbProduct on tbStock.pcode = tbProduct.pcode where FORMAT(sdate,'dd-MM-yyyy') between '"+dateStart.Value.ToString("dd-MM-yyyy")+"' and '"+dateEnd.Value.ToString("dd-MM-yyyy") + "' and status = 'Done';", conn); //sdate between '"+dateStart.Value+"' and '"+dateEnd.Value+"' and
            dr = cmd.ExecuteReader();
            int i = 1; // Number of items/Rows
            while (dr.Read())
            {
                dataGridView2.Rows.Add(i, dr["refno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(),dr["sdate"].ToString(), dr["stock_in_by"].ToString(), dr["id"].ToString());
                i++;
            }
            dr.Close();
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colDelete")
            {
                if (MessageBox.Show("Delete this item ?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from tbStock where id = '" + dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() + "';", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Deleted Successfully", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();

                    f = new Product();
                    f.LoadData("");
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.Rows.Count > 0)
                {
                    if(MessageBox.Show("Are you save this record?",dbcon.GetTitle(),MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            // Update Product qty
                            conn.Open();
                            cmd = new SqlCommand("update tbProduct set qty += " + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) + " where pcode = '" + dataGridView1.Rows[i].Cells[2].Value.ToString()+"';", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            // Update Stock qty
                            conn.Open();
                            cmd = new SqlCommand("update tbStock set qty += " + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) + ", status='Done' where id = '" + dataGridView1.Rows[i].Cells[7].Value.ToString()+"';", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        MessageBox.Show("Record/s Successfully saved! ", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();                       
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), dbcon.GetTitle(),MessageBoxButtons.OK,MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            LoadHistory();
        }
    }
}
