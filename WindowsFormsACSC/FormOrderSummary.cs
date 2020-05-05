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
using ACSC.BL.Repositories.Interface;

namespace WindowsFormsACSC
{
    public partial class FormOrderSummary : Form
    {
        public FormOrderSummary(Order order)
        {
            InitializeComponent();
            _order = order;
            _orderItem.OrderId = order.Id;
            GenerateSummary();            
        }

        private Order _order = new Order();
        private OrderItem _orderItem = new OrderItem();
        private void GenerateSummary()
        {
            listViewSummary.Clear();
            // Set the view to show details.
            listViewSummary.View = View.Details;
            // Select the item and subitems when selection is made.
            listViewSummary.FullRowSelect = true;
            // Display grid lines.
            listViewSummary.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewSummary.Sorting = SortOrder.Ascending;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listViewSummary.Columns.Add("OrderId", 0, HorizontalAlignment.Center);
            listViewSummary.Columns.Add("ProductId", 0, HorizontalAlignment.Center);
            listViewSummary.Columns.Add("Product Name", 150, HorizontalAlignment.Center);
            listViewSummary.Columns.Add("Product Description", 150, HorizontalAlignment.Center);
            listViewSummary.Columns.Add("Purchase Price", 120, HorizontalAlignment.Center);
            listViewSummary.Columns.Add("Quantity", 120, HorizontalAlignment.Center);

            //IOrderItemRepository<OrderItem> db = new OrderItemRepository();
            IOrderItemManager db = new OrderItemManager();
            var orderItemList = new List<ListViewItem>();
            var orders = db.Search(_orderItem);
            decimal? numberOfitems = 0;
            
            foreach (var order in orders)
            {
                ListViewItem item = new ListViewItem(order.OrderId.ToString());
                item.SubItems.Add(order.ProductId.ToString());
                //item.SubItems.Add(order.OrderItemProductName.ToString());
                //item.SubItems.Add(order.OrderItemProductDescription.ToString());
                item.SubItems.Add(order.PurchasePrice.ToString());
                item.SubItems.Add(order.Quantity.ToString());

                orderItemList.Add(item);

                numberOfitems += order.Quantity;
            }
            listViewSummary.Items.AddRange(orderItemList.ToArray());

            //labelBillAndShip.Text = $"Customer: {_order.CustomerName}\r\n\r\nPhone Number:{_order.CustomerPhoneNumber}\r\n\r\nAddress: {_order.ShippingAddress}";

            labelOrderSummary.Text = $"Subtotal ({numberOfitems} items): {Math.Round(Convert.ToDouble(_order.TotalAmount), 2).ToString("C")}" +
                $"\r\n\r\nTotal: {Math.Round(Convert.ToDouble(_order.TotalAmount), 2).ToString("C")}";
        }

        private void buttonSummaryBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
