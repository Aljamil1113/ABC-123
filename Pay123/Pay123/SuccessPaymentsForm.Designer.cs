
namespace Pay123
{
    partial class SuccessPaymentsForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtmFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtmTo = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.PaymentsStatusMerchantBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Payment123DataSet = new Pay123.Payment123DataSet();
            this.PaymentsStatusMerchantTableAdapter = new Pay123.Payment123DataSetTableAdapters.PaymentsStatusMerchantTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsStatusMerchantBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment123DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.PaymentsStatusMerchantBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pay123.paymentReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(29, 62);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1307, 471);
            this.reportViewer1.TabIndex = 0;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(419, 28);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(49, 17);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "From:";
            // 
            // dtmFrom
            // 
            this.dtmFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFrom.Location = new System.Drawing.Point(489, 23);
            this.dtmFrom.Name = "dtmFrom";
            this.dtmFrom.Size = new System.Drawing.Size(128, 22);
            this.dtmFrom.TabIndex = 2;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(647, 26);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(32, 17);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To:";
            // 
            // dtmTo
            // 
            this.dtmTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmTo.Location = new System.Drawing.Point(696, 23);
            this.dtmTo.Name = "dtmTo";
            this.dtmTo.Size = new System.Drawing.Size(127, 22);
            this.dtmTo.TabIndex = 4;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Bisque;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(847, 17);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(82, 34);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // PaymentsStatusMerchantBindingSource
            // 
            this.PaymentsStatusMerchantBindingSource.DataMember = "PaymentsStatusMerchant";
            this.PaymentsStatusMerchantBindingSource.DataSource = this.Payment123DataSet;
            // 
            // Payment123DataSet
            // 
            this.Payment123DataSet.DataSetName = "Payment123DataSet";
            this.Payment123DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PaymentsStatusMerchantTableAdapter
            // 
            this.PaymentsStatusMerchantTableAdapter.ClearBeforeFill = true;
            // 
            // SuccessPaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 545);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dtmTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtmFrom);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SuccessPaymentsForm";
            this.ShowIcon = false;
            this.Text = "Success Payments";
            this.Load += new System.EventHandler(this.SuccessPaymentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsStatusMerchantBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment123DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtmFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtmTo;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.BindingSource PaymentsStatusMerchantBindingSource;
        private Payment123DataSet Payment123DataSet;
        private Payment123DataSetTableAdapters.PaymentsStatusMerchantTableAdapter PaymentsStatusMerchantTableAdapter;
    }
}