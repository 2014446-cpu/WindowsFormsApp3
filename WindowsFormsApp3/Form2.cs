using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "admin" && password == "12345")
            {
                Form1 newForm = new Form1(); // Create an instance of Form1
                this.Hide(); // Optionally hide the current form
                newForm.Show(); // Show the new form
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
