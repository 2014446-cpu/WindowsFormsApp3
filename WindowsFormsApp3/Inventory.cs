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
    public partial class Inventory : UserControl
    {
        private BindingList<Product> _inventoryList = new BindingList<Product>();
        private BindingSource bindingSource = new BindingSource();
        string filePath = "./product.csv";
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            var tempData = InventoryService.LoadFromCSV(filePath);
            _inventoryList.Clear();

            foreach (var item in tempData)
            {
                _inventoryList.Add(item);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
