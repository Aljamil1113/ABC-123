using Pay123.Data;
using Pay123.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pay123
{
    public partial class SuccessPaymentsForm : Form
    {
        public SuccessPaymentsForm()
        {
            InitializeComponent();
        }

        private void SuccessPaymentsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Payment123DataSet.PaymentsStatusMerchant' table. You can move, or remove it, as needed.
            
            this.PaymentsStatusMerchantTableAdapter.Fill(this.Payment123DataSet.PaymentsStatusMerchant);

            reportViewer1.RefreshReport();

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PaymentsStatusMerchantTableAdapter.FillByDate(this.Payment123DataSet.PaymentsStatusMerchant, dtmFrom.Value.ToString(), dtmTo.Value.ToString());
            Microsoft.Reporting.WinForms.ReportParameter[] rparams = new Microsoft.Reporting.WinForms.ReportParameter[]
              {
                    new Microsoft.Reporting.WinForms.ReportParameter("DateFrom", dtmFrom.Value.ToShortDateString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("DateTo", dtmTo.Value.ToShortDateString())
              };
            reportViewer1.LocalReport.SetParameters(rparams);
            reportViewer1.RefreshReport();

        }
    }
}
