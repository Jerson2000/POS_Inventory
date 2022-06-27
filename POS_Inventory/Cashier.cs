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

namespace POS_Inventory
{
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
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
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;


            }
            else
            {


                this.WindowState = FormWindowState.Maximized;
                iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        #endregion
        // Toggle Menu Btn
        private void menuBtn_Click(object sender, EventArgs e)
        {
            // w x h - 279, 599 - panel2 size
            if (panel2.Size.Width == 279)
            {
                panel2.Size = new System.Drawing.Size(0, 599);
            }
            else if (panel2.Size.Width == 0)
            {
                panel2.Size = new System.Drawing.Size(279, 599);
            }
        }

        private void btnNewTransac_Click(object sender, EventArgs e)
        {
            transaction1.GetTransNo();
        }
    }

}
