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
using PagedList;

namespace Pay123
{
    public partial class Payment123 : Form
    {
        private readonly Pay123Db db;
        private Payment paymentSend;
        private IPagedList<Payment> paymentLists;
        private int pageNumber = 1;
        private int pageSize = 3;
        public Payment123()
        {
            InitializeComponent();
            db = new Pay123Db();
            paymentSend = new Payment();
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
            Payment123_Load(sender, e);
        }

        public async Task<IPagedList<Payment>> LoadDataAsync()
        {
            List<Payment> payments = (List<Payment>)await RestService.GetPayments();
            return await Task.Factory.StartNew(() =>
            {
                return payments.ToPagedList(pageNumber, pageSize);
            });
        }

        private async void Payment123_Load(object sender, EventArgs e)
        {
            paymentLists = await LoadDataAsync();
            btnPreviousPayment.Enabled = paymentLists.HasPreviousPage;
            btnNextPayment.Enabled = paymentLists.HasNextPage;
            paymentDataGridView.DataSource = paymentLists.ToList();
            paymentDataGridView.Columns["UserId"].Visible = false;
            lblPagePayment.Text = string.Format("Page {0}/{1}", pageNumber, paymentLists.PageCount);

        }

        private async void btnPreviousPayment_Click(object sender, EventArgs e)
        {
            if(paymentLists.HasPreviousPage)
            {
                --pageNumber;
                paymentLists = await LoadDataAsync();
                btnPreviousPayment.Enabled = paymentLists.HasPreviousPage;
                btnNextPayment.Enabled = paymentLists.HasNextPage;
                paymentDataGridView.DataSource = paymentLists.ToList();
                paymentDataGridView.Columns["UserId"].Visible = false;
                lblPagePayment.Text = string.Format("Page {0}/{1}", pageNumber, paymentLists.PageCount);
            }
        }

        private async void btnNextPayment_Click(object sender, EventArgs e)
        {
            if(paymentLists.HasNextPage)
            {
                ++pageNumber;
                paymentLists = await LoadDataAsync();
                btnPreviousPayment.Enabled = paymentLists.HasPreviousPage;
                btnNextPayment.Enabled = paymentLists.HasNextPage;
                paymentDataGridView.DataSource = paymentLists.ToList();
                paymentDataGridView.Columns["UserId"].Visible = false;
                lblPagePayment.Text = string.Format("Page {0}/{1}", pageNumber, paymentLists.PageCount);
            }
        }
    }
}
