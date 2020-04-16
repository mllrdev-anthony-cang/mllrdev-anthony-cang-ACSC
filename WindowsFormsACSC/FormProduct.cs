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
    public partial class FormProduct : Form
    {
        private IProductManager _iProductRepository;
        private Product _product, _productSelection;
        public FormProduct()
        {
            InitializeComponent();
            _iProductRepository = new ProductManager();
            _product = _productSelection = new Product();
            _fillListView(_iProductRepository.GetBy(_product));
            _initialFormState();
        }        
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
        private void _initialFormState()
        {
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
        private void listViewProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedrow = listViewProduct.SelectedItems;
            _productSelection = new Product();

            if (selectedrow.Count > 0)
            {
                _productSelection.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _productSelection.Name = selectedrow[0].SubItems[1].Text;
                _productSelection.Description = selectedrow[0].SubItems[2].Text;
                _productSelection.CurrentPrice = Convert.ToDecimal(selectedrow[0].SubItems[3].Text);
            }
            labelProduct.Text = $"{_productSelection.Name}\r\n{_productSelection.Description}\r\n{_productSelection.CurrentPrice} Php";
            buttonDelete.Enabled = true;
            buttonAdd.Text = "Add";
            buttonReset.Enabled = true;
            buttonUpdate.Enabled = true;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            decimal maxPrice, minPrice;
            var product = new Product
            {
                Name = textBoxName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                MaxPrice = decimal.TryParse(textBoxMaxPrice.Text.Trim(), out maxPrice) ? maxPrice : maxPrice,
                MinPrice = decimal.TryParse(textBoxMinPrice.Text.Trim(), out minPrice) ? minPrice : minPrice
            };

            if (product.MaxPrice == 0 && product.MinPrice == 0)
            {
                product.MaxPrice = null;
                product.MinPrice = null;
            }

            if(string.IsNullOrWhiteSpace(_iProductRepository.SearchOperation(product)) == false)
            {
                MessageBox.Show(_iProductRepository.SearchOperation(product), "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _initialFormState();
                _fillListView(_iProductRepository.GetBy(product));
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
                _initialFormState();
                buttonAdd.Text = "Save";
                buttonSearch.Enabled = false;
                buttonReset.Enabled = true;

                textBoxCurrentPrice.Enabled = true;
                textBoxMaxPrice.Enabled = false;
                textBoxMinPrice.Enabled = false;

                return;
            }
            decimal currentPrice;
            var product = new Product
            {
                Name = textBoxName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                CurrentPrice = decimal.TryParse(textBoxCurrentPrice.Text.Trim(), out currentPrice) ? currentPrice : currentPrice
            };

            var addMessage = _iProductRepository.AddOperation(product);

            if (string.Equals(addMessage, "New record added."))
            {
                _initialFormState();
                _fillListView(_iProductRepository.GetBy(product));
                buttonReset.Enabled = true;
                MessageBox.Show(addMessage, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(addMessage, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.Equals("Edit", buttonUpdate.Text))
            {
                textBoxName.Text = _productSelection.Name;
                textBoxDescription.Text = _productSelection.Description;
                textBoxCurrentPrice.Text = _productSelection.CurrentPrice.ToString();                

                buttonUpdate.Text = "Update";
                buttonAdd.Enabled = false;
                buttonSearch.Enabled = false;
                buttonDelete.Enabled = false;

                textBoxCurrentPrice.Enabled = true;
                textBoxMaxPrice.Enabled = false;
                textBoxMinPrice.Enabled = false;

                return;
            }
            decimal currentPrice;
            var productNewProp = new Product
            {
                Id = _productSelection.Id,
                Name = textBoxName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                CurrentPrice = decimal.TryParse(textBoxCurrentPrice.Text.Trim(), out currentPrice) ? currentPrice : currentPrice
            };

            var updateMessage = _iProductRepository.UpdateOperation(_productSelection, productNewProp);

            if (string.Equals(updateMessage,"Record updated."))
            {
                _initialFormState();
                _fillListView(_iProductRepository.GetBy(productNewProp));
                buttonReset.Enabled = true;
                MessageBox.Show(updateMessage, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(updateMessage, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                var deleteMessage = _iProductRepository.DeleteOperation(_productSelection);

                if (string.Equals(deleteMessage, "Record removed."))
                {
                    _initialFormState();
                    _fillListView(_iProductRepository.GetBy(_product));
                    MessageBox.Show(deleteMessage, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(deleteMessage, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            _initialFormState();
            _fillListView(_iProductRepository.GetBy(_product));
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
    }
}
