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
    public partial class UserSettings : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();
        public UserSettings()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public void Clear()
        {
            txtUsername.Clear();
            txtPass.Clear();
            txtRPass.Clear();
            cbRole.Text = "";
            txtName.Clear();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsername.Text == String.Empty || txtPass.Text == String.Empty || txtRPass.Text == String.Empty || cbRole.Text == String.Empty || txtName.Text == String.Empty)
                {
                    MessageBox.Show("Missing Required fields", dbcon.GetTitle(), MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else if(txtPass.Text != txtRPass.Text)
                {
                    MessageBox.Show("Password does not match!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into tbUser (username,password,role,name) values(@username,@password,@role,@name);", conn);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@role", cbRole.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("New account successfully created!", dbcon.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();

                }
                
            }
            catch(Exception ex)
            {
                conn.Close();
                if(ex.Message.Contains("duplicate key"))
                {
                    MessageBox.Show("This username is already taken!");
                }
                else
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
