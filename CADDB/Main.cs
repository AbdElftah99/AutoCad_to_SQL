using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CADDB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Set FormBorderStyle to FixedSingle to prevent resizing
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // Disable maximize box (and restore box) on the title bar
            MaximizeBox = false;
            ControlBox = true; // Set this to false if you want to remove the entire title bar

            lblInfo.Text= string.Empty;
        }

        private void btn_LoadLines_Click(object sender, EventArgs e)
        {
            DBLoadUtil dBLoad = new DBLoadUtil();   
            string result = dBLoad.LoadLines();
            lblInfo.Text = result;
        }

        private void btnLoadMText_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                DBLoadUtil dBLoad = new DBLoadUtil();
                string result = dBLoad.LoadMText();
                lblInfo.Text = result;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                DBLoadUtil dBLoad = new DBLoadUtil();
                string result = dBLoad.LoadPLines();
                lblInfo.Text = result;
            }
        }
    }
}
