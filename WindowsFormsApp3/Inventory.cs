using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp3
{
    public partial class Inventory : UserControl
    {
        private BindingList<Product> _inventoryList = new BindingList<Product>();
        private BindingSource _bindingSource = new BindingSource();
        string filePath = "./product.csv";
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            string path = filePath;

            var tempData = InventoryService.LoadFromCSV(path);
            _inventoryList.Clear();

            foreach (var item in tempData)
            {
                _inventoryList.Add(item);
            }

            dgv.DataSource = _inventoryList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            int newId = _inventoryList.Count + 1000;
            string name = txtName.Text;
            string brand = txtBrand.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            int quantity = int.Parse(txtQuantity.Text);
            Product newProduct = new Product(newId, name, brand, price, quantity);
            _inventoryList.Add(newProduct);

            // 4. Refresh the grid to show the new item
            _bindingSource.ResetBindings(false);

            // 5. Clear fields for the next entry
            ClearFields();
        }

        private bool ValidateInputs()
        {
            // Check if Name contains invalid special characters like #, $, @
            // This regex allows only letters, numbers, and spaces
            if (!Regex.IsMatch(txtName.Text, @"^[a-zA-Z0-9 ]+$"))
            {
                MessageBox.Show("Product Name contains invalid characters.");
                return false;
            }

            // Check if Price is a positive decimal
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid positive price.");
                return false;
            }

            // Check if Quantity is a positive integer
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("Please enter a valid positive quantity.");
                return false;
            }

            return true;
        }
        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtBrand.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
