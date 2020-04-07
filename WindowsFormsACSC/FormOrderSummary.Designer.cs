namespace WindowsFormsACSC
{
    partial class FormOrderSummary
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
            this.listViewSummary = new System.Windows.Forms.ListView();
            this.buttonSummaryBack = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelOrderSummary = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelBillAndShip = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewSummary
            // 
            this.listViewSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSummary.HideSelection = false;
            this.listViewSummary.Location = new System.Drawing.Point(266, 12);
            this.listViewSummary.Name = "listViewSummary";
            this.listViewSummary.Size = new System.Drawing.Size(522, 426);
            this.listViewSummary.TabIndex = 17;
            this.listViewSummary.UseCompatibleStateImageBehavior = false;
            this.listViewSummary.View = System.Windows.Forms.View.Details;
            // 
            // buttonSummaryBack
            // 
            this.buttonSummaryBack.Location = new System.Drawing.Point(142, 243);
            this.buttonSummaryBack.Name = "buttonSummaryBack";
            this.buttonSummaryBack.Size = new System.Drawing.Size(118, 23);
            this.buttonSummaryBack.TabIndex = 15;
            this.buttonSummaryBack.Text = "Back";
            this.buttonSummaryBack.UseVisualStyleBackColor = true;
            this.buttonSummaryBack.Click += new System.EventHandler(this.buttonSummaryBack_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelOrderSummary);
            this.groupBox6.Location = new System.Drawing.Point(12, 158);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(248, 79);
            this.groupBox6.TabIndex = 14;
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
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 131);
            this.groupBox5.TabIndex = 13;
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
            // FormOrderSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewSummary);
            this.Controls.Add(this.buttonSummaryBack);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Name = "FormOrderSummary";
            this.Text = "FormOrderItems";
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewSummary;
        private System.Windows.Forms.Button buttonSummaryBack;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelOrderSummary;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelBillAndShip;
    }
}