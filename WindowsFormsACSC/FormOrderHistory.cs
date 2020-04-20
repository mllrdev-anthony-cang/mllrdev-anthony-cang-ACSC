using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACSC.BL;
using ACSC.BL.Manager;
using ACSC.BL.Manager.Interface;

namespace WindowsFormsACSC
{
    public partial class FormOrderHistory : Form
    {
        public FormOrderHistory()
        {
            InitializeComponent();
            _clearAll();

            dateTimePickerMaxDate.MaxDate = DateTime.Now;
            dateTimePickerMinDate.MaxDate = DateTime.Now;
        }

        private Order _selectedOrder = new Order();
        private void _fillListView(Order filter)
        {
            listViewOrder.Clear();
            // Set the view to show details.
            listViewOrder.View = View.Details;
            // Select the item and subitems when selection is made.
            listViewOrder.FullRowSelect = true;
            // Display grid lines.
            listViewOrder.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewOrder.Sorting = SortOrder.Ascending;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listViewOrder.Columns.Add("Id", 0, HorizontalAlignment.Center);
            listViewOrder.Columns.Add("AddressId", 0, HorizontalAlignment.Center);
            listViewOrder.Columns.Add("CustomerId", 0, HorizontalAlignment.Center);
            listViewOrder.Columns.Add("Total Amount", 120, HorizontalAlignment.Center);
            listViewOrder.Columns.Add("Order Date", 120, HorizontalAlignment.Center);
            listViewOrder.Columns.Add("Customer Name", 120, HorizontalAlignment.Center);
            listViewOrder.Columns.Add("Customer Phone Number", 120, HorizontalAlignment.Center);
            listViewOrder.Columns.Add("Shipping Address", 120, HorizontalAlignment.Center);

            //var db = new OrderRepository();
            IOrderManager db = new OrderManager();
            var productList = new List<ListViewItem>();
            var orders = db.GetBy(filter);

            foreach (var order in orders)
            {
                ListViewItem item = new ListViewItem(order.Id.ToString());
                item.SubItems.Add(order.AddressId.ToString());
                item.SubItems.Add(order.CustomerId.ToString());
                item.SubItems.Add(order.TotalAmount.ToString());
                item.SubItems.Add(order.OrderDate.ToString());
                item.SubItems.Add(order.CustomerName.ToString());
                item.SubItems.Add(order.CustomerPhoneNumber.ToString());
                item.SubItems.Add(order.ShippingAddress.ToString());

                productList.Add(item);
            }
            listViewOrder.Items.AddRange(productList.ToArray());
        }

        private void listViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedrow = listViewOrder.SelectedItems;

            if (selectedrow.Count > 0)
            {
                _selectedOrder.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _selectedOrder.AddressId = Convert.ToInt32(selectedrow[0].SubItems[1].Text);
                _selectedOrder.CustomerId = Convert.ToInt32(selectedrow[0].SubItems[2].Text);
                _selectedOrder.TotalAmount = Convert.ToDecimal(selectedrow[0].SubItems[3].Text);
                _selectedOrder.CustomerName = selectedrow[0].SubItems[5].Text;
                _selectedOrder.CustomerPhoneNumber = selectedrow[0].SubItems[6].Text;
                _selectedOrder.ShippingAddress = selectedrow[0].SubItems[7].Text;
            }


            //textBoxCustomerName.Text = _selectedOrder.CustomerName;
            //textBoxShippingAddress.Text = _selectedOrder.ShippingAddress;
            //textBoxTotalAmount.Text = _selectedOrder.TotalAmount.ToString();

            buttonOrderSummary.Enabled = true;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var day = new TimeSpan(0,23,59,0,0);
            var order = new Order
            {
                CustomerName = textBoxCustomerName.Text.Trim(),
                ShippingAddress = textBoxShippingAddress.Text.Trim(),
                MaxOrderDate = DateTime.Parse(dateTimePickerMaxDate.Text).Add(day).ToString("yyyy-MM-dd HH:mm:ss.fff"),
                MinOrderDate = DateTime.Parse(dateTimePickerMinDate.Text).ToString("yyyy-MM-dd HH:mm:ss.fff")
            };
            _fillListView(order);
        }

        private void _clearAll()
        {
            buttonOrderSummary.Enabled = false;

            textBoxCustomerName.Text = string.Empty;
            textBoxShippingAddress.Text = string.Empty;
            //textBoxTotalAmount.Text = string.Empty;

            _fillListView(new Order());
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _clearAll();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOrderSummary_Click(object sender, EventArgs e)
        {
            
            var newForm = new FormOrderSummary(_selectedOrder);
            newForm.ShowDialog();
        }
    }
}
