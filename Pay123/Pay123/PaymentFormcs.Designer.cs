
namespace Pay123
{
    partial class PaymentForm
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
            this.cmbMerchant = new System.Windows.Forms.ComboBox();
            this.lblMerchant = new System.Windows.Forms.Label();
            this.dtmDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblReferenceNumber = new System.Windows.Forms.Label();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtOtherDetails = new System.Windows.Forms.TextBox();
            this.lblOtherDetails = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblServiceFee = new System.Windows.Forms.Label();
            this.txtPPRemarks = new System.Windows.Forms.TextBox();
            this.lblPPRemarks = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatuses = new System.Windows.Forms.ComboBox();
            this.btnSavePay = new System.Windows.Forms.Button();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.numServiceFee = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceFee)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMerchant
            // 
            this.cmbMerchant.DisplayMember = "MerchantId";
            this.cmbMerchant.FormattingEnabled = true;
            this.cmbMerchant.Location = new System.Drawing.Point(195, 47);
            this.cmbMerchant.Name = "cmbMerchant";
            this.cmbMerchant.Size = new System.Drawing.Size(199, 26);
            this.cmbMerchant.TabIndex = 0;
            this.cmbMerchant.ValueMember = "MerchantId";
            // 
            // lblMerchant
            // 
            this.lblMerchant.AutoSize = true;
            this.lblMerchant.Location = new System.Drawing.Point(18, 47);
            this.lblMerchant.Name = "lblMerchant";
            this.lblMerchant.Size = new System.Drawing.Size(83, 18);
            this.lblMerchant.TabIndex = 1;
            this.lblMerchant.Text = "Merchant:";
            // 
            // dtmDate
            // 
            this.dtmDate.CustomFormat = "MMMM dd, yyyy";
            this.dtmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmDate.Location = new System.Drawing.Point(195, 92);
            this.dtmDate.Name = "dtmDate";
            this.dtmDate.Size = new System.Drawing.Size(199, 24);
            this.dtmDate.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(18, 92);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(48, 18);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date:";
            // 
            // lblReferenceNumber
            // 
            this.lblReferenceNumber.AutoSize = true;
            this.lblReferenceNumber.Location = new System.Drawing.Point(18, 139);
            this.lblReferenceNumber.Name = "lblReferenceNumber";
            this.lblReferenceNumber.Size = new System.Drawing.Size(154, 18);
            this.lblReferenceNumber.TabIndex = 4;
            this.lblReferenceNumber.Text = "Reference Number:";
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.Location = new System.Drawing.Point(195, 139);
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(199, 24);
            this.txtReferenceNumber.TabIndex = 5;
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(195, 295);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(199, 24);
            this.txtAccountNumber.TabIndex = 7;
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Location = new System.Drawing.Point(18, 295);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(138, 18);
            this.lblAccountNumber.TabIndex = 6;
            this.lblAccountNumber.Text = "Account Number:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(195, 357);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(199, 24);
            this.txtAccountName.TabIndex = 9;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(18, 357);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(123, 18);
            this.lblAccountName.TabIndex = 8;
            this.lblAccountName.Text = "Account Name:";
            // 
            // txtOtherDetails
            // 
            this.txtOtherDetails.Location = new System.Drawing.Point(601, 183);
            this.txtOtherDetails.Multiline = true;
            this.txtOtherDetails.Name = "txtOtherDetails";
            this.txtOtherDetails.Size = new System.Drawing.Size(282, 122);
            this.txtOtherDetails.TabIndex = 11;
            // 
            // lblOtherDetails
            // 
            this.lblOtherDetails.AutoSize = true;
            this.lblOtherDetails.Location = new System.Drawing.Point(473, 186);
            this.lblOtherDetails.Name = "lblOtherDetails";
            this.lblOtherDetails.Size = new System.Drawing.Size(112, 18);
            this.lblOtherDetails.TabIndex = 10;
            this.lblOtherDetails.Text = "Other Details:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(473, 50);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(70, 18);
            this.lblAmount.TabIndex = 12;
            this.lblAmount.Text = "Amount:";
            // 
            // lblServiceFee
            // 
            this.lblServiceFee.AutoSize = true;
            this.lblServiceFee.Location = new System.Drawing.Point(473, 92);
            this.lblServiceFee.Name = "lblServiceFee";
            this.lblServiceFee.Size = new System.Drawing.Size(102, 18);
            this.lblServiceFee.TabIndex = 14;
            this.lblServiceFee.Text = "Service Fee:";
            // 
            // txtPPRemarks
            // 
            this.txtPPRemarks.Location = new System.Drawing.Point(603, 322);
            this.txtPPRemarks.Multiline = true;
            this.txtPPRemarks.Name = "txtPPRemarks";
            this.txtPPRemarks.Size = new System.Drawing.Size(283, 116);
            this.txtPPRemarks.TabIndex = 17;
            // 
            // lblPPRemarks
            // 
            this.lblPPRemarks.AutoSize = true;
            this.lblPPRemarks.Location = new System.Drawing.Point(473, 322);
            this.lblPPRemarks.Name = "lblPPRemarks";
            this.lblPPRemarks.Size = new System.Drawing.Size(108, 18);
            this.lblPPRemarks.TabIndex = 16;
            this.lblPPRemarks.Text = "PP Remarks:";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(195, 186);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(199, 24);
            this.txtClientName.TabIndex = 19;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(18, 186);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(105, 18);
            this.lblClientName.TabIndex = 18;
            this.lblClientName.Text = "Client Name:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(195, 238);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(199, 24);
            this.txtCustomer.TabIndex = 21;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(18, 238);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 18);
            this.lblCustomer.TabIndex = 20;
            this.lblCustomer.Text = "Customer:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(473, 139);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(61, 18);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatuses
            // 
            this.cmbStatuses.FormattingEnabled = true;
            this.cmbStatuses.Items.AddRange(new object[] {
            "None"});
            this.cmbStatuses.Location = new System.Drawing.Point(607, 132);
            this.cmbStatuses.Name = "cmbStatuses";
            this.cmbStatuses.Size = new System.Drawing.Size(176, 26);
            this.cmbStatuses.TabIndex = 22;
            // 
            // btnSavePay
            // 
            this.btnSavePay.BackColor = System.Drawing.Color.Aqua;
            this.btnSavePay.Location = new System.Drawing.Point(316, 479);
            this.btnSavePay.Name = "btnSavePay";
            this.btnSavePay.Size = new System.Drawing.Size(134, 37);
            this.btnSavePay.TabIndex = 24;
            this.btnSavePay.Text = "Save";
            this.btnSavePay.UseVisualStyleBackColor = false;
            this.btnSavePay.Click += new System.EventHandler(this.btnSavePay_Click);
            // 
            // numAmount
            // 
            this.numAmount.DecimalPlaces = 2;
            this.numAmount.Location = new System.Drawing.Point(606, 42);
            this.numAmount.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(177, 24);
            this.numAmount.TabIndex = 26;
            // 
            // numServiceFee
            // 
            this.numServiceFee.DecimalPlaces = 2;
            this.numServiceFee.Location = new System.Drawing.Point(607, 87);
            this.numServiceFee.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numServiceFee.Name = "numServiceFee";
            this.numServiceFee.Size = new System.Drawing.Size(176, 24);
            this.numServiceFee.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gold;
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.lblMerchant);
            this.groupBox1.Controls.Add(this.btnSavePay);
            this.groupBox1.Controls.Add(this.numServiceFee);
            this.groupBox1.Controls.Add(this.txtPPRemarks);
            this.groupBox1.Controls.Add(this.cmbStatuses);
            this.groupBox1.Controls.Add(this.lblPPRemarks);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.txtOtherDetails);
            this.groupBox1.Controls.Add(this.cmbMerchant);
            this.groupBox1.Controls.Add(this.lblOtherDetails);
            this.groupBox1.Controls.Add(this.numAmount);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.dtmDate);
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.txtClientName);
            this.groupBox1.Controls.Add(this.lblAccountName);
            this.groupBox1.Controls.Add(this.lblReferenceNumber);
            this.groupBox1.Controls.Add(this.txtAccountNumber);
            this.groupBox1.Controls.Add(this.lblClientName);
            this.groupBox1.Controls.Add(this.lblAccountNumber);
            this.groupBox1.Controls.Add(this.txtReferenceNumber);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.lblServiceFee);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(62, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 539);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Details";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(195, 415);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(199, 24);
            this.txtUserId.TabIndex = 28;
            this.txtUserId.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(490, 479);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 37);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(1029, 600);
            this.Controls.Add(this.groupBox1);
            this.Name = "PaymentForm";
            this.Text = "Payment Form";
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceFee)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMerchant;
        private System.Windows.Forms.Label lblMerchant;
        private System.Windows.Forms.DateTimePicker dtmDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblReferenceNumber;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TextBox txtOtherDetails;
        private System.Windows.Forms.Label lblOtherDetails;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblServiceFee;
        private System.Windows.Forms.TextBox txtPPRemarks;
        private System.Windows.Forms.Label lblPPRemarks;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatuses;
        private System.Windows.Forms.Button btnSavePay;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.NumericUpDown numServiceFee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Button btnCancel;
    }
}