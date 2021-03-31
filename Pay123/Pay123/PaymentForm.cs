using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pay123.Data;
using Pay123.Models;
using Pay123.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

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
            string merchantName, string statusName, string userId, string attachment)
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
            cmbMerchant.Text = merchantName;
            cmbStatuses.Text = statusName;
            txtUserId.Text = userId;
            txtAttachement.Text = attachment;
        }

        private decimal ComputeServiceFee(decimal value)
        {
            return (value * (5.00M / 100.00M));
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
            payment.ServiceFee = ComputeServiceFee(numAmount.Value);
            payment.PPRemarks = txtPPRemarks.Text;
            payment.StatusId = Convert.ToInt32(cmbStatuses.SelectedValue);
            payment.UserId = txtUserId.Text;
            payment.Attachment = txtAttachement.Text;

            if(Convert.ToInt32(cmbStatuses.SelectedValue) == 3)
            {
                var payFromDb = db.Payments.Any(p => p.ReferenceNumber == payment.ReferenceNumber);

                if (payFromDb == true)
                {
                    MessageBox.Show("This record is already save to database.", "Duplicate Record Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    payment.ProcessedBy = GlobalUser.Username;
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

        #region Upload File to google drive
        //private static string GetMimeType(string fileName) 
        //{ 
        //    string mimeType = "application/unknown"; 
        //    string ext = System.IO.Path.GetExtension(fileName).ToLower(); 
        //    Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext); 
        //    if (regKey != null && regKey.GetValue("Content Type") != null) 
        //        mimeType = regKey.GetValue("Content Type").ToString(); 
        //    System.Diagnostics.Debug.WriteLine(mimeType); return mimeType; 
        //}
        //private void Authorize()
        //{
        //    string[] scopes = new string[] { DriveService.Scope.Drive,
        //                           DriveService.Scope.DriveFile,};
        //    var clientId = "445231420300-t5akqauhjo3msm9kr7m4ts2sse2qr52r.apps.googleusercontent.com";      // From https://console.developers.google.com  
        //    var clientSecret = "YuITz_zL64_E-_IY-Yq1ukzq";          // From https://console.developers.google.com  
        //                                                                 // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
        //    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
        //    {
        //        ClientId = clientId,
        //        ClientSecret = clientSecret
        //    }, scopes,
        //    Environment.UserName, CancellationToken.None, new FileDataStore("MyAppsToken")).Result;
        //    //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   

        //    DriveService service = new DriveService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = "Payment123",

        //    });
        //    service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
        //    //Long Operations like file uploads might timeout. 100 is just precautionary value, can be set to any reasonable value depending on what you use your service for  

        //    // team drive root https://drive.google.com/drive/folders/0AAE83zjNwK-GUk9PVA   

        //    var respocne = uploadFile(service, txtAttachement.Text, "");
        //    // Third parameter is empty it means it would upload to root directory, if you want to upload under a folder, pass folder's id here.
        //    MessageBox.Show("Process completed--- Response--" + respocne);
        //}


        //public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, string _descrp = "Uploaded with .NET!")
        //{
        //    if (System.IO.File.Exists(_uploadFile))
        //    {
        //        Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
        //        body.Name = System.IO.Path.GetFileName(_uploadFile);
        //        body.Description = _descrp;
        //        body.MimeType = GetMimeType(_uploadFile);
        //        // body.Parents = new List<string> { _parent };// UN comment if you want to upload to a folder(ID of parent folder need to be send as paramter in above method)
        //        byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
        //        System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
        //        try
        //        {
        //            FilesResource.CreateMediaUpload request = _service.Files.Create(body, stream, GetMimeType(_uploadFile));
        //            request.SupportsTeamDrives = true;
        //            // You can bind event handler with progress changed event and response recieved(completed event)
        //            request.ProgressChanged += Request_ProgressChanged;
        //            request.ResponseReceived += Request_ResponseReceived;
        //            request.Upload();
        //            return request.ResponseBody;
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message, "Error Occured");
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("The file does not exist.", "404");
        //        return null;
        //    }
        //}

        //private void Request_ProgressChanged(Google.Apis.Upload.IUploadProgress obj)
        //{
        //    if (obj.Status != Google.Apis.Upload.UploadStatus.Completed)
        //    {
        //        textBox1.Text += obj.Status + " " + obj.BytesSent;
        //    }
        //}
        //private void Request_ResponseReceived(Google.Apis.Drive.v3.Data.File obj) 
        //{ 
        //    if (obj == null) 
        //    { 
        //        MessageBox.Show("Upload Failed !!!"); 
        //    } 
        //}

        //private void Request_ProgressChanged(Google.Apis.Upload.IUploadProgress obj)
        //{
        //    txtAttachement.Text += obj.Status + " " + obj.BytesSent;
        //}

        //private void Request_ResponseReceived(Google.Apis.Drive.v3.Data.File obj)
        //{
        //    if (obj != null)
        //    {
        //        MessageBox.Show("File was uploaded sucessfully--" + obj.Id);
        //    }
        //}
        #endregion

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html; *.jpeg; *.jpg; *.png;";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        txtAttachement.Text = path;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //private void btnUpload_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    try
        //    {
        //        string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
        //        if (filename == null)
        //        {
        //            MessageBox.Show("Please select a valid document.");
        //        }
        //        else
        //        {
        //            txtAttachement.Text = filename;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
