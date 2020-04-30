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
using ACSC.BL.Models;
using ACSC.BL.Repositories.Interface;

namespace WindowsFormsACSC
{
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
            InitializeListViewOrderItem();
            InitialTabOrderState();
            AddressClearAll();
            InitialTabProductState(_getProducts, _productManager);
            InitialTabCustomerState(_getCustomers, _customerManager);
        }

        private List<OrderItem> _selectedProducts = new List<OrderItem>();
        private Product _selectedOrderItem = new Product();
        private decimal _selectedOrderItemQuantity,_productQuantity,_totalAmount;
        private bool _orderSaved = false;

        private Product _selectedProduct = new Product(),_getProducts = new Product();
        private IProductManager _productManager = new ProductManager();
        private decimal _maxPrice,_minPrice;
        private Customer _selectedCustomer = new Customer(), _getCustomers = new Customer();
        private ICustomerManager _customerManager = new CustomerManager();
        private Address _selectedAddress = new Address(), _getAddresses = new Address();
        IAddressManager _addressManager = new AddressManager();
        private AddressMethods _addressMethods = new AddressMethods();

        private void FillListView(List<Product> products)
        {
            listViewProduct.Clear();
            // Set the view to show details.
            listViewProduct.View = View.Details;
            // Select the item and subitems when selection is made.
            listViewProduct.FullRowSelect = true;
            // Display grid lines.
            listViewProduct.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewProduct.Sorting = SortOrder.Ascending;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listViewProduct.Columns.Add("Id", 0, HorizontalAlignment.Center);
            listViewProduct.Columns.Add("Name", 150, HorizontalAlignment.Center);
            listViewProduct.Columns.Add("Description", 150, HorizontalAlignment.Center);
            listViewProduct.Columns.Add("Current Price", 120, HorizontalAlignment.Center);

            var listItem = new List<ListViewItem>();

            foreach (var product in products)
            {
                ListViewItem item = new ListViewItem(product.Id.ToString());
                item.SubItems.Add(product.Name);
                item.SubItems.Add(product.Description);
                item.SubItems.Add(product.CurrentPrice.ToString());

                listItem.Add(item);
            }
            listViewProduct.Items.AddRange(listItem.ToArray());
        }
        private void FillListView(List<Customer> customers)
        {
            listViewCustomer.Clear();
            // Set the view to show details.
            listViewCustomer.View = View.Details;
            // Select the item and subitems when selection is made.
            listViewCustomer.FullRowSelect = true;
            // Display grid lines.
            listViewCustomer.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewCustomer.Sorting = SortOrder.Ascending;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listViewCustomer.Columns.Add("Id", 0, HorizontalAlignment.Center);
            listViewCustomer.Columns.Add("First Name", 150, HorizontalAlignment.Center);
            listViewCustomer.Columns.Add("Last Name", 150, HorizontalAlignment.Center);
            listViewCustomer.Columns.Add("Phone Number", 120, HorizontalAlignment.Center);

            var listItem = new List<ListViewItem>();

            foreach (var customer in customers)
            {
                ListViewItem item = new ListViewItem(customer.Id.ToString());
                item.SubItems.Add(customer.FirstName);
                item.SubItems.Add(customer.LastName);
                item.SubItems.Add(customer.PhoneNumber);

                listItem.Add(item);
            }
            listViewCustomer.Items.AddRange(listItem.ToArray());
        }
        private void FillListView(List<Address> addresses)
        {
            listViewAddress.Clear();
            // Set the view to show details.
            listViewAddress.View = View.Details;
            // Select the item and subitems when selection is made.
            listViewAddress.FullRowSelect = true;
            // Display grid lines.
            listViewAddress.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewAddress.Sorting = SortOrder.Ascending;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listViewAddress.Columns.Add("Id", 0, HorizontalAlignment.Center);
            listViewAddress.Columns.Add("House, Building, Street", 200, HorizontalAlignment.Center);
            listViewAddress.Columns.Add("Province", 120, HorizontalAlignment.Center);
            listViewAddress.Columns.Add("City \\ Municipality", 120, HorizontalAlignment.Center);
            listViewAddress.Columns.Add("Barangay", 120, HorizontalAlignment.Center);
            var listItem = new List<ListViewItem>();

            foreach (var address in addresses)
            {
                ListViewItem item = new ListViewItem(address.Id.ToString());
                item.SubItems.Add(address.HouseBuildingStreet);
                item.SubItems.Add(address.Province);
                item.SubItems.Add(address.CityMunicipality);
                item.SubItems.Add(address.Barangay);

                listItem.Add(item);
            }
            listViewAddress.Items.AddRange(listItem.ToArray());
        }
        private void FillListView(Address filter)
        {
            listViewAddress.Clear();
            // Set the view to show details.
            listViewAddress.View = View.Details;
            // Select the item and subitems when selection is made.
            listViewAddress.FullRowSelect = true;
            // Display grid lines.
            listViewAddress.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewAddress.Sorting = SortOrder.Ascending;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listViewAddress.Columns.Add("Id", 0, HorizontalAlignment.Center);
            listViewAddress.Columns.Add("House, Building, Street", 200, HorizontalAlignment.Center);
            listViewAddress.Columns.Add("Province", 120, HorizontalAlignment.Center);
            listViewAddress.Columns.Add("City \\ Municipality", 120, HorizontalAlignment.Center);
            listViewAddress.Columns.Add("Barangay", 120, HorizontalAlignment.Center);

            //AddressRepository db = new AddressRepository();
            var db = _addressManager;
            var addressList = new List<ListViewItem>();
            var addresses = db.GetBy(filter);

            foreach (var address in addresses)
            {
                ListViewItem item = new ListViewItem(address.Id.ToString());
                item.SubItems.Add(address.HouseBuildingStreet);
                item.SubItems.Add(address.Province);
                item.SubItems.Add(address.CityMunicipality);
                item.SubItems.Add(address.Barangay);

                addressList.Add(item);
            }
            listViewAddress.Items.AddRange(addressList.ToArray());
        }
        private void InitialTabProductState(Product product, IProductManager db)
        {
            var customers = db.GetBy(product);
            FillListView(customers);

            labelProduct.Text = string.Empty;
            textBoxProductName.Text = string.Empty;
            textBoxProductDescription.Text = string.Empty;
            textBoxProductMaxPrice.Text = string.Empty;
            textBoxProductMinPrice.Text = string.Empty;
            textBoxProductQuantity.Text = string.Empty;

            textBoxProductName.Enabled = true;
            textBoxProductDescription.Enabled = true;
            textBoxProductQuantity.Enabled = false;
            textBoxProductMaxPrice.Enabled = true;
            textBoxProductMinPrice.Enabled = true;

            buttonProductAdd.Text = "Add to cart";

            buttonProductAdd.Enabled = false;
            buttonProductSearch.Enabled = true;
            buttonProductCancel.Enabled = true;
            buttonProductNext.Enabled = _selectedProducts.Count > 0;
            buttonProductReset.Enabled = false;

        }
        private void InitialTabOrderState()
        {
            buttonOrderItemBack.Enabled = true;
            buttonOrderItemUpdate.Enabled = false;
            buttonOrderItemRemove.Enabled = false;
            buttonOrderItemReset.Enabled = false;
            buttonOrderItemNext.Enabled = true;

            buttonOrderItemUpdate.Text = "Edit";

            textBoxOrderItemQuantity.Text = string.Empty;
            labelOrderItem.Text = string.Empty;
        }
        private void InitialTabCustomerState(Customer customer, ICustomerManager db)
        {
            var customers = db.GetBy(customer);
            FillListView(customers);

            labelCustomer.Text = string.Empty;
            textBoxCustomerFirstName.Text = string.Empty;
            textBoxCustomerLastName.Text = string.Empty;
            textBoxCustomerPhoneNumber.Text = string.Empty;

            buttonCustomerSearch.Enabled = true;
            buttonCustomerReset.Enabled = false;
            buttonCustomerNext.Enabled = true;
            buttonCustomerBack.Enabled = true;

        }
        private void InitialTabAddressState(Address address, IAddressManager db)
        {
            var customers = db.GetBy(address);
            FillListView(customers);

            textBoxAddressHouse.Text = string.Empty;
            textBoxAddressProvince.Text = string.Empty;
            textBoxAddressCity.Text = string.Empty;
            textBoxAddressBarangay.Text = string.Empty;
            labelAddress.Text = string.Empty;

            buttonAddressSearch.Enabled = true;
            buttonAddressReset.Enabled = false;
        }
        private void InitializeListViewOrderItem()
        {
            listViewOrderItem.Clear();
            // Set the view to show details.
            listViewOrderItem.View = View.Details;
            // Select the item and subitems when selection is made.
            listViewOrderItem.FullRowSelect = true;
            // Display grid lines.
            listViewOrderItem.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewOrderItem.Sorting = SortOrder.Ascending;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listViewOrderItem.Columns.Add("Id", 0, HorizontalAlignment.Center);
            listViewOrderItem.Columns.Add("Name", 150, HorizontalAlignment.Center);
            listViewOrderItem.Columns.Add("Description", 150, HorizontalAlignment.Center);
            listViewOrderItem.Columns.Add("Purchase Price", 120, HorizontalAlignment.Center);
            listViewOrderItem.Columns.Add("Quantity", 120, HorizontalAlignment.Center);
        }
        private bool IsMatch(Product product, IProductManager db)
        {
            if (string.IsNullOrWhiteSpace(product.AllInString) == true && product.MaxPrice == null && product.MinPrice == null)
            {
                MessageBox.Show("Please enter a value before searching.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var products = db.GetBy(product);

            if (products.Count < 1)
            {
                MessageBox.Show("No records found.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FillListView(products);
            return true;

        }                
        private bool IsMatch(Customer customer, ICustomerManager db)
        {
            if (string.IsNullOrWhiteSpace(customer.AllInString) == true)
            {
                MessageBox.Show("Please enter a value before searching.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var customers = db.GetBy(customer);

            if (customers.Count < 1)
            {
                MessageBox.Show("No records found.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FillListView(customers);
            return true;

        }                
        private bool IsMatch(Address address, IAddressManager db)
        {
            if (string.IsNullOrWhiteSpace(_addressMethods.AllInString(address)) == true)
            {
                MessageBox.Show("Please enter a value before searching.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var addresses = db.GetBy(address);

            if (addresses.Count < 1)
            {
                MessageBox.Show("No records found.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FillListView(addresses);
            return true;

        }
        private void AddressClearAll()
        {
            buttonAddressNext.Enabled = false;

            textBoxAddressHouse.Text = string.Empty;
            textBoxAddressProvince.Text = string.Empty;
            textBoxAddressCity.Text = string.Empty;
            textBoxAddressBarangay.Text = string.Empty;

            var address = new Address { CustomerId = _selectedCustomer.Id };
            FillListView(address);
            _selectedAddress = new Address();
        }
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
            listViewSummary.Columns.Add("Id", 0, HorizontalAlignment.Center);
            listViewSummary.Columns.Add("Name", 150, HorizontalAlignment.Center);
            listViewSummary.Columns.Add("Description", 150, HorizontalAlignment.Center);
            listViewSummary.Columns.Add("Purchase Price", 120, HorizontalAlignment.Center);
            listViewSummary.Columns.Add("Quantity", 120, HorizontalAlignment.Center);

            var orderitemsrows = listViewOrderItem.Items;
            decimal total = 0;
            decimal? numberOfitems = 0;

            for (var i = 0; i < orderitemsrows.Count; i++)
            {
                var item = listViewOrderItem.Items[i].Clone() as ListViewItem;
                listViewSummary.Items.Add(item);

                total += Convert.ToDecimal(orderitemsrows[i].SubItems[3].Text) * Convert.ToDecimal(orderitemsrows[i].SubItems[4].Text);
                numberOfitems += Convert.ToDecimal(orderitemsrows[i].SubItems[4].Text);
            }
            _totalAmount = total;
            labelBillAndShip.Text = $"Customer: {_selectedCustomer.FullName}\r\n\r\nPhone Number:{_selectedCustomer.PhoneNumber}" +
                $"\r\n\r\nAddress: {_selectedAddress.HouseBuildingStreet}, {_selectedAddress.Barangay}, {_selectedAddress.CityMunicipality}, {_selectedAddress.Province}";

            labelOrderSummary.Text = $"Subtotal ({numberOfitems} items): {Math.Round(Convert.ToDouble(_totalAmount), 2).ToString("C")}" +
                $"\r\n\r\nTotal: {Math.Round(Convert.ToDouble(_totalAmount), 2).ToString("C")}";
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.Equals("Add to cart", buttonProductAdd.Text))
            {
                buttonProductAdd.Text = "Save to cart";
                buttonProductSearch.Enabled = false;
                buttonProductReset.Enabled = true;

                textBoxProductName.Enabled = false;
                textBoxProductDescription.Enabled = false;
                textBoxProductQuantity.Enabled = true;
                textBoxProductMaxPrice.Enabled = false;
                textBoxProductMinPrice.Enabled = false;
                textBoxProductQuantity.Focus();
                return;
            }

            var orderitem = new OrderItem
            {
                OrderId = 1,
                ProductId = _selectedProduct.Id,
                Quantity = decimal.TryParse(textBoxProductQuantity.Text.Trim(), out _productQuantity) ? _productQuantity : _productQuantity,
                PurchasePrice = _selectedProduct.CurrentPrice
            };

            if (orderitem.IsValid == false)
            {
                MessageBox.Show("Please enter a valid quantity.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxProductQuantity.Focus();
                return;
            }

            _selectedProducts.Add(orderitem);

            var orderitemlist = new List<ListViewItem>();

            ListViewItem item = new ListViewItem(_selectedProduct.Id.ToString());
            item.SubItems.Add(_selectedProduct.Name);
            item.SubItems.Add(_selectedProduct.Description);
            item.SubItems.Add(orderitem.PurchasePrice.ToString());
            item.SubItems.Add(Math.Round(Convert.ToDouble(orderitem.Quantity), 0).ToString());

            item.Name = _selectedProduct.Id.ToString();

            if (listViewOrderItem.Items.ContainsKey(_selectedProduct.Id.ToString()))
            {
                var orderitemsrows = listViewOrderItem.Items;
                
                for(var i=0; i< orderitemsrows.Count; i++)
                {
                    if (string.Equals(_selectedProduct.Id.ToString(), orderitemsrows[i].SubItems[0].Text))
                    {
                        var rowquantity = Math.Round(Convert.ToDouble(orderitem.Quantity), 0) + Math.Round(Convert.ToDouble(orderitemsrows[i].SubItems[4].Text), 0);
                        orderitemsrows[i].SubItems[4].Text = rowquantity.ToString();
                        break;
                    }
                }
            }
            else
            {
                orderitemlist.Add(item);
                listViewOrderItem.Items.AddRange(orderitemlist.ToArray());
            }

            MessageBox.Show($"{orderitem.Quantity} item(s) of {_selectedProduct.Name} added to cart.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            buttonProductNext.Enabled = true;
        }
        private void listViewProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedrow = listViewProduct.SelectedItems;
            
            if (selectedrow.Count > 0)
            {
                _selectedProduct.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _selectedProduct.Name = selectedrow[0].SubItems[1].Text;
                _selectedProduct.Description = selectedrow[0].SubItems[2].Text;
                _selectedProduct.CurrentPrice = Convert.ToDecimal(selectedrow[0].SubItems[3].Text);
            }

            //textBoxProductName.Text = _selectedProduct.Name;
            //textBoxProductDescription.Text = _selectedProduct.Description;
            //textBoxProductCurrentPrice.Text = _selectedProduct.CurrentPrice.ToString();
            labelProduct.Text = $"{_selectedProduct.Name}\r\n{_selectedProduct.Description}\r\n{_selectedProduct.CurrentPrice} Php";

            textBoxProductQuantity.Text = string.Empty;

            textBoxProductName.Enabled = true;
            textBoxProductDescription.Enabled = true;
            textBoxProductQuantity.Enabled = false;
            textBoxProductMaxPrice.Enabled = true;
            textBoxProductMinPrice.Enabled = true;

            buttonProductAdd.Text = "Add to cart";

            buttonProductAdd.Enabled = true;
            buttonProductSearch.Enabled = true;
            buttonProductCancel.Enabled = true;
            buttonProductReset.Enabled = true;
        }
        private void buttonProductSearch_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                Name = textBoxProductName.Text.Trim(),
                Description = textBoxProductDescription.Text.Trim(),
                MaxPrice = decimal.TryParse(textBoxProductMaxPrice.Text.Trim(), out _maxPrice) ? _maxPrice : _maxPrice,
                MinPrice = decimal.TryParse(textBoxProductMinPrice.Text.Trim(), out _minPrice) ? _minPrice : _minPrice
            };

            if (product.MaxPrice == 0 && product.MinPrice == 0)
            {
                product.MaxPrice = null;
                product.MinPrice = null;
            }

            if (IsMatch(product, _productManager) == true)
            {
                InitialTabProductState(product, _productManager);
                buttonProductReset.Enabled = true;
                textBoxProductName.Text = product.Name;
                textBoxProductDescription.Text = product.Description;
                textBoxProductMaxPrice.Text = product.MaxPrice.ToString();
                textBoxProductMinPrice.Text = product.MinPrice.ToString();
            }
        }               
        private void buttonProductCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonProductNext_Click(object sender, EventArgs e)
        {
            if(_selectedProducts.Count() > 0)
            {
                tabControlOrder.SelectedTab = tabPageOrderItems;                
            }            
        }
        private void listViewOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var selectedrow = listViewOrderItem.SelectedItems;

            if (selectedrow.Count > 0)
            {
                _selectedOrderItem.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _selectedOrderItem.Name = selectedrow[0].SubItems[1].Text;
                _selectedOrderItem.Description = selectedrow[0].SubItems[2].Text;
                _selectedOrderItem.CurrentPrice = Convert.ToDecimal(selectedrow[0].SubItems[3].Text);
                _selectedOrderItemQuantity = Convert.ToDecimal(selectedrow[0].SubItems[4].Text);
            }
            labelOrderItem.Text = $"{_selectedOrderItem.Name}\r\n{_selectedOrderItemQuantity} item(s)";

            buttonOrderItemUpdate.Enabled = true;
            buttonOrderItemRemove.Enabled = true;
            buttonOrderItemReset.Enabled = true;
        }        
        private void buttonOrderItemUpdate_Click(object sender, EventArgs e)
        {
            if (string.Equals("Edit", buttonOrderItemUpdate.Text))
            {
                textBoxOrderItemQuantity.Text = _selectedOrderItemQuantity.ToString();

                buttonOrderItemUpdate.Text = "Update";
                buttonOrderItemBack.Enabled = false;
                
                buttonOrderItemRemove.Enabled = false;
                buttonOrderItemReset.Enabled = true;
                buttonOrderItemNext.Enabled = false;

                return;
            }

            var selectedrow = listViewOrderItem.SelectedItems;
            var quantity = decimal.TryParse(textBoxOrderItemQuantity.Text.Trim(), out _productQuantity) ? _productQuantity : _productQuantity;
            var selectedproductquantity = Math.Round(Convert.ToDouble(quantity), 0);

            if (quantity < 1)
            {
                MessageBox.Show("Please enter a valid quantity.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxOrderItemQuantity.Focus();
                return;
            }

            if(_selectedOrderItemQuantity == quantity)
            {
                MessageBox.Show("No changes is made, please check.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedrow.Count > 0 && selectedproductquantity > 0)
            {
                selectedrow[0].SubItems[4].Text = selectedproductquantity.ToString();
                //_orderItemClearAll();
                InitialTabOrderState();
                MessageBox.Show($"Item {_selectedOrderItem.Name} quantiy updated from {_selectedOrderItemQuantity} to {selectedproductquantity}", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
        private void buttonOrderItemRemove_Click(object sender, EventArgs e)
        {
            var selectedrow = listViewOrderItem.SelectedItems;

            if(selectedrow.Count > 0)
            {
                listViewOrderItem.Items.RemoveAt(listViewOrderItem.SelectedIndices[0]);
                //_orderItemClearAll();
                InitialTabOrderState();
                MessageBox.Show($"Item {_selectedOrderItem.Name} removed.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void buttonOrderItemClear_Click(object sender, EventArgs e)
        {
            InitialTabOrderState();
        }
        private void buttonOrderItemNext_Click(object sender, EventArgs e)
        {
            tabControlOrder.SelectedTab = tabPageCustomer;
        }
        private void buttonOrderItemBack_Click(object sender, EventArgs e)
        {
            tabControlOrder.SelectedTab = tabPageProduct;
        }       
        private void buttonCustomerSearch_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                FirstName = textBoxCustomerFirstName.Text.Trim(),
                LastName = textBoxCustomerLastName.Text.Trim(),
                PhoneNumber = textBoxCustomerPhoneNumber.Text.Trim()
            };
            //_fillListView(customer);
            if (IsMatch(customer, _customerManager) == true)
            {
                InitialTabCustomerState(customer, _customerManager);
                buttonCustomerReset.Enabled = true;
                textBoxCustomerFirstName.Text = customer.FirstName;
                textBoxCustomerLastName.Text = customer.LastName;
                textBoxCustomerPhoneNumber.Text = customer.PhoneNumber;
            }
        }          
        private void listViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedrow = listViewCustomer.SelectedItems;

            if (selectedrow.Count > 0)
            {
                _selectedCustomer.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _selectedCustomer.FirstName = selectedrow[0].SubItems[1].Text;
                _selectedCustomer.LastName = selectedrow[0].SubItems[2].Text;
                _selectedCustomer.PhoneNumber = selectedrow[0].SubItems[3].Text;
            }
            labelCustomer.Text = $"Name: {_selectedCustomer.FullName}\r\n\r\nPhone number:{_selectedCustomer.PhoneNumber}";
            //textBoxCustomerFirstName.Text = _selectedCustomer.FirstName;
            //textBoxCustomerLastName.Text = _selectedCustomer.LastName;
            //textBoxCustomerPhoneNumber.Text = _selectedCustomer.PhoneNumber;
            _getAddresses.CustomerId = _selectedCustomer.Id;
            buttonCustomerNext.Enabled = true;
            //_addressClearAll();
            InitialTabAddressState(_getAddresses,_addressManager);
        }
        private void buttonCustomerNext_Click(object sender, EventArgs e)
        {
            tabControlOrder.SelectedTab = tabPageShippingAddress;
        }
        private void buttonCustomerBack_Click(object sender, EventArgs e)
        {
            tabControlOrder.SelectedTab = tabPageOrderItems;
        }        
        private void listViewAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedrow = listViewAddress.SelectedItems;

            if (selectedrow.Count > 0)
            {
                _selectedAddress.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _selectedAddress.HouseBuildingStreet = selectedrow[0].SubItems[1].Text;
                _selectedAddress.Province = selectedrow[0].SubItems[2].Text;
                _selectedAddress.CityMunicipality = selectedrow[0].SubItems[3].Text;
                _selectedAddress.Barangay = selectedrow[0].SubItems[4].Text;
            }

            /*textBoxAddressHouse.Text = _selectedAddress.HouseBuildingStreet;
            textBoxAddressProvince.Text = _selectedAddress.Province;
            textBoxAddressCity.Text = _selectedAddress.CityMunicipality;
            textBoxAddressBarangay.Text = _selectedAddress.Barangay;*/
            labelAddress.Text = _addressMethods.FullAddress(_selectedAddress);

            buttonAddressNext.Enabled = true;
            buttonAddressReset.Enabled = true;
        }
        private void buttonAddressSearch_Click(object sender, EventArgs e)
        {            
            var address = new Address
            {
                HouseBuildingStreet = textBoxAddressHouse.Text.Trim(),
                Province = textBoxAddressProvince.Text.Trim(),
                CityMunicipality = textBoxAddressCity.Text.Trim(),
                Barangay = textBoxAddressBarangay.Text.Trim(),
                CustomerId = _selectedCustomer.Id
            };
            //_fillListView(address);
            if (IsMatch(address, _addressManager) == true)
            {
                InitialTabAddressState(address, _addressManager);
                buttonAddressReset.Enabled = true;
                textBoxAddressHouse.Text = address.HouseBuildingStreet;
                textBoxAddressProvince.Text = address.Province;
                textBoxAddressCity.Text = address.CityMunicipality;
                textBoxAddressBarangay.Text = address.Barangay;
            }
        }        
        private void buttonAddressNext_Click(object sender, EventArgs e)
        {
            var selectedrow = listViewAddress.SelectedItems;

            if (selectedrow.Count > 0)
            {
                tabControlOrder.SelectedTab = tabPageSummary;
                GenerateSummary();
            }
            
        }
        private void buttonAddressBack_Click(object sender, EventArgs e)
        {
            tabControlOrder.SelectedTab = tabPageCustomer;
        }        
        private void tabPageSummary_Enter(object sender, EventArgs e)
        {
            GenerateSummary();
        }
        private void buttonSummaryPlaceOrder_Click(object sender, EventArgs e)
        {
            var orderDate = DateTime.Now;
            var order = new Order
            {
                CustomerId = _selectedCustomer.Id,
                AddressId = _selectedAddress.Id,
                OrderDate = orderDate,
                TotalAmount = _totalAmount,
                MinOrderDate = orderDate.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                MaxOrderDate = orderDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
            };
            //IOrderRepository<Order> orderDB = new OrderRepository();
            IOrderManager orderDB = new OrderManager();
            order.Id = orderDB.Save(order);

            if(order.Id < 1)
            {
                MessageBox.Show("Your order is incomplete, please check.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //var saveOrderId = save;            
            var orderSummaryRows = listViewSummary.Items;
            IOrderItemManager orderItemDB = new OrderItemManager();
            var saveCount = 0;
            var orderitemlist = new List<OrderItem>();

            for (var i = 0; i < orderSummaryRows.Count; i++)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = Convert.ToInt32(orderSummaryRows[i].SubItems[0].Text),
                    PurchasePrice = Convert.ToDecimal(orderSummaryRows[i].SubItems[3].Text),
                    Quantity = Convert.ToDecimal(orderSummaryRows[i].SubItems[4].Text)
                };

                var save = orderItemDB.Save(orderItem);

                if (save>0)
                {
                    saveCount++;
                    orderitemlist.Add(orderItem);
                }
            }

            order.OrderItems = orderitemlist;

            MessageBox.Show($"Your order of {orderSummaryRows.Count} of {saveCount} items is placed. ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _orderSaved = true;
            this.Close();
        }
        private void buttonSummaryBack_Click(object sender, EventArgs e)
        {
            tabControlOrder.SelectedTab = tabPageShippingAddress;
        }
        private void buttonProductReset_Click(object sender, EventArgs e)
        {
            InitialTabProductState(_getProducts, _productManager);
        }
        private void textBoxOrderItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBoxProductQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void buttonCustomerReset_Click(object sender, EventArgs e)
        {
            InitialTabCustomerState(_getCustomers, _customerManager);
            _selectedCustomer = new Customer();
            _selectedAddress = new Address();
        }
        private void buttonAddressReset_Click(object sender, EventArgs e)
        {
            InitialTabAddressState(_getAddresses, _addressManager);
            _selectedAddress = new Address();
        }
        private void tabPageShippingAddress_Enter(object sender, EventArgs e)
        {

            if(_selectedCustomer.Id < 1)
            {
                MessageBox.Show("Please select a customer first.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControlOrder.SelectTab("tabPageCustomer");                    
            }
        }
        private void FormOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_orderSaved == false)
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to cancel {this.Text} window?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                e.Cancel = (dialogResult == DialogResult.No);
            }
            
        }
    }
}
