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

            this.reportViewer1.RefreshReport();
        }
    }
}
