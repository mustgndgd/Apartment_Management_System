using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Apartment.App.Web.PaymentApiService
{
    public static class PaymentService
    {
        private const string url = "https://localhost:44310/api/Payment";
        public static string Pay(PaymentModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:44310/api/Payment";
            using var client = new HttpClient();
            var response = client.PostAsync(url, data).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return result;
            }
            return "-1";
        }

        public static PaymentModel GetPayment(string id)
        {
            var url1 = url+"/"+ id;
            using var client = new HttpClient();
            var response = client.GetAsync(url1).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<PaymentModel>(result);
            }
            return null;
        }

    }
}
