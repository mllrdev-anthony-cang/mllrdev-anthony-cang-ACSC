using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACSC.BL.Manager;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Models;

namespace WindowsFormsACSC
{
    public partial class FormCustomerOrderHistory : Form
    {
        private ICustomerOrderHistoryManager _manager;
        private CustomerProductOrderHistory _customerOrderHistory;
        public FormCustomerOrderHistory()
        {
            InitializeComponent();

            _manager = new CustomerOrderHistoryManager();
            _customerOrderHistory = new CustomerProductOrderHistory();
            dateTimePickerMaxDate.MaxDate = dateTimePickerMinDate.MaxDate = DateTime.Now;
            dateTimePickerMaxDate.Value = dateTimePickerMinDate.Value = DateTime.Now;
        }

        private void FillListView(List<CustomerProductOrderHistory> customerOrderHistories)
        {
            listViewOrder.Items.Clear();           
            var listItem = new List<ListViewItem>();

            foreach (var orderHistory in customerOrderHistories)
            {
                ListViewItem item = new ListViewItem(orderHistory.ProductId.ToString());
                item.SubItems.Add(orderHistory.CustomerId.ToString());
                item.SubItems.Add(orderHistory.ProductName);
                item.SubItems.Add(orderHistory.PurchasePrice.ToString());
                item.SubItems.Add(orderHistory.Quantity.ToString());
                item.SubItems.Add(orderHistory.OrderDate.ToString());
                item.SubItems.Add(orderHistory.CustomerName);

                listItem.Add(item);
            }

            listViewOrder.Items.AddRange(listItem.ToArray());
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var day = new TimeSpan(0, 23, 59, 0, 0);
            int productId = 0;
            int customerId = 0;
            int.TryParse(textBoxProductId.Text, out productId);
            int.TryParse(textBoxCustomerId.Text, out customerId);
            _customerOrderHistory.ProductId = productId;
            _customerOrderHistory.CustomerId = customerId;
            _customerOrderHistory.MaxOrderDate = DateTime.Parse(dateTimePickerMaxDate.Text).Add(day).ToString("yyyy-MM-dd HH:mm:ss.fff");
            _customerOrderHistory.MinOrderDate = DateTime.Parse(dateTimePickerMinDate.Text).ToString("yyyy-MM-dd HH:mm:ss.fff");
            var result = _manager.Search(_customerOrderHistory);
            FillListView(result);

            var totalItems = result.Sum(s => s.Quantity);
            var totalAmount = result.Sum(s => s.PurchasePrice);

            labelSummary.Text = $"Total # items: {totalItems}\r\n\r\nTotal Amount: {totalAmount.ToString("C")}";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
