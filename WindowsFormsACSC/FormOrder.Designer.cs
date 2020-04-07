namespace WindowsFormsACSC
{
    partial class FormOrder
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
            this.tabControlOrder = new System.Windows.Forms.TabControl();
            this.tabPageProduct = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.labelProduct = new System.Windows.Forms.Label();
            this.buttonProductCancel = new System.Windows.Forms.Button();
            this.buttonProductReset = new System.Windows.Forms.Button();
            this.buttonProductSearch = new System.Windows.Forms.Button();
            this.buttonProductNext = new System.Windows.Forms.Button();
            this.buttonProductAdd = new System.Windows.Forms.Button();
            this.listViewProduct = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxProductMaxPrice = new System.Windows.Forms.TextBox();
            this.textBoxProductMinPrice = new System.Windows.Forms.TextBox();
            this.textBoxProductQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxProductDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageOrderItems = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.labelOrderItem = new System.Windows.Forms.Label();
            this.buttonOrderItemRemove = new System.Windows.Forms.Button();
            this.buttonOrderItemUpdate = new System.Windows.Forms.Button();
            this.buttonOrderItemNext = new System.Windows.Forms.Button();
            this.buttonOrderItemBack = new System.Windows.Forms.Button();
            this.buttonOrderItemReset = new System.Windows.Forms.Button();
            this.listViewOrderItem = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxOrderItemQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageCustomer = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxCustomerPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxCustomerFirstName = new System.Windows.Forms.TextBox();
            this.textBoxCustomerLastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonCustomerSearch = new System.Windows.Forms.Button();
            this.buttonCustomerBack = new System.Windows.Forms.Button();
            this.buttonCustomerNext = new System.Windows.Forms.Button();
            this.buttonCustomerReset = new System.Windows.Forms.Button();
            this.listViewCustomer = new System.Windows.Forms.ListView();
            this.tabPageShippingAddress = new System.Windows.Forms.TabPage();
            this.buttonAddressBack = new System.Windows.Forms.Button();
            this.buttonAddressNext = new System.Windows.Forms.Button();
            this.buttonAddressReset = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxAddressBarangay = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAddressHouse = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxAddressProvince = new System.Windows.Forms.TextBox();
            this.textBoxAddressCity = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.listViewAddress = new System.Windows.Forms.ListView();
            this.buttonAddressSearch = new System.Windows.Forms.Button();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.listViewSummary = new System.Windows.Forms.ListView();
            this.buttonSummaryBack = new System.Windows.Forms.Button();
            this.buttonSummaryPlaceOrder = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelOrderSummary = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelBillAndShip = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.tabControlOrder.SuspendLayout();
            this.tabPageProduct.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageOrderItems.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageCustomer.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageShippingAddress.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlOrder
            // 
            this.tabControlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlOrder.Controls.Add(this.tabPageProduct);
            this.tabControlOrder.Controls.Add(this.tabPageOrderItems);
            this.tabControlOrder.Controls.Add(this.tabPageCustomer);
            this.tabControlOrder.Controls.Add(this.tabPageShippingAddress);
            this.tabControlOrder.Controls.Add(this.tabPageSummary);
            this.tabControlOrder.Location = new System.Drawing.Point(10, 10);
            this.tabControlOrder.Name = "tabControlOrder";
            this.tabControlOrder.SelectedIndex = 0;
            this.tabControlOrder.Size = new System.Drawing.Size(776, 596);
            this.tabControlOrder.TabIndex = 0;
            // 
            // tabPageProduct
            // 
            this.tabPageProduct.BackColor = System.Drawing.Color.Transparent;
            this.tabPageProduct.Controls.Add(this.groupBox7);
            this.tabPageProduct.Controls.Add(this.buttonProductCancel);
            this.tabPageProduct.Controls.Add(this.buttonProductReset);
            this.tabPageProduct.Controls.Add(this.buttonProductSearch);
            this.tabPageProduct.Controls.Add(this.buttonProductNext);
            this.tabPageProduct.Controls.Add(this.buttonProductAdd);
            this.tabPageProduct.Controls.Add(this.listViewProduct);
            this.tabPageProduct.Controls.Add(this.groupBox2);
            this.tabPageProduct.Location = new System.Drawing.Point(4, 22);
            this.tabPageProduct.Name = "tabPageProduct";
            this.tabPageProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProduct.Size = new System.Drawing.Size(768, 570);
            this.tabPageProduct.TabIndex = 0;
            this.tabPageProduct.Text = "Product";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.labelProduct);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(248, 88);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Product Details";
            // 
            // labelProduct
            // 
            this.labelProduct.Location = new System.Drawing.Point(6, 19);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(236, 59);
            this.labelProduct.TabIndex = 6;
            this.labelProduct.Text = "Name\r\nDescription\r\nPrice";
            this.labelProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonProductCancel
            // 
            this.buttonProductCancel.Location = new System.Drawing.Point(136, 380);
            this.buttonProductCancel.Name = "buttonProductCancel";
            this.buttonProductCancel.Size = new System.Drawing.Size(118, 23);
            this.buttonProductCancel.TabIndex = 17;
            this.buttonProductCancel.Text = "Cancel";
            this.buttonProductCancel.UseVisualStyleBackColor = true;
            this.buttonProductCancel.Click += new System.EventHandler(this.buttonProductCancel_Click);
            // 
            // buttonProductReset
            // 
            this.buttonProductReset.Location = new System.Drawing.Point(136, 322);
            this.buttonProductReset.Name = "buttonProductReset";
            this.buttonProductReset.Size = new System.Drawing.Size(118, 23);
            this.buttonProductReset.TabIndex = 16;
            this.buttonProductReset.Text = "Reset";
            this.buttonProductReset.UseVisualStyleBackColor = true;
            this.buttonProductReset.Click += new System.EventHandler(this.buttonProductReset_Click);
            // 
            // buttonProductSearch
            // 
            this.buttonProductSearch.Location = new System.Drawing.Point(136, 293);
            this.buttonProductSearch.Name = "buttonProductSearch";
            this.buttonProductSearch.Size = new System.Drawing.Size(118, 23);
            this.buttonProductSearch.TabIndex = 13;
            this.buttonProductSearch.Text = "Search";
            this.buttonProductSearch.UseVisualStyleBackColor = true;
            this.buttonProductSearch.Click += new System.EventHandler(this.buttonProductSearch_Click);
            // 
            // buttonProductNext
            // 
            this.buttonProductNext.Location = new System.Drawing.Point(136, 351);
            this.buttonProductNext.Name = "buttonProductNext";
            this.buttonProductNext.Size = new System.Drawing.Size(118, 23);
            this.buttonProductNext.TabIndex = 12;
            this.buttonProductNext.Text = "Next";
            this.buttonProductNext.UseVisualStyleBackColor = true;
            this.buttonProductNext.Click += new System.EventHandler(this.buttonProductNext_Click);
            // 
            // buttonProductAdd
            // 
            this.buttonProductAdd.Location = new System.Drawing.Point(6, 293);
            this.buttonProductAdd.Name = "buttonProductAdd";
            this.buttonProductAdd.Size = new System.Drawing.Size(118, 23);
            this.buttonProductAdd.TabIndex = 12;
            this.buttonProductAdd.Text = "Add to cart";
            this.buttonProductAdd.UseVisualStyleBackColor = true;
            this.buttonProductAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listViewProduct
            // 
            this.listViewProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProduct.HideSelection = false;
            this.listViewProduct.Location = new System.Drawing.Point(260, 6);
            this.listViewProduct.Name = "listViewProduct";
            this.listViewProduct.Size = new System.Drawing.Size(502, 556);
            this.listViewProduct.TabIndex = 11;
            this.listViewProduct.UseCompatibleStateImageBehavior = false;
            this.listViewProduct.SelectedIndexChanged += new System.EventHandler(this.listViewProduct_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxProductMaxPrice);
            this.groupBox2.Controls.Add(this.textBoxProductMinPrice);
            this.groupBox2.Controls.Add(this.textBoxProductQuantity);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxProductDescription);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxProductName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 187);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Transaction";
            // 
            // textBoxProductMaxPrice
            // 
            this.textBoxProductMaxPrice.Location = new System.Drawing.Point(127, 119);
            this.textBoxProductMaxPrice.Name = "textBoxProductMaxPrice";
            this.textBoxProductMaxPrice.Size = new System.Drawing.Size(109, 20);
            this.textBoxProductMaxPrice.TabIndex = 3;
            this.textBoxProductMaxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOrderItemQuantity_KeyPress);
            // 
            // textBoxProductMinPrice
            // 
            this.textBoxProductMinPrice.Location = new System.Drawing.Point(9, 119);
            this.textBoxProductMinPrice.Name = "textBoxProductMinPrice";
            this.textBoxProductMinPrice.Size = new System.Drawing.Size(109, 20);
            this.textBoxProductMinPrice.TabIndex = 3;
            this.textBoxProductMinPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOrderItemQuantity_KeyPress);
            // 
            // textBoxProductQuantity
            // 
            this.textBoxProductQuantity.Location = new System.Drawing.Point(9, 158);
            this.textBoxProductQuantity.Name = "textBoxProductQuantity";
            this.textBoxProductQuantity.Size = new System.Drawing.Size(227, 20);
            this.textBoxProductQuantity.TabIndex = 3;
            this.textBoxProductQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProductQuantity_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Price Range:";
            // 
            // textBoxProductDescription
            // 
            this.textBoxProductDescription.Location = new System.Drawing.Point(9, 80);
            this.textBoxProductDescription.Name = "textBoxProductDescription";
            this.textBoxProductDescription.Size = new System.Drawing.Size(227, 20);
            this.textBoxProductDescription.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description:";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(9, 40);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(227, 20);
            this.textBoxProductName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = " Name:";
            // 
            // tabPageOrderItems
            // 
            this.tabPageOrderItems.BackColor = System.Drawing.Color.Transparent;
            this.tabPageOrderItems.Controls.Add(this.groupBox8);
            this.tabPageOrderItems.Controls.Add(this.buttonOrderItemRemove);
            this.tabPageOrderItems.Controls.Add(this.buttonOrderItemUpdate);
            this.tabPageOrderItems.Controls.Add(this.buttonOrderItemNext);
            this.tabPageOrderItems.Controls.Add(this.buttonOrderItemBack);
            this.tabPageOrderItems.Controls.Add(this.buttonOrderItemReset);
            this.tabPageOrderItems.Controls.Add(this.listViewOrderItem);
            this.tabPageOrderItems.Controls.Add(this.groupBox1);
            this.tabPageOrderItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrderItems.Name = "tabPageOrderItems";
            this.tabPageOrderItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrderItems.Size = new System.Drawing.Size(768, 570);
            this.tabPageOrderItems.TabIndex = 1;
            this.tabPageOrderItems.Text = "Order Items";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.labelOrderItem);
            this.groupBox8.Location = new System.Drawing.Point(6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(254, 88);
            this.groupBox8.TabIndex = 24;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Order Item Details";
            // 
            // labelOrderItem
            // 
            this.labelOrderItem.Location = new System.Drawing.Point(6, 19);
            this.labelOrderItem.Name = "labelOrderItem";
            this.labelOrderItem.Size = new System.Drawing.Size(236, 59);
            this.labelOrderItem.TabIndex = 6;
            this.labelOrderItem.Text = "Name\r\nDescription\r\nPrice";
            this.labelOrderItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOrderItemRemove
            // 
            this.buttonOrderItemRemove.Location = new System.Drawing.Point(12, 206);
            this.buttonOrderItemRemove.Name = "buttonOrderItemRemove";
            this.buttonOrderItemRemove.Size = new System.Drawing.Size(118, 23);
            this.buttonOrderItemRemove.TabIndex = 23;
            this.buttonOrderItemRemove.Text = "Remove";
            this.buttonOrderItemRemove.UseVisualStyleBackColor = true;
            this.buttonOrderItemRemove.Click += new System.EventHandler(this.buttonOrderItemRemove_Click);
            // 
            // buttonOrderItemUpdate
            // 
            this.buttonOrderItemUpdate.Location = new System.Drawing.Point(12, 177);
            this.buttonOrderItemUpdate.Name = "buttonOrderItemUpdate";
            this.buttonOrderItemUpdate.Size = new System.Drawing.Size(118, 23);
            this.buttonOrderItemUpdate.TabIndex = 22;
            this.buttonOrderItemUpdate.Text = "Update";
            this.buttonOrderItemUpdate.UseVisualStyleBackColor = true;
            this.buttonOrderItemUpdate.Click += new System.EventHandler(this.buttonOrderItemUpdate_Click);
            // 
            // buttonOrderItemNext
            // 
            this.buttonOrderItemNext.Location = new System.Drawing.Point(142, 207);
            this.buttonOrderItemNext.Name = "buttonOrderItemNext";
            this.buttonOrderItemNext.Size = new System.Drawing.Size(118, 23);
            this.buttonOrderItemNext.TabIndex = 23;
            this.buttonOrderItemNext.Text = "Next";
            this.buttonOrderItemNext.UseVisualStyleBackColor = true;
            this.buttonOrderItemNext.Click += new System.EventHandler(this.buttonOrderItemNext_Click);
            // 
            // buttonOrderItemBack
            // 
            this.buttonOrderItemBack.Location = new System.Drawing.Point(142, 236);
            this.buttonOrderItemBack.Name = "buttonOrderItemBack";
            this.buttonOrderItemBack.Size = new System.Drawing.Size(118, 23);
            this.buttonOrderItemBack.TabIndex = 23;
            this.buttonOrderItemBack.Text = "Back";
            this.buttonOrderItemBack.UseVisualStyleBackColor = true;
            this.buttonOrderItemBack.Click += new System.EventHandler(this.buttonOrderItemBack_Click);
            // 
            // buttonOrderItemReset
            // 
            this.buttonOrderItemReset.Location = new System.Drawing.Point(142, 177);
            this.buttonOrderItemReset.Name = "buttonOrderItemReset";
            this.buttonOrderItemReset.Size = new System.Drawing.Size(118, 23);
            this.buttonOrderItemReset.TabIndex = 22;
            this.buttonOrderItemReset.Text = "Reset";
            this.buttonOrderItemReset.UseVisualStyleBackColor = true;
            this.buttonOrderItemReset.Click += new System.EventHandler(this.buttonOrderItemClear_Click);
            // 
            // listViewOrderItem
            // 
            this.listViewOrderItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewOrderItem.HideSelection = false;
            this.listViewOrderItem.Location = new System.Drawing.Point(266, 6);
            this.listViewOrderItem.Name = "listViewOrderItem";
            this.listViewOrderItem.Size = new System.Drawing.Size(496, 556);
            this.listViewOrderItem.TabIndex = 19;
            this.listViewOrderItem.UseCompatibleStateImageBehavior = false;
            this.listViewOrderItem.SelectedIndexChanged += new System.EventHandler(this.listViewOrderItem_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxOrderItemQuantity);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 71);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Item Transaction";
            // 
            // textBoxOrderItemQuantity
            // 
            this.textBoxOrderItemQuantity.Location = new System.Drawing.Point(10, 37);
            this.textBoxOrderItemQuantity.Name = "textBoxOrderItemQuantity";
            this.textBoxOrderItemQuantity.Size = new System.Drawing.Size(227, 20);
            this.textBoxOrderItemQuantity.TabIndex = 3;
            this.textBoxOrderItemQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOrderItemQuantity_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Quantity:";
            // 
            // tabPageCustomer
            // 
            this.tabPageCustomer.BackColor = System.Drawing.Color.Transparent;
            this.tabPageCustomer.Controls.Add(this.groupBox9);
            this.tabPageCustomer.Controls.Add(this.groupBox3);
            this.tabPageCustomer.Controls.Add(this.buttonCustomerSearch);
            this.tabPageCustomer.Controls.Add(this.buttonCustomerBack);
            this.tabPageCustomer.Controls.Add(this.buttonCustomerNext);
            this.tabPageCustomer.Controls.Add(this.buttonCustomerReset);
            this.tabPageCustomer.Controls.Add(this.listViewCustomer);
            this.tabPageCustomer.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustomer.Name = "tabPageCustomer";
            this.tabPageCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomer.Size = new System.Drawing.Size(768, 570);
            this.tabPageCustomer.TabIndex = 2;
            this.tabPageCustomer.Text = "Customer";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.labelCustomer);
            this.groupBox9.Location = new System.Drawing.Point(6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(248, 88);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Customer Details";
            // 
            // labelCustomer
            // 
            this.labelCustomer.Location = new System.Drawing.Point(6, 19);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(236, 59);
            this.labelCustomer.TabIndex = 6;
            this.labelCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxCustomerPhoneNumber);
            this.groupBox3.Controls.Add(this.textBoxCustomerFirstName);
            this.groupBox3.Controls.Add(this.textBoxCustomerLastName);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(6, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 150);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customer Transaction";
            // 
            // textBoxCustomerPhoneNumber
            // 
            this.textBoxCustomerPhoneNumber.Location = new System.Drawing.Point(9, 120);
            this.textBoxCustomerPhoneNumber.Name = "textBoxCustomerPhoneNumber";
            this.textBoxCustomerPhoneNumber.Size = new System.Drawing.Size(227, 20);
            this.textBoxCustomerPhoneNumber.TabIndex = 3;
            // 
            // textBoxCustomerFirstName
            // 
            this.textBoxCustomerFirstName.Location = new System.Drawing.Point(9, 40);
            this.textBoxCustomerFirstName.Name = "textBoxCustomerFirstName";
            this.textBoxCustomerFirstName.Size = new System.Drawing.Size(227, 20);
            this.textBoxCustomerFirstName.TabIndex = 1;
            // 
            // textBoxCustomerLastName
            // 
            this.textBoxCustomerLastName.Location = new System.Drawing.Point(9, 80);
            this.textBoxCustomerLastName.Name = "textBoxCustomerLastName";
            this.textBoxCustomerLastName.Size = new System.Drawing.Size(227, 20);
            this.textBoxCustomerLastName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "First Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Phone Number:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Last Name:";
            // 
            // buttonCustomerSearch
            // 
            this.buttonCustomerSearch.Location = new System.Drawing.Point(136, 256);
            this.buttonCustomerSearch.Name = "buttonCustomerSearch";
            this.buttonCustomerSearch.Size = new System.Drawing.Size(118, 23);
            this.buttonCustomerSearch.TabIndex = 13;
            this.buttonCustomerSearch.Text = "Search";
            this.buttonCustomerSearch.UseVisualStyleBackColor = true;
            this.buttonCustomerSearch.Click += new System.EventHandler(this.buttonCustomerSearch_Click);
            // 
            // buttonCustomerBack
            // 
            this.buttonCustomerBack.Location = new System.Drawing.Point(136, 343);
            this.buttonCustomerBack.Name = "buttonCustomerBack";
            this.buttonCustomerBack.Size = new System.Drawing.Size(118, 23);
            this.buttonCustomerBack.TabIndex = 10;
            this.buttonCustomerBack.Text = "Back";
            this.buttonCustomerBack.UseVisualStyleBackColor = true;
            this.buttonCustomerBack.Click += new System.EventHandler(this.buttonCustomerBack_Click);
            // 
            // buttonCustomerNext
            // 
            this.buttonCustomerNext.Location = new System.Drawing.Point(136, 314);
            this.buttonCustomerNext.Name = "buttonCustomerNext";
            this.buttonCustomerNext.Size = new System.Drawing.Size(118, 23);
            this.buttonCustomerNext.TabIndex = 10;
            this.buttonCustomerNext.Text = "Next";
            this.buttonCustomerNext.UseVisualStyleBackColor = true;
            this.buttonCustomerNext.Click += new System.EventHandler(this.buttonCustomerNext_Click);
            // 
            // buttonCustomerReset
            // 
            this.buttonCustomerReset.Location = new System.Drawing.Point(136, 285);
            this.buttonCustomerReset.Name = "buttonCustomerReset";
            this.buttonCustomerReset.Size = new System.Drawing.Size(118, 23);
            this.buttonCustomerReset.TabIndex = 11;
            this.buttonCustomerReset.Text = "Reset";
            this.buttonCustomerReset.UseVisualStyleBackColor = true;
            this.buttonCustomerReset.Click += new System.EventHandler(this.buttonCustomerReset_Click);
            // 
            // listViewCustomer
            // 
            this.listViewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCustomer.FullRowSelect = true;
            this.listViewCustomer.HideSelection = false;
            this.listViewCustomer.Location = new System.Drawing.Point(260, 6);
            this.listViewCustomer.Name = "listViewCustomer";
            this.listViewCustomer.Size = new System.Drawing.Size(502, 556);
            this.listViewCustomer.TabIndex = 8;
            this.listViewCustomer.UseCompatibleStateImageBehavior = false;
            this.listViewCustomer.View = System.Windows.Forms.View.Details;
            this.listViewCustomer.SelectedIndexChanged += new System.EventHandler(this.listViewCustomer_SelectedIndexChanged);
            // 
            // tabPageShippingAddress
            // 
            this.tabPageShippingAddress.BackColor = System.Drawing.Color.Transparent;
            this.tabPageShippingAddress.Controls.Add(this.groupBox10);
            this.tabPageShippingAddress.Controls.Add(this.buttonAddressBack);
            this.tabPageShippingAddress.Controls.Add(this.buttonAddressNext);
            this.tabPageShippingAddress.Controls.Add(this.buttonAddressReset);
            this.tabPageShippingAddress.Controls.Add(this.groupBox4);
            this.tabPageShippingAddress.Controls.Add(this.listViewAddress);
            this.tabPageShippingAddress.Controls.Add(this.buttonAddressSearch);
            this.tabPageShippingAddress.Location = new System.Drawing.Point(4, 22);
            this.tabPageShippingAddress.Name = "tabPageShippingAddress";
            this.tabPageShippingAddress.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShippingAddress.Size = new System.Drawing.Size(768, 570);
            this.tabPageShippingAddress.TabIndex = 3;
            this.tabPageShippingAddress.Text = "Shipping Address";
            this.tabPageShippingAddress.Enter += new System.EventHandler(this.tabPageShippingAddress_Enter);
            // 
            // buttonAddressBack
            // 
            this.buttonAddressBack.Location = new System.Drawing.Point(136, 380);
            this.buttonAddressBack.Name = "buttonAddressBack";
            this.buttonAddressBack.Size = new System.Drawing.Size(118, 23);
            this.buttonAddressBack.TabIndex = 6;
            this.buttonAddressBack.Text = "Back";
            this.buttonAddressBack.UseVisualStyleBackColor = true;
            this.buttonAddressBack.Click += new System.EventHandler(this.buttonAddressBack_Click);
            // 
            // buttonAddressNext
            // 
            this.buttonAddressNext.Location = new System.Drawing.Point(136, 351);
            this.buttonAddressNext.Name = "buttonAddressNext";
            this.buttonAddressNext.Size = new System.Drawing.Size(118, 23);
            this.buttonAddressNext.TabIndex = 6;
            this.buttonAddressNext.Text = "Next";
            this.buttonAddressNext.UseVisualStyleBackColor = true;
            this.buttonAddressNext.Click += new System.EventHandler(this.buttonAddressNext_Click);
            // 
            // buttonAddressReset
            // 
            this.buttonAddressReset.Location = new System.Drawing.Point(136, 322);
            this.buttonAddressReset.Name = "buttonAddressReset";
            this.buttonAddressReset.Size = new System.Drawing.Size(118, 23);
            this.buttonAddressReset.TabIndex = 7;
            this.buttonAddressReset.Text = "Reset";
            this.buttonAddressReset.UseVisualStyleBackColor = true;
            this.buttonAddressReset.Click += new System.EventHandler(this.buttonAddressReset_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxAddressBarangay);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.textBoxAddressHouse);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textBoxAddressProvince);
            this.groupBox4.Controls.Add(this.textBoxAddressCity);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(6, 100);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(248, 187);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Address Transaction";
            // 
            // textBoxAddressBarangay
            // 
            this.textBoxAddressBarangay.Location = new System.Drawing.Point(9, 157);
            this.textBoxAddressBarangay.Name = "textBoxAddressBarangay";
            this.textBoxAddressBarangay.Size = new System.Drawing.Size(227, 20);
            this.textBoxAddressBarangay.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "House, Building, Street:";
            // 
            // textBoxAddressHouse
            // 
            this.textBoxAddressHouse.Location = new System.Drawing.Point(9, 40);
            this.textBoxAddressHouse.Name = "textBoxAddressHouse";
            this.textBoxAddressHouse.Size = new System.Drawing.Size(227, 20);
            this.textBoxAddressHouse.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Province:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Barangay:";
            // 
            // textBoxAddressProvince
            // 
            this.textBoxAddressProvince.Location = new System.Drawing.Point(9, 79);
            this.textBoxAddressProvince.Name = "textBoxAddressProvince";
            this.textBoxAddressProvince.Size = new System.Drawing.Size(227, 20);
            this.textBoxAddressProvince.TabIndex = 1;
            // 
            // textBoxAddressCity
            // 
            this.textBoxAddressCity.Location = new System.Drawing.Point(9, 118);
            this.textBoxAddressCity.Name = "textBoxAddressCity";
            this.textBoxAddressCity.Size = new System.Drawing.Size(227, 20);
            this.textBoxAddressCity.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "City / Municipality:";
            // 
            // listViewAddress
            // 
            this.listViewAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAddress.HideSelection = false;
            this.listViewAddress.Location = new System.Drawing.Point(260, 6);
            this.listViewAddress.Name = "listViewAddress";
            this.listViewAddress.Size = new System.Drawing.Size(502, 556);
            this.listViewAddress.TabIndex = 5;
            this.listViewAddress.UseCompatibleStateImageBehavior = false;
            this.listViewAddress.View = System.Windows.Forms.View.Details;
            this.listViewAddress.SelectedIndexChanged += new System.EventHandler(this.listViewAddress_SelectedIndexChanged);
            // 
            // buttonAddressSearch
            // 
            this.buttonAddressSearch.Location = new System.Drawing.Point(136, 293);
            this.buttonAddressSearch.Name = "buttonAddressSearch";
            this.buttonAddressSearch.Size = new System.Drawing.Size(118, 23);
            this.buttonAddressSearch.TabIndex = 10;
            this.buttonAddressSearch.Text = "Search";
            this.buttonAddressSearch.UseVisualStyleBackColor = true;
            this.buttonAddressSearch.Click += new System.EventHandler(this.buttonAddressSearch_Click);
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSummary.Controls.Add(this.listViewSummary);
            this.tabPageSummary.Controls.Add(this.buttonSummaryBack);
            this.tabPageSummary.Controls.Add(this.buttonSummaryPlaceOrder);
            this.tabPageSummary.Controls.Add(this.groupBox6);
            this.tabPageSummary.Controls.Add(this.groupBox5);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummary.Size = new System.Drawing.Size(768, 570);
            this.tabPageSummary.TabIndex = 4;
            this.tabPageSummary.Text = "Summary";
            this.tabPageSummary.Enter += new System.EventHandler(this.tabPageSummary_Enter);
            // 
            // listViewSummary
            // 
            this.listViewSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSummary.HideSelection = false;
            this.listViewSummary.Location = new System.Drawing.Point(260, 6);
            this.listViewSummary.Name = "listViewSummary";
            this.listViewSummary.Size = new System.Drawing.Size(502, 556);
            this.listViewSummary.TabIndex = 12;
            this.listViewSummary.UseCompatibleStateImageBehavior = false;
            this.listViewSummary.View = System.Windows.Forms.View.Details;
            // 
            // buttonSummaryBack
            // 
            this.buttonSummaryBack.Location = new System.Drawing.Point(136, 266);
            this.buttonSummaryBack.Name = "buttonSummaryBack";
            this.buttonSummaryBack.Size = new System.Drawing.Size(118, 23);
            this.buttonSummaryBack.TabIndex = 11;
            this.buttonSummaryBack.Text = "Back";
            this.buttonSummaryBack.UseVisualStyleBackColor = true;
            this.buttonSummaryBack.Click += new System.EventHandler(this.buttonSummaryBack_Click);
            // 
            // buttonSummaryPlaceOrder
            // 
            this.buttonSummaryPlaceOrder.Location = new System.Drawing.Point(136, 237);
            this.buttonSummaryPlaceOrder.Name = "buttonSummaryPlaceOrder";
            this.buttonSummaryPlaceOrder.Size = new System.Drawing.Size(118, 23);
            this.buttonSummaryPlaceOrder.TabIndex = 11;
            this.buttonSummaryPlaceOrder.Text = "Place Order";
            this.buttonSummaryPlaceOrder.UseVisualStyleBackColor = true;
            this.buttonSummaryPlaceOrder.Click += new System.EventHandler(this.buttonSummaryPlaceOrder_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelOrderSummary);
            this.groupBox6.Location = new System.Drawing.Point(6, 152);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(248, 79);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Order Summary";
            // 
            // labelOrderSummary
            // 
            this.labelOrderSummary.Location = new System.Drawing.Point(6, 24);
            this.labelOrderSummary.Name = "labelOrderSummary";
            this.labelOrderSummary.Size = new System.Drawing.Size(236, 52);
            this.labelOrderSummary.TabIndex = 0;
            this.labelOrderSummary.Text = "Subtotal (# items) : 9999.00\r\n\r\nTotal: 9999.00";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelBillAndShip);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 131);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Billing and Shipping";
            // 
            // labelBillAndShip
            // 
            this.labelBillAndShip.Location = new System.Drawing.Point(6, 24);
            this.labelBillAndShip.Name = "labelBillAndShip";
            this.labelBillAndShip.Size = new System.Drawing.Size(236, 84);
            this.labelBillAndShip.TabIndex = 0;
            this.labelBillAndShip.Text = "Full Name\r\n\r\nPhone Number\r\n\r\nAddress";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.labelAddress);
            this.groupBox10.Location = new System.Drawing.Point(6, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(242, 88);
            this.groupBox10.TabIndex = 13;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Address Details";
            // 
            // labelAddress
            // 
            this.labelAddress.Location = new System.Drawing.Point(6, 19);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(230, 59);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 614);
            this.Controls.Add(this.tabControlOrder);
            this.MinimumSize = new System.Drawing.Size(809, 501);
            this.Name = "FormOrder";
            this.Text = "FormOrder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrder_FormClosing);
            this.tabControlOrder.ResumeLayout(false);
            this.tabPageProduct.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageOrderItems.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageCustomer.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageShippingAddress.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageSummary.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlOrder;
        private System.Windows.Forms.TabPage tabPageProduct;
        private System.Windows.Forms.TabPage tabPageOrderItems;
        private System.Windows.Forms.TabPage tabPageCustomer;
        private System.Windows.Forms.TabPage tabPageShippingAddress;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxProductMaxPrice;
        private System.Windows.Forms.TextBox textBoxProductMinPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxProductDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listViewProduct;
        private System.Windows.Forms.TextBox textBoxProductQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonProductCancel;
        private System.Windows.Forms.Button buttonProductReset;
        private System.Windows.Forms.Button buttonProductSearch;
        private System.Windows.Forms.Button buttonProductAdd;
        private System.Windows.Forms.Button buttonProductNext;
        private System.Windows.Forms.Button buttonOrderItemRemove;
        private System.Windows.Forms.Button buttonOrderItemUpdate;
        private System.Windows.Forms.Button buttonOrderItemNext;
        private System.Windows.Forms.Button buttonOrderItemBack;
        private System.Windows.Forms.Button buttonOrderItemReset;
        private System.Windows.Forms.ListView listViewOrderItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxOrderItemQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxCustomerPhoneNumber;
        private System.Windows.Forms.TextBox textBoxCustomerFirstName;
        private System.Windows.Forms.TextBox textBoxCustomerLastName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonCustomerSearch;
        private System.Windows.Forms.Button buttonCustomerNext;
        private System.Windows.Forms.Button buttonCustomerReset;
        private System.Windows.Forms.ListView listViewCustomer;
        private System.Windows.Forms.Button buttonCustomerBack;
        private System.Windows.Forms.Button buttonAddressBack;
        private System.Windows.Forms.Button buttonAddressNext;
        private System.Windows.Forms.Button buttonAddressReset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxAddressBarangay;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxAddressHouse;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxAddressProvince;
        private System.Windows.Forms.TextBox textBoxAddressCity;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView listViewAddress;
        private System.Windows.Forms.Button buttonAddressSearch;
        private System.Windows.Forms.ListView listViewSummary;
        private System.Windows.Forms.Button buttonSummaryPlaceOrder;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelOrderSummary;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelBillAndShip;
        private System.Windows.Forms.Button buttonSummaryBack;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label labelOrderItem;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label labelAddress;
    }
}