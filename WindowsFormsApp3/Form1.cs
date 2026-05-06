using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//This is the new content i just made

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_CheckOut());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Orders());
        }

        // This can be reused for showing any UserControl
        private void ShowScreen(UserControl newScreen)
        {
            // Find existing controls and dispose them to free memory
            foreach (Control ctrl in pnlContent.Controls)
            {
                ctrl.Dispose();
            }

            pnlContent.Controls.Clear(); // Clear the controls
            newScreen.Dock = DockStyle.Fill; // Set Dock to Fill
            pnlContent.Controls.Add(newScreen); // Add the UC to Pnl
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowScreen(new Home());
        }

        private void btnInv_Click(object sender, EventArgs e)
        {
            ShowScreen(new Inventory());
        }

        private void pnlContent_Click(object sender, EventArgs e)
        {

        }
    }
}
