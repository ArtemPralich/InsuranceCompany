using InsuranceCompany.MobileClient.Interceptors;
using InsuranceCompany.MobileClient.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InsuranceCompany.MobileClient.Services
{
    public class AuthService
    {
        const string Url = "https://10.0.2.2:7046/api/authentication/";
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем всех друзей
        public async Task<AuthentificatedUser> Login(User user)
        {

            user.UserName = user.Email;
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient client = new HttpClient(clientHandler);
            var response = await client.PostAsync(Url + "login", new StringContent(
                    JsonSerializer.Serialize(user),
                    Encoding.UTF8, "application/json"));
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<AuthentificatedUser>(
                await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<AuthentificatedUser> Regitration(RegistrationUser user)
        {

            user.UserName = user.Email;
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient client = new HttpClient(clientHandler);
            var response = await client.PostAsync(Url + "RegisterClient", new StringContent(
                    JsonSerializer.Serialize(user),
                    Encoding.UTF8, "application/json"));
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<AuthentificatedUser>(
                await response.Content.ReadAsStringAsync(), options);
        }
    }
}
