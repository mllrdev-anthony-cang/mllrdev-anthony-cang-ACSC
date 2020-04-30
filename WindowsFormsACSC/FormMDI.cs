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
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new FormCustomer();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
                      
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var newForm = new FormProduct();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new FormOrder();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void orderHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new FormOrderHistory();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void customerOrderHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new FormCustomerOrderHistory();
            newForm.MdiParent = this;
            newForm.Show();
        }
    }
}
