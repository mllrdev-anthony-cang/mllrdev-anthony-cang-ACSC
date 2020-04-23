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
    public partial class FormAddress : Form
    {
        private IAddressManager _manager;
        private Address _address,_selectedAddress;
        public FormAddress(Customer customer)
        {
            InitializeComponent();
            _manager = new AddressManager();
            _address = _selectedAddress = new Address { CustomerId = customer.Id };
            FillListView(_manager.GetBy(_address));
            this.Text = $"{customer.FullName} Address List";
            InitialFormState();
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
        private void InitialFormState()
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
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void listViewAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedrow = listViewAddress.SelectedItems;
            _selectedAddress = new Address { CustomerId = _address.CustomerId};

            if (selectedrow.Count > 0)
            {
                _selectedAddress.Id = Convert.ToInt32(selectedrow[0].SubItems[0].Text);
                _selectedAddress.HouseBuildingStreet = selectedrow[0].SubItems[1].Text;
                _selectedAddress.Province = selectedrow[0].SubItems[2].Text;
                _selectedAddress.CityMunicipality = selectedrow[0].SubItems[3].Text;
                _selectedAddress.Barangay = selectedrow[0].SubItems[4].Text;
            }

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

            if (string.IsNullOrWhiteSpace(address.AllInString) == true)
            {
                MessageBox.Show("Please enter a value before searching.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var getBy = _manager.GetBy(address);

            if (getBy.Count < 1)
            {
                MessageBox.Show("No Records Found", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InitialFormState();
                FillListView(getBy);
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
                InitialFormState();
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

            if (address.isValid == true)
            {
                address.Id = _manager.SaveEntity(address);
            }

            if (address.Id > 0)
            {
                InitialFormState();
                FillListView(_manager.GetBy(address));
                buttonReset.Enabled = true;
                MessageBox.Show($"New record with ID '{address.Id}' added.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string updateMessage = "";//_iAddressRepository.UpdateOperation(_addressSelection, address);
            bool success = false;

            if(string.Equals(_selectedAddress.AllInString, address.AllInString) == true)
            {
                updateMessage = "No Changes made, please check.";
            }
            else if (address.isValid == true)
            {
                success = _manager.UpdateEntity(address);
                updateMessage = "Record Updated.";
            }
            else
            {
                updateMessage = "Please don't leave the text boxes empty.";
            }     

            if (success)
            {
                InitialFormState();
                FillListView(_manager.GetBy(address));
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

                foreach (ListViewItem item in listViewAddress.SelectedItems)
                {
                    ids.Add(Convert.ToInt32(item.SubItems[0].Text));
                }

                if (_manager.RemoveEntity(ids.ToArray()))
                {
                    InitialFormState();
                    FillListView(_manager.GetBy(_address));
                    MessageBox.Show("Record removed.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Removed Failed!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            InitialFormState();
            FillListView(_manager.GetBy(_address));
        }
        private void FormAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to cancel {this.Text} window?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            e.Cancel = (dialogResult == DialogResult.No);
        }
    }
}
