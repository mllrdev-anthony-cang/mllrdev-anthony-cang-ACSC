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
    public partial class FormAddress : Form
    {
        private IAddressRepository<Address> _iAddressRepository;
        private Address _address,_addressSelection;
        public FormAddress(Customer customer)
        {
            InitializeComponent();
            _iAddressRepository = new AddressRepository();
            _address = _addressSelection = new Address { CustomerId = customer.Id };
            _fillListView(_iAddressRepository.GetBy(_address));
            this.Text = $"{customer.FullName} Address List";
            _initialFormState();
        }       
        
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
        private void _initialFormState()
        {
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
        private bool _search(Address address)
        {
            if (string.IsNullOrWhiteSpace(address.AllInString) == true)
            {
                MessageBox.Show("Please enter a value before searching.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var addresses = _iAddressRepository.GetBy(address);

            if (addresses.Count < 1)
            {
                MessageBox.Show("No records found.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _fillListView(addresses);
            return true;

        }
        private bool _add(Address address)
        {
            bool success = false;

            if (_iAddressRepository.Save(address) == true)
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
        private bool _update(Address selected, Address newValues)
        {
            bool success = false;

            if (string.Equals(selected.AllInString, newValues.AllInString) == true)
            {
                MessageBox.Show("No changes is made, please check.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_iAddressRepository.Save(newValues) == true)
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
        private bool _delete(Address address)
        {
            bool success = false;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                if (_iAddressRepository.Remove(address) == true)
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
            var selectedrow = listViewAddress.SelectedItems;
            _addressSelection = new Address { CustomerId = _address.CustomerId};

            if (selectedrow.Count > 0)
            {
                _addressSelection.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _addressSelection.HouseBuildingStreet = selectedrow[0].SubItems[1].Text;
                _addressSelection.Province = selectedrow[0].SubItems[2].Text;
                _addressSelection.CityMunicipality = selectedrow[0].SubItems[3].Text;
                _addressSelection.Barangay = selectedrow[0].SubItems[4].Text;
            }
            labelAddress.Text = _addressSelection.FullAddress;

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
                CustomerId = _addressSelection.CustomerId
            };

            if (string.IsNullOrWhiteSpace(_iAddressRepository.SearchOperation(address)) == false)
            {
                MessageBox.Show(_iAddressRepository.SearchOperation(address), "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _initialFormState();
                _fillListView(_iAddressRepository.GetBy(address));
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
                _initialFormState();
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
                CustomerId = _addressSelection.CustomerId
            };
            var addMessage = _iAddressRepository.AddOperation(address);

            if (string.Equals(addMessage, "New record added."))
            {
                _initialFormState();
                _fillListView(_iAddressRepository.GetBy(address));
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
                textBoxHouse.Text = _addressSelection.HouseBuildingStreet;
                textBoxProvince.Text = _addressSelection.Province;
                textBoxCity.Text = _addressSelection.CityMunicipality;
                textBoxBarangay.Text = _addressSelection.Barangay;

                buttonUpdate.Text = "Update";
                buttonAdd.Enabled = false;
                buttonSearch.Enabled = false;
                buttonDelete.Enabled = false;
                return;
            }

            var address = new Address
            {
                Id = _addressSelection.Id,
                HouseBuildingStreet = textBoxHouse.Text.Trim(),
                Province = textBoxProvince.Text.Trim(),
                CityMunicipality = textBoxCity.Text.Trim(),
                Barangay = textBoxBarangay.Text.Trim(),
                CustomerId = _addressSelection.CustomerId
            };
            var updateMessage = _iAddressRepository.UpdateOperation(_addressSelection, address);

            if (string.Equals(updateMessage, "Record updated."))
            {
                _initialFormState();
                _fillListView(_iAddressRepository.GetBy(address));
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
                var deleteMessage = _iAddressRepository.DeleteOperation(_addressSelection);

                if (string.Equals(deleteMessage, "Record removed."))
                {
                    _initialFormState();
                    _fillListView(_iAddressRepository.GetBy(_address));
                    MessageBox.Show(deleteMessage, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(deleteMessage, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            _initialFormState();
            _fillListView(_iAddressRepository.GetBy(_address));
        }
        private void FormAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to cancel {this.Text} window?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            e.Cancel = (dialogResult == DialogResult.No);
        }
    }
}
