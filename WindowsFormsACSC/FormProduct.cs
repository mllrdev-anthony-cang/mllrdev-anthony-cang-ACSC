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

namespace WindowsFormsACSC
{
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
            _initialFormState(_getProducts, _dbProduct);
        }
        private Product _selectedProduct = new Product();
        private Product _getProducts = new Product();
        private ProductRepository _dbProduct = new ProductRepository();
        private decimal _currentPrice;
        private decimal _maxPrice;
        private decimal _minPrice;
        private void _fillListView(List<Product> products)
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
        private void _initialFormState(Product product, ProductRepository db)
        {
            var customers = db.GetBy(product);
            _fillListView(customers);

            labelProduct.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            textBoxCurrentPrice.Text = string.Empty;
            textBoxMaxPrice.Text = string.Empty;
            textBoxMinPrice.Text = string.Empty;

            textBoxCurrentPrice.Enabled = false;
            textBoxMaxPrice.Enabled = true;
            textBoxMinPrice.Enabled = true;

            buttonAdd.Text = "Add";
            buttonUpdate.Text = "Edit";

            buttonAdd.Enabled = true;
            buttonSearch.Enabled = true;
            buttonCancel.Enabled = true;

            buttonUpdate.Enabled = false;
            buttonReset.Enabled = false;
            buttonDelete.Enabled = false;

        }
        private void _select(ListView.SelectedListViewItemCollection selectedrow, Product setSelected)
        {
            if (selectedrow.Count > 0)
            {
                setSelected.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                setSelected.Name = selectedrow[0].SubItems[1].Text;
                setSelected.Description = selectedrow[0].SubItems[2].Text;
                setSelected.CurrentPrice = Convert.ToDecimal(selectedrow[0].SubItems[3].Text);
            }

        }
        private bool _search(Product product, ProductRepository db)
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

            _fillListView(products);
            return true;

        }
        private bool _add(Product product, ProductRepository db)
        {
            bool success = false;

            if (db.Save(product) == true)
            {
                MessageBox.Show("New record added.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = true;
            }
            else
            {
                MessageBox.Show("Please don't leave the text boxes empty.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
            return success;

        }
        private bool _update(Product selected, Product newValues, ProductRepository db)
        {
            bool success = false;

            if (string.Equals(selected.AllInString, newValues.AllInString) == true)
            {
                MessageBox.Show("No changes is made, please check.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (db.Save(newValues) == true)
            {
                MessageBox.Show("Record updated.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Please don't leave the text boxes empty.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return success;
        }
        private bool _delete(Product product, ProductRepository db)
        {
            bool success = false;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                if (db.Remove(product) == true)
                {
                    MessageBox.Show("Record removed.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    MessageBox.Show($"Failed! No reocrod id passed.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return success;
        }        
        private void listViewProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            _select(listViewProduct.SelectedItems, _selectedProduct);
            labelProduct.Text = $"{_selectedProduct.Name}\r\n{_selectedProduct.Description}\r\n{_selectedProduct.CurrentPrice} Php";
            buttonDelete.Enabled = true;
            buttonAdd.Text = "Add";
            buttonReset.Enabled = true;
            buttonUpdate.Enabled = true;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                Name = textBoxName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                MaxPrice = decimal.TryParse(textBoxMaxPrice.Text.Trim(), out _maxPrice) ? _maxPrice : _maxPrice,
                MinPrice = decimal.TryParse(textBoxMinPrice.Text.Trim(), out _minPrice) ? _minPrice : _minPrice
            };

            if (product.MaxPrice == 0 && product.MinPrice == 0)
            {
                product.MaxPrice = null;
                product.MinPrice = null;
            }            

            if (_search(product, _dbProduct) == true)
            {
                _initialFormState(product, _dbProduct);
                buttonReset.Enabled = true;
                textBoxName.Text = product.Name;
                textBoxDescription.Text = product.Description;
                textBoxMaxPrice.Text = product.MaxPrice.ToString();
                textBoxMinPrice.Text = product.MinPrice.ToString();
            }
        }        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.Equals(buttonAdd.Text, "Add"))
            {
                _initialFormState(_getProducts, _dbProduct);
                buttonAdd.Text = "Save";
                buttonSearch.Enabled = false;
                buttonReset.Enabled = true;

                textBoxCurrentPrice.Enabled = true;
                textBoxMaxPrice.Enabled = false;
                textBoxMinPrice.Enabled = false;

                return;
            }
            var product = new Product
            {
                Name = textBoxName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                CurrentPrice = decimal.TryParse(textBoxCurrentPrice.Text.Trim(), out _currentPrice) ? _currentPrice : _currentPrice
            };

            if (_add(product, _dbProduct) == true)
            {
                _initialFormState(_getProducts, _dbProduct);
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.Equals("Edit", buttonUpdate.Text))
            {
                textBoxName.Text = _selectedProduct.Name;
                textBoxDescription.Text = _selectedProduct.Description;
                textBoxCurrentPrice.Text = _selectedProduct.CurrentPrice.ToString();                

                buttonUpdate.Text = "Update";
                buttonAdd.Enabled = false;
                buttonSearch.Enabled = false;
                buttonDelete.Enabled = false;

                textBoxCurrentPrice.Enabled = true;
                textBoxMaxPrice.Enabled = false;
                textBoxMinPrice.Enabled = false;

                return;
            }

            var product = new Product
            {
                Id = _selectedProduct.Id,
                Name = textBoxName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                CurrentPrice = decimal.TryParse(textBoxCurrentPrice.Text.Trim(), out _currentPrice) ? _currentPrice : _currentPrice
            };

            if (_update(_selectedProduct, product, _dbProduct) == true)
            {
                _initialFormState(_getProducts, _dbProduct);
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_delete(_selectedProduct, _dbProduct) == true)
            {
                _initialFormState(_getProducts, _dbProduct);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            _initialFormState(_getProducts, _dbProduct);
        }
        private void FormProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to cancel {this.Text} window?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            e.Cancel = (dialogResult == DialogResult.No);
        }
        private void textBoxCurrentPrice_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBoxMinPrice_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBoxMaxPrice_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
