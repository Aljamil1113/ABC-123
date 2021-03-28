
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PaymentsStatusMerchantBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Payment123DataSet = new Pay123.Payment123DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PaymentsStatusMerchantTableAdapter = new Pay123.Payment123DataSetTableAdapters.PaymentsStatusMerchantTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsStatusMerchantBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment123DataSet)).BeginInit();
            this.SuspendLayout();
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
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PaymentsStatusMerchantBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pay123.PaymentPosts.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1369, 544);
            this.reportViewer1.TabIndex = 0;
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
            this.Controls.Add(this.reportViewer1);
            this.Name = "SuccessPaymentsForm";
            this.ShowIcon = false;
            this.Text = "Success Payments";
            this.Load += new System.EventHandler(this.SuccessPaymentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsStatusMerchantBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment123DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PaymentsStatusMerchantBindingSource;
        private Payment123DataSet Payment123DataSet;
        private Payment123DataSetTableAdapters.PaymentsStatusMerchantTableAdapter PaymentsStatusMerchantTableAdapter;
    }
}