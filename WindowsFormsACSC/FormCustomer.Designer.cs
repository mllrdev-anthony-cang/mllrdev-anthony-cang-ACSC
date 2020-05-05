namespace WindowsFormsACSC
{
    partial class FormCustomer
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
            this.listViewCustomer = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonAddress = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCustomer
            // 
            this.listViewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.FirstName,
            this.LastName,
            this.PhoneNumber});
            this.listViewCustomer.FullRowSelect = true;
            this.listViewCustomer.HideSelection = false;
            this.listViewCustomer.Location = new System.Drawing.Point(266, 12);
            this.listViewCustomer.Name = "listViewCustomer";
            this.listViewCustomer.Size = new System.Drawing.Size(436, 576);
            this.listViewCustomer.TabIndex = 4;
            this.listViewCustomer.UseCompatibleStateImageBehavior = false;
            this.listViewCustomer.View = System.Windows.Forms.View.Details;
            this.listViewCustomer.SelectedIndexChanged += new System.EventHandler(this.listViewCustomer_SelectedIndexChanged);
            this.listViewCustomer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewCustomer_MouseDoubleClick);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 0;
            // 
            // FirstName
            // 
            this.FirstName.Text = "First Name";
            this.FirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstName.Width = 140;
            // 
            // LastName
            // 
            this.LastName.Text = "Last Name";
            this.LastName.Width = 140;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.Text = "Phone Number";
            this.PhoneNumber.Width = 120;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(10, 39);
            this.textBoxFirstName.MaxLength = 50;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(227, 20);
            this.textBoxFirstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "First Name:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(10, 78);
            this.textBoxLastName.MaxLength = 50;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(227, 20);
            this.textBoxLastName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name:";
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(10, 117);
            this.textBoxPhoneNumber.MaxLength = 50;
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(227, 20);
            this.textBoxPhoneNumber.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Phone Number:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(142, 324);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(118, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(12, 295);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(118, 23);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 324);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(118, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPhoneNumber);
            this.groupBox1.Controls.Add(this.textBoxFirstName);
            this.groupBox1.Controls.Add(this.textBoxLastName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 154);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Transaction";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 266);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(118, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(142, 295);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(118, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(142, 266);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(118, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonAddress
            // 
            this.buttonAddress.Location = new System.Drawing.Point(12, 353);
            this.buttonAddress.Name = "buttonAddress";
            this.buttonAddress.Size = new System.Drawing.Size(118, 23);
            this.buttonAddress.TabIndex = 5;
            this.buttonAddress.Text = "Address List";
            this.buttonAddress.UseVisualStyleBackColor = true;
            this.buttonAddress.Click += new System.EventHandler(this.buttonAddress_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelCustomer);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Details";
            // 
            // labelCustomer
            // 
            this.labelCustomer.Location = new System.Drawing.Point(6, 19);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(236, 59);
            this.labelCustomer.TabIndex = 6;
            this.labelCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 597);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAddress);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.listViewCustomer);
            this.MinimumSize = new System.Drawing.Size(730, 464);
            this.Name = "FormCustomer";
            this.Text = "Customer View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCustomer_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewCustomer;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader LastName;
        private System.Windows.Forms.ColumnHeader PhoneNumber;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonAddress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelCustomer;
    }
}