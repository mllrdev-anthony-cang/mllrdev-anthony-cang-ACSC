namespace WindowsFormsACSC
{
    partial class FormCustomerProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewCustomerProduct = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewCustomerProduct
            // 
            this.listViewCustomerProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewCustomerProduct.FullRowSelect = true;
            this.listViewCustomerProduct.HideSelection = false;
            this.listViewCustomerProduct.Location = new System.Drawing.Point(12, 12);
            this.listViewCustomerProduct.Name = "listViewCustomerProduct";
            this.listViewCustomerProduct.Size = new System.Drawing.Size(366, 456);
            this.listViewCustomerProduct.TabIndex = 0;
            this.listViewCustomerProduct.UseCompatibleStateImageBehavior = false;
            this.listViewCustomerProduct.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product Name";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Purchase Price";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // FormCustomerProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 480);
            this.Controls.Add(this.listViewCustomerProduct);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(406, 519);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(406, 519);
            this.Name = "FormCustomerProduct";
            this.Text = "FormCustomerProduct";
            this.Load += new System.EventHandler(this.FormCustomerProduct_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewCustomerProduct;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}