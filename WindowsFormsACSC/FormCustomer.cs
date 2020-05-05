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
    public partial class FormCustomer : Form
    {
        private ICustomerManager _manager;
        private Customer _selectedCustomer, _customer;
        public FormCustomer()
        {
            InitializeComponent();
            _customer = _selectedCustomer = new Customer();
            _manager = new CustomerManager();
            DefaultFormState();
            FillListView(_manager.Search(_customer));
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
        private void DefaultFormState()
        {
            labelCustomer.Text = string.Empty;
            textBoxFirstName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            textBoxPhoneNumber.Text = string.Empty;

            buttonAdd.Text = "Add";
            buttonUpdate.Text = "Edit";

            buttonAdd.Enabled = true;
            buttonSearch.Enabled = true;
            buttonCancel.Enabled = true;

            buttonUpdate.Enabled = false;
            buttonReset.Enabled = false;
            buttonDelete.Enabled = false;
            buttonAddress.Enabled = false;
            
        }                      
        private void listViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedrow = listViewCustomer.SelectedItems;
            _selectedCustomer = new Customer();

            if (selectedrow.Count > 0)
            {
                _selectedCustomer.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _selectedCustomer.FirstName = selectedrow[0].SubItems[1].Text;
                _selectedCustomer.LastName = selectedrow[0].SubItems[2].Text;
                _selectedCustomer.PhoneNumber = selectedrow[0].SubItems[3].Text;
            }
            //labelCustomer.Text = $"Name: {_selectedCustomer.FullName}\r\n\r\nPhone number:{_selectedCustomer.PhoneNumber}";
            buttonDelete.Enabled = true;
            buttonAddress.Enabled = true;
            buttonAdd.Text = "Add";
            buttonReset.Enabled = true;
            buttonUpdate.Enabled = true;
        }                
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.Equals(buttonAdd.Text, "Add"))
            {
                DefaultFormState();
                buttonAdd.Text = "Save";
                buttonSearch.Enabled = false;
                buttonReset.Enabled = true;
                return;
            }
            var customer = new Customer
            {
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                PhoneNumber = textBoxPhoneNumber.Text.Trim()
            };

            //var addMessage = _iCustomerRepository.SaveEntity(customer);
            //if(customer.IsValid == true)
            //{
                customer.Id = _manager.Save(customer);
            //}

            if (customer.Id > 0)
            {
                DefaultFormState();
                FillListView(_manager.Search(customer));
                buttonReset.Enabled = true;
                MessageBox.Show($"New record with ID '{customer.Id}' added.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please don't leave the text boxes empty.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }        
        private void buttonUpdate_Click(object sender, EventArgs e)
        {  
            if(string.Equals("Edit", buttonUpdate.Text))
            {
                textBoxFirstName.Text = _selectedCustomer.FirstName;
                textBoxLastName.Text = _selectedCustomer.LastName;
                textBoxPhoneNumber.Text = _selectedCustomer.PhoneNumber;

                buttonUpdate.Text = "Update";
                buttonAdd.Enabled = false;
                buttonSearch.Enabled = false;
                buttonDelete.Enabled = false;
                buttonAddress.Enabled = false;
                return;
            }

            var customer = new Customer
            {
                Id = _selectedCustomer.Id,
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                PhoneNumber = textBoxPhoneNumber.Text.Trim()
            };

            //var updateMessage = _iCustomerRepository.UpdateOperation(_customerSelection, customer);
            string updateMessage = "";//_iAddressRepository.UpdateOperation(_addressSelection, address);
            bool success = false;

            /*if (string.Equals(_selectedCustomer.AllInString, customer.AllInString) == true)
            {
                updateMessage = "No Changes made, please check.";
            }
            else if (customer.IsValid == true)
            {
                success = _manager.Update(customer);
                updateMessage = "Record Updated.";
            }
            else
            {
                updateMessage = "Please don't leave the text boxes empty.";
            }*/

            if (success)
            {
                DefaultFormState();
                FillListView(_manager.Search(customer));
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
                //var deleteMessage = _iCustomerRepository.DeleteOperation(_customerSelection);
                List<int> ids = new List<int>();

                foreach (ListViewItem item in listViewCustomer.SelectedItems)
                {
                    ids.Add(Convert.ToInt32(item.SubItems[0].Text));
                }

                if (_manager.Delete(ids.ToArray()))
                {
                    DefaultFormState();
                    FillListView(_manager.Search(_customer));
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
        private void buttonAddress_Click(object sender, EventArgs e)
        {
            var newForm = new FormAddress(_selectedCustomer);            
            newForm.ShowDialog();
        }        
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                PhoneNumber = textBoxPhoneNumber.Text.Trim()
            };

            /*if (string.IsNullOrWhiteSpace(customer.AllInString) == true)
            {
                MessageBox.Show("Please enter a value before searching.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            var getBy = _manager.Search(customer);

            if (getBy.Count < 1)
            {
                MessageBox.Show("No Records Found", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DefaultFormState();
                FillListView(_manager.Search(customer));
                buttonReset.Enabled = true;
                textBoxFirstName.Text = customer.FirstName;
                textBoxLastName.Text = customer.LastName;
                textBoxPhoneNumber.Text = customer.PhoneNumber;
            }

        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            DefaultFormState();
            FillListView(_manager.Search(_customer));
        }

        private void listViewCustomer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedrow = listViewCustomer.SelectedItems;            

            if (selectedrow.Count > 0)
            {            
                
                int customerId = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                var newForm = new FormCustomerProduct(customerId);
                newForm.ShowDialog();
            }
        }

        private void FormCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to cancel {this.Text} window?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            e.Cancel = (dialogResult == DialogResult.No);
        }
    }
}
