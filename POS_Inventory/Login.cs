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
namespace POS_Inventory
{
    public partial class Login : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        GetString dbcon = new GetString();

        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection(dbcon.DBConn());
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

        #region Control Box        

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string _username="",role="",name="";
                bool isUser = false;
                conn.Open();
                cmd = new SqlCommand("select * from tbUser where username = @username and password = @password", conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    isUser = true;
                    _username = dr["username"].ToString();
                    role = dr["role"].ToString();
                    name = dr["name"].ToString();
                }
                else
                {
                    isUser = false;
                    MessageBox.Show("Wrong Credentials", "Access Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
                if(isUser == true)
                {
                    if(role != String.Empty && role == "Cashier")
                    {
                        MessageBox.Show("Welcome " + name + " !", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        txtUsername.Clear();
                        txtPassword.Clear();
                        this.Hide();
                        Cashier f = new Cashier(this);
                        f.lbUser.Text = name;
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Welcome " + name + " !", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Clear();
                        txtPassword.Clear();
                        this.Hide();
                        Admin f = new Admin(this);
                        f.lbName.Text = name;
                        f.lbRole.Text = role;
                        f.ShowDialog();
                    }
                }
                

            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
