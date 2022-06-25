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
    public partial class Category : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public Category()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            LoadData();
        }

        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            conn.Open();
            cmd = new SqlCommand("select * from tbCategory;", conn);
            dr = cmd.ExecuteReader();
            int i = 1; // Number of items/Rows
            while (dr.Read())
            {

                dataGridView1.Rows.Add(i, dr["cat_id"].ToString(), dr["category"].ToString());
                i++;
            }

            dr.Close();
            conn.Close();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            CategoryDialog f = new CategoryDialog(this);
            f.btnSave.Enabled = true;
            f.btnUpdate.Enabled = false;
            f.ShowDialog();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                CategoryDialog f = new CategoryDialog(this);
                conn.Open();
                cmd = new SqlCommand("select * from tbCategory where cat_id = '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "';", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    f.textBox1.Text = dr["category"].ToString();
                }
                dr.Close();
                conn.Close();
                f.lbID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.btnSave.Enabled = false;
                f.btnUpdate.Enabled = true;
                f.ShowDialog();
            }
            if (colName == "colDelete")
            {
                if (MessageBox.Show("Delete this Category ?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from tbCategory where cat_id = '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "';", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Category Deleted", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        
    }
}
