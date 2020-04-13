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
using ACSC.BL.Repositories.Interface;

namespace WindowsFormsACSC
{
    public partial class FormCustomer : Form
    {
        private ICustomerRepository<Customer> _iCustomerRepository;
        private Customer _customerSelection, _customer;
        public FormCustomer()
        {
            InitializeComponent();
            _customer = _customerSelection = new Customer();
            _iCustomerRepository = new CustomerRepository();
            _initialFormState();
            _fillListView(_iCustomerRepository.GetBy(_customer));
        }        
        private void _fillListView(List<Customer> customers)
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
        private void _initialFormState()
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
            _customerSelection = new Customer();

            if (selectedrow.Count > 0)
            {
                _customerSelection.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _customerSelection.FirstName = selectedrow[0].SubItems[1].Text;
                _customerSelection.LastName = selectedrow[0].SubItems[2].Text;
                _customerSelection.PhoneNumber = selectedrow[0].SubItems[3].Text;
            }
            labelCustomer.Text = $"Name: {_customerSelection.FullName}\r\n\r\nPhone number:{_customerSelection.PhoneNumber}";
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
                _initialFormState();
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

            var addMessage = _iCustomerRepository.AddOperation(customer);

            if (string.Equals(addMessage, "New record added."))
            {
                _initialFormState();
                _fillListView(_iCustomerRepository.GetBy(customer));
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
            if(string.Equals("Edit", buttonUpdate.Text))
            {
                textBoxFirstName.Text = _customerSelection.FirstName;
                textBoxLastName.Text = _customerSelection.LastName;
                textBoxPhoneNumber.Text = _customerSelection.PhoneNumber;

                buttonUpdate.Text = "Update";
                buttonAdd.Enabled = false;
                buttonSearch.Enabled = false;
                buttonDelete.Enabled = false;
                buttonAddress.Enabled = false;
                return;
            }

            var customer = new Customer
            {
                Id = _customerSelection.Id,
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                PhoneNumber = textBoxPhoneNumber.Text.Trim()
            };

            var updateMessage = _iCustomerRepository.UpdateOperation(_customerSelection, customer);

            if (string.Equals(updateMessage, "Record updated."))
            {
                _initialFormState();
                _fillListView(_iCustomerRepository.GetBy(customer));
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
                var deleteMessage = _iCustomerRepository.DeleteOperation(_customerSelection);

                if (string.Equals(deleteMessage, "Record removed."))
                {
                    _initialFormState();
                    _fillListView(_iCustomerRepository.GetBy(_customer));
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
        private void buttonAddress_Click(object sender, EventArgs e)
        {
            var newForm = new FormAddress(_customerSelection);            
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

            if (string.IsNullOrWhiteSpace(_iCustomerRepository.SearchOperation(customer)) == false)
            {
                MessageBox.Show(_iCustomerRepository.SearchOperation(customer), "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _initialFormState();
                _fillListView(_iCustomerRepository.GetBy(customer));
                buttonReset.Enabled = true;
                textBoxFirstName.Text = customer.FirstName;
                textBoxLastName.Text = customer.LastName;
                textBoxPhoneNumber.Text = customer.PhoneNumber;
            }

        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            _initialFormState();
            _fillListView(_iCustomerRepository.GetBy(_customer));
        }
        private void FormCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to cancel {this.Text} window?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            e.Cancel = (dialogResult == DialogResult.No);
        }
    }
}
