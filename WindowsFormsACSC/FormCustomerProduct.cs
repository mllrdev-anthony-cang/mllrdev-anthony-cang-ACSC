using ACSC.BL;
using ACSC.BL.Manager;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsACSC
{
    public partial class FormCustomerProduct : Form
    {
        private List<CustomerProduct> _customerProducts;
        private Order _order;
        private Product _product;
        private int _customerId;
        
        private IOrderItemManager _orderItemManager;
        private IOrderManager _orderManager;
        private IProductManager _productManager;
        

        public FormCustomerProduct(int customerId)
        {
            InitializeComponent();
            _order = new Order();
            _product = new Product();
            _customerId = customerId;

            _customerProducts = new List<CustomerProduct>();
            _orderItemManager = new OrderItemManager();
            _orderManager = new OrderManager();
            _productManager = new ProductManager();

        }                

        private void LoadListItems()
        {
            var orders = _orderManager.Search(new Order());
            var orderItems = _orderItemManager.Search(new OrderItem()).Where(p => orders.Where(pw => pw.CustomerId == _customerId).Select(o => o.Id).Contains(p.OrderId) == true);
            var products = _productManager.Search(new Product());

            _customerProducts.AddRange(orderItems.Select( p => new CustomerProduct {
                ProductName = products.Where(pn => pn.Id == p.ProductId).Select(ps => ps.Name).FirstOrDefault(),
                PurchasePrice = p.PurchasePrice,
                OrderDate = orders.Where(o=> o.Id == p.OrderId).Select(os => os.OrderDate).FirstOrDefault()
            }));

            listViewCustomerProduct.Items.Clear();
            listViewCustomerProduct.Items.AddRange(_customerProducts.Select(
                p => new ListViewItem(new string[]{
                    p.ProductName,
                    p.PurchasePrice.ToString("C"),
                    p.OrderDate.ToString()
                })).ToArray());
        }

        private void FormCustomerProduct_Load(object sender, EventArgs e)
        {
            LoadListItems();
        }
    }
}
