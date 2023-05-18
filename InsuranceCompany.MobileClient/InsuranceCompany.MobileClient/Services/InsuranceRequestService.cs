using InsuranceCompany.MobileClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InsuranceCompany.MobileClient.Services
{
    public class InsuranceRequestService
    {
        const string Url = "https://10.0.2.2:7046/api/InsuranceRequest/";
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public async Task<List<InsuranceRequest>> GetClientInsurances()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient client = new HttpClient(clientHandler);

            if (App.Current.Properties.TryGetValue("token", out object buff))
            {
                if (buff != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", buff.ToString());
                }
            }
            var response = await client.GetAsync(Url + "GetClientInsurances");
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<List<InsuranceRequest>>(
                await response.Content.ReadAsStringAsync(), options);
        }
    }
}
