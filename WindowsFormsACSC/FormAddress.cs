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
    public partial class FormAddress : Form
    {
        public FormAddress(Customer customer)
        {
            InitializeComponent();

            this.Text = $"{customer.FullName} Address List";
            _getAddresses.CustomerId = customer.Id;
            _selectedAddress.CustomerId = customer.Id;
            _initialFormState(_getAddresses, _dbAddress);
        }
        
        private Address _selectedAddress = new Address();
        private Address _getAddresses = new Address();
        private AddressRepository _dbAddress = new AddressRepository();
        private void _fillListView(List<Address> addresses)
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
        private void _initialFormState(Address address, AddressRepository db)
        {
            var customers = db.GetBy(address);
            _fillListView(customers);

            textBoxHouse.Text = string.Empty;
            textBoxProvince.Text = string.Empty;
            textBoxCity.Text = string.Empty;
            textBoxBarangay.Text = string.Empty;
            labelAddress.Text = string.Empty;

            buttonAdd.Text = "Add";
            buttonUpdate.Text = "Edit";

            buttonAdd.Enabled = true;
            buttonSearch.Enabled = true;
            buttonCancel.Enabled = true;

            buttonUpdate.Enabled = false;
            buttonReset.Enabled = false;
            buttonDelete.Enabled = false;
        }
        private void _select(ListView.SelectedListViewItemCollection selectedrow, Address setSelected)
        {
            if (selectedrow.Count > 0)
            {
                setSelected.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                setSelected.HouseBuildingStreet = selectedrow[0].SubItems[1].Text;
                setSelected.Province = selectedrow[0].SubItems[2].Text;
                setSelected.CityMunicipality = selectedrow[0].SubItems[3].Text;
                setSelected.Barangay = selectedrow[0].SubItems[4].Text;
            }

        }
        private bool _search(Address address, AddressRepository db)
        {
            if (string.IsNullOrWhiteSpace(address.AllInString) == true)
            {
                MessageBox.Show("Please enter a value before searching.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var addresses = db.GetBy(address);

            if (addresses.Count < 1)
            {
                MessageBox.Show("No records found.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _fillListView(addresses);
            return true;

        }
        private bool _add(Address address, AddressRepository db)
        {
            bool success = false;

            if (db.Save(address) == true)
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
        private bool _update(Address selected, Address newValues, AddressRepository db)
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
        private bool _delete(Address address, AddressRepository db)
        {
            bool success = false;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                if (db.Remove(address) == true)
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
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void listViewAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            _select(listViewAddress.SelectedItems, _selectedAddress);
            labelAddress.Text = _selectedAddress.FullAddress;

            buttonDelete.Enabled = true;
            buttonAdd.Text = "Add";
            buttonReset.Enabled = true;
            buttonUpdate.Enabled = true;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {   
            var address = new Address
            {
                HouseBuildingStreet = textBoxHouse.Text.Trim(),
                Province = textBoxProvince.Text.Trim(),
                CityMunicipality = textBoxCity.Text.Trim(),
                Barangay = textBoxBarangay.Text.Trim(),
                CustomerId = _selectedAddress.CustomerId
            };

            if (_search(address, _dbAddress) == true)
            {
                _initialFormState(address, _dbAddress);
                buttonReset.Enabled = true;
                textBoxHouse.Text = address.HouseBuildingStreet;
                textBoxProvince.Text = address.Province;
                textBoxCity.Text = address.CityMunicipality;
                textBoxBarangay.Text = address.Barangay;
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.Equals(buttonAdd.Text, "Add"))
            {
                _initialFormState(_getAddresses, _dbAddress);
                buttonAdd.Text = "Save";
                buttonSearch.Enabled = false;
                buttonReset.Enabled = true;

                return;
            }
            var address = new Address
            {
                HouseBuildingStreet = textBoxHouse.Text.Trim(),
                Province = textBoxProvince.Text.Trim(),
                CityMunicipality = textBoxCity.Text.Trim(),
                Barangay = textBoxBarangay.Text.Trim(),
                CustomerId = _selectedAddress.CustomerId
            };

            if (_add(address, _dbAddress) == true)
            {
                _initialFormState(_getAddresses, _dbAddress);
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.Equals("Edit", buttonUpdate.Text))
            {
                textBoxHouse.Text = _selectedAddress.HouseBuildingStreet;
                textBoxProvince.Text = _selectedAddress.Province;
                textBoxCity.Text = _selectedAddress.CityMunicipality;
                textBoxBarangay.Text = _selectedAddress.Barangay;

                buttonUpdate.Text = "Update";
                buttonAdd.Enabled = false;
                buttonSearch.Enabled = false;
                buttonDelete.Enabled = false;
                return;
            }

            var address = new Address
            {
                Id = _selectedAddress.Id,
                HouseBuildingStreet = textBoxHouse.Text.Trim(),
                Province = textBoxProvince.Text.Trim(),
                CityMunicipality = textBoxCity.Text.Trim(),
                Barangay = textBoxBarangay.Text.Trim(),
                CustomerId = _selectedAddress.CustomerId
            };

            if (_update(_selectedAddress, address, _dbAddress) == true)
            {
                _initialFormState(_getAddresses, _dbAddress);
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_delete(_selectedAddress, _dbAddress) == true)
            {
                _initialFormState(_getAddresses, _dbAddress);
            }
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            _initialFormState(_getAddresses, _dbAddress);
        }
        private void FormAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to cancel {this.Text} window?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            e.Cancel = (dialogResult == DialogResult.No);
        }
    }
}
