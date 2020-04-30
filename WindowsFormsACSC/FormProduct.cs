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
        private IProductManager _manager;
        private Product _product, _selectedProduct;
        public FormProduct()
        {
            InitializeComponent();
            _manager = new ProductManager();
            _product = _selectedProduct = new Product();
            FillListView(_manager.GetBy(_product));
            InitialFormState();
        }        
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
        private void InitialFormState()
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
            _selectedProduct = new Product();

            if (selectedrow.Count > 0)
            {
                _selectedProduct.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _selectedProduct.Name = selectedrow[0].SubItems[1].Text;
                _selectedProduct.Description = selectedrow[0].SubItems[2].Text;
                _selectedProduct.CurrentPrice = Convert.ToDecimal(selectedrow[0].SubItems[3].Text);
            }

            labelProduct.Text = $"{_selectedProduct.Name}\r\n{_selectedProduct.Description}\r\n{_selectedProduct.CurrentPrice} Php";
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


            if (string.IsNullOrWhiteSpace(product.AllInString) == true)
            {
                MessageBox.Show("Please enter a value before searching.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var getBy = _manager.GetBy(product);

            if (getBy.Count < 1)
            {
                MessageBox.Show("No Records Found", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InitialFormState();
                FillListView(_manager.GetBy(product));
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
                InitialFormState();
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

            //var addMessage = _iProductRepository.AddOperation(product);
            if (product.IsValid == true)
            {
                product.Id = _manager.Save(product);
            }

            if (product.Id > 0)
            {
                InitialFormState();
                FillListView(_manager.GetBy(product));
                buttonReset.Enabled = true;
                MessageBox.Show($"New record with ID '{product.Id}' added.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please don't leave the text boxes empty.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            decimal currentPrice;
            var productNewProp = new Product
            {
                Id = _selectedProduct.Id,
                Name = textBoxName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                CurrentPrice = decimal.TryParse(textBoxCurrentPrice.Text.Trim(), out currentPrice) ? currentPrice : currentPrice
            };

            string updateMessage;
            bool success = false;

            if (string.Equals(_selectedProduct.AllInString, productNewProp.AllInString) == true)
            {
                updateMessage = "No Changes made, please check.";
            }
            else if (productNewProp.IsValid == true)
            {
                success = _manager.Update(productNewProp);
                updateMessage = "Record Updated.";
            }
            else
            {
                updateMessage = "Please don't leave the text boxes empty.";
            }

            if (success)
            {
                InitialFormState();
                FillListView(_manager.GetBy(productNewProp));
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                List<int> ids = new List<int>();

                foreach (ListViewItem item in listViewProduct.SelectedItems)
                {
                    ids.Add(Convert.ToInt32(item.SubItems[0].Text));
                }

                if (_manager.Delete(ids.ToArray()))
                {
                    InitialFormState();
                    FillListView(_manager.GetBy(_product));
                    MessageBox.Show("Records removed!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            InitialFormState();
            FillListView(_manager.GetBy(_product));
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
