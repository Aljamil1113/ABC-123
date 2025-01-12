﻿using Newtonsoft.Json;
using Pay123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pay123.Services
{
    public static class RestService
    {
        private static readonly string baseURL = "https://localhost:44324/api/";   

        public static async Task<IEnumerable<PaymentsStatusMerchant>> GetPayments()
        {
            var payments = new List<PaymentsStatusMerchant>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);

                    var response = client.GetAsync("paymentsend").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var readPayments = await response.Content.ReadAsStringAsync();

                        var responseAsPayments = JsonConvert.DeserializeObject<List<PaymentsStatusMerchant>>(readPayments);

                        payments = responseAsPayments;
                    }
                    else
                    {
                        MessageBox.Show("Error Connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (WebException err)
            {

                MessageBox.Show(err.ToString(), "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
            return payments;
        }

        
        public static async Task EditPaymentSend(Payment payment)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);

                    var response = await client.PutAsync($"paymentsend/{payment.ReferenceNumber}", new StringContent(
                            JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Successfully update record Ref #: {payment.ReferenceNumber}.", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    }

                    else
                    {
                        MessageBox.Show("Error Connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (WebException err)
            {

                MessageBox.Show(err.ToString(), "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
