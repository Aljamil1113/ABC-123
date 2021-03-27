using Newtonsoft.Json;
using Pay123.Data;
using Pay123.Models;
using Pay123.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pay123
{
    public partial class Payment123 : Form
    {
        private Payment paymentSend = new Payment();
        private readonly Pay123Db db;
        public Payment123()
        {
            InitializeComponent();
            db = new Pay123Db();
            LoadData();
        }

        public async void LoadData()
        {
            paymentDataGridView.DataSource = await RestService.GetPayments();
            paymentDataGridView.Columns["UserId"].Visible = false;
        }

        

        private void paymentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            paymentSend.Date = Convert.ToDateTime(paymentDataGridView.Rows[e.RowIndex].Cells[0].FormattedValue);
            paymentSend.ReferenceNumber = paymentDataGridView.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            paymentSend.Client = paymentDataGridView.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            paymentSend.Customer = paymentDataGridView.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            paymentSend.MerchantId = Convert.ToInt32(paymentDataGridView.Rows[e.RowIndex].Cells[4].FormattedValue);
            paymentSend.AccountNumber = paymentDataGridView.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
            paymentSend.AccountName = paymentDataGridView.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
            paymentSend.OtherDetails = paymentDataGridView.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
            paymentSend.Amount = Convert.ToDecimal(paymentDataGridView.Rows[e.RowIndex].Cells[8].FormattedValue);

            paymentSend.ServiceFee = paymentDataGridView.Rows[e.RowIndex].Cells[9].Value == null ? 0.00M 
                : Convert.ToDecimal(paymentDataGridView.Rows[e.RowIndex].Cells[9].FormattedValue.ToString());

            paymentSend.PPRemarks = paymentDataGridView.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
            paymentSend.StatusId = Convert.ToInt32(paymentDataGridView.Rows[e.RowIndex].Cells[11].FormattedValue);
            paymentSend.UserId = paymentDataGridView.Rows[e.RowIndex].Cells[12].FormattedValue.ToString();

           
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();

            if(paymentSend.ReferenceNumber == null)
            {
                MessageBox.Show("Please select a record", "No Select Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                paymentSend.Date = DateTime.Now;
                paymentSend.ServiceFee = 0.00M;
                paymentSend.MerchantId = 1;
                paymentSend.StatusId = 1;
            }
            else
            {
                paymentForm.PreviewPayment(paymentSend.ReferenceNumber, paymentSend.Date, paymentSend.AccountNumber, paymentSend.AccountName,
                paymentSend.OtherDetails, paymentSend.Amount, paymentSend.ServiceFee, paymentSend.PPRemarks, paymentSend.Client,
                paymentSend.Customer, paymentSend.MerchantId, paymentSend.StatusId, paymentSend.UserId);

                paymentForm.ShowDialog();
            }
            
        }

        private void btnRefreshPay_Click(object sender, EventArgs e)
        {
            paymentDataGridView.Refresh();
            LoadData();
        }
    }
}
