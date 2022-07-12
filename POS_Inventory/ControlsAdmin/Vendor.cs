﻿using System;
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
    public partial class Vendor : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public Vendor()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
            LoadVendor();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            VendorDialog f = new VendorDialog(this);
            f.btnSave.Enabled = true;
            f.btnUpdate.Enabled = false;
            f.ShowDialog();
        }
        public void LoadVendor()
        {
            try
            {
                dataGridView1.Rows.Clear();
                conn.Open();
                cmd = new SqlCommand("select * from tbVendor",conn);
                dr = cmd.ExecuteReader();
                int i = 1;
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["vendor"].ToString(),dr["address"].ToString(),dr["contact_person"].ToString(),dr["telephone"].ToString(),dr["email"].ToString(),dr["fax"].ToString());
                    i++;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                VendorDialog f = new VendorDialog(this);
                f.lbID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.txtVendor.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                f.txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                f.txtContactPerson.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.txtTelephone.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                f.txtFax.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                f.btnSave.Enabled = false;
                f.btnUpdate.Enabled = true;




                f.ShowDialog();
            }
            if (colName == "colDelete")
            {
                if (MessageBox.Show("Remove this Vendor ?", dbcon.GetTitle(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from tbVendor where id = '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "';", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Vendor Successfully Removed", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVendor();
                }
            }
        }
    }
}
