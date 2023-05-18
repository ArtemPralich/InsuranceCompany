using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace InsuranceCompany.MobileClient.Interceptors
{
    public class JwtTokenInterceptor : DelegatingHandler
    {
        private readonly string _jwtToken;

        public JwtTokenInterceptor(string jwtToken)
        {
            _jwtToken = jwtToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Добавляем заголовок с JWT токеном к каждому запросу
            request.Headers.Add("Authorization", $"Bearer {_jwtToken}");

            // Продолжаем выполнение запроса
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
