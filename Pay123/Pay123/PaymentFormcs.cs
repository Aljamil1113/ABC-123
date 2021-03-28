using Pay123.Data;
using Pay123.Models;
using Pay123.Services;
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
    public partial class PaymentForm : Form
    {
        private readonly Pay123Db db;
        private Payment payment = new Payment();
        public PaymentForm()
        {
            db = new Pay123Db();
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            var merchants = db.Merchants.ToList();
            cmbMerchant.DataSource = merchants;
            cmbMerchant.DisplayMember = "MerchantName";
            cmbMerchant.ValueMember = "MerchantId";

            var status = db.Statuses.ToList();
            cmbStatuses.DataSource = status;
            cmbStatuses.DisplayMember = "StatusName";
            cmbStatuses.ValueMember = "StatusId";
            
        }

        private string LoadMerchant(int id)
        {
            var merchant = db.Merchants.Where(m => m.MerchantId == id).FirstOrDefault();

            return merchant.MerchantName;
        }

        private string LoadStatus(int id)
        {
            var merchant = db.Statuses.Where(m => m.StatusId == id).FirstOrDefault();
            return merchant.StatusName;
        }

        public void PreviewPayment(string referenceNumber, DateTime date, string accountNumber, string accountName,
            string otherDetails, decimal amount, decimal? serviceFee, string ppRemarks, string clientName, string customerName,
            int merchantId, int statusId, string userId)
        {
            txtReferenceNumber.Text = referenceNumber;
            if(date == null)
            {
                dtmDate.Value = DateTime.Now;
            }
            else
            {
                dtmDate.Value = date;
            }
           
            txtAccountNumber.Text = accountNumber;
            txtAccountName.Text = accountName;
            txtOtherDetails.Text = otherDetails;
            numAmount.Value = amount;
            numServiceFee.Value = (decimal)serviceFee;
            txtPPRemarks.Text = ppRemarks;
            txtClientName.Text = clientName;
            txtCustomer.Text = customerName;
            cmbMerchant.Text = LoadMerchant(merchantId);
            cmbStatuses.Text = LoadStatus(statusId);
            txtUserId.Text = userId;
        }

        private async void btnSavePay_Click(object sender, EventArgs e)
        {
            payment.ReferenceNumber = txtReferenceNumber.Text;
            payment.Date = dtmDate.Value;
            payment.Client = txtClientName.Text;
            payment.Customer = txtCustomer.Text;
            payment.MerchantId = Convert.ToInt32(cmbMerchant.SelectedValue);
            payment.AccountNumber = txtAccountNumber.Text;
            payment.AccountName = txtAccountName.Text;
            payment.OtherDetails = txtOtherDetails.Text;
            payment.Amount = numAmount.Value;
            payment.ServiceFee = numServiceFee.Value;
            payment.PPRemarks = txtPPRemarks.Text;
            payment.StatusId = Convert.ToInt32(cmbStatuses.SelectedValue);
            payment.UserId = txtUserId.Text;

            if(Convert.ToInt32(cmbStatuses.SelectedValue) == 3)
            {
                var payFromDb = db.Payments.Any(p => p.ReferenceNumber == payment.ReferenceNumber);

                if (payFromDb == true)
                {
                    MessageBox.Show("This record is already save to database.", "Duplicate Record Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.Payments.Add(payment);
                    await db.SaveChangesAsync();
                }
            }

            await RestService.EditPaymentSend(payment);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
