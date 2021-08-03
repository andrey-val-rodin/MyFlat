using MyFlat.Common;
using MyFlat.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace MyFlat.Services
{
    public class GlobusService
    {
        private readonly IMessenger _messenger;
        private readonly HttpClient _httpClient = new HttpClient();
        private string _sessionId;

        public bool IsAuthorized
        {
            get
            {
                return !string.IsNullOrEmpty(_sessionId);
            }
        }

        public GlobusService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public async Task<bool> AuthorizeAsync(string login, string password)
        {
            if (IsAuthorized)
                return true;

            _sessionId = await RetrieveSessionIdAsync();

            var request = CreateRequest(
                new Uri("https://lk.globusenergo.ru/ajax/auth.php"),
                $"tourl=%2Fpersonal%2Finfo%2F&AUTH_FORM=Y&TYPE=AUTH&USER_LOGIN={HttpUtility.UrlEncode(login)}&USER_PASSWORD={HttpUtility.UrlEncode(password)}",
                "https://lk.globusenergo.ru/"
                );

            var response = await SendAsync(request);
            if (response?.StatusCode != HttpStatusCode.OK)
            {
                _messenger.ShowError($"Сервер lk.globusenergo.ru вернул код ошибки {response?.StatusCode.ToString()}");
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            if (content.Contains("ERROR|Неверный логин или пароль"))
            {
                _messenger.ShowError("Глобус: Неверный логин или пароль");
                _sessionId = null;
            }

            return IsAuthorized;
        }

        private async Task<string> RetrieveSessionIdAsync()
        {
            var container = new CookieContainer();
            var uri = new Uri("https://lk.globusenergo.ru/");
            using var httpClientHandler = new HttpClientHandler { CookieContainer = container };
            using var httpClient = new HttpClient(httpClientHandler);
            await httpClient.GetAsync(uri);

            var cookies = container.GetCookies(uri).Cast<Cookie>().ToList();
            return cookies.FirstOrDefault(c => c.Name == "PHPSESSID")?.Value;
        }

        public async Task<bool> LogoffAsync()
        {
            if (!IsAuthorized)
                throw new InvalidOperationException();

            var request = CreateRequest(
                new Uri("https://lk.globusenergo.ru/personal/info/?logout=yes"),
                "",
                "https://lk.globusenergo.ru/personal/info/");

            var response = await SendAsync(request);
            if (response?.StatusCode != HttpStatusCode.OK)
            {
                _messenger.ShowError($"Сервер lk.globusenergo.ru вернул код ошибки {response?.StatusCode.ToString()}");
                return false;
            }

            await response.Content.ReadAsStringAsync();

            _sessionId = null;
            return !IsAuthorized;
        }

        private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (HttpRequestException e)
            {
                _messenger.ShowError(e.Message);
            }

            return response;
        }

        private HttpRequestMessage CreateRequest(Uri uri, string content, string referrer)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if (referrer == null)
                throw new ArgumentNullException(nameof(referrer));

            var request = new HttpRequestMessage
            {
                RequestUri = uri,
                Method = HttpMethod.Post,
                Content = new StringContent(content)
            };

            request.Headers.Connection.Add("keep-alive");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            request.Headers.Add("Origin", "https://lk.globusenergo.ru");
            request.Headers.Add("Sec-Fetch-Site", "same-origin");
            request.Headers.Add("Sec-Fetch-Mode", "cors");
            request.Headers.Add("Sec-Fetch-Dest", "empty");
            request.Headers.Add("Referer", referrer);
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Cookie", $"PHPSESSID={_sessionId}; BITRIX_SM_GUEST_ID=115872; BITRIX_SM_LAST_VISIT=02.08.2021+12%3A11%3A09; BITRIX_CONVERSION_CONTEXT_s1=%7B%22ID%22%3A8%2C%22EXPIRE%22%3A1627937940%2C%22UNIQUE%22%3A%5B%22conversion_visit_day%22%5D%7D; BX_USER_ID=02c28ee84de81190c66c50093df21db8");

            return request;
        }

        public async Task<decimal?> GetBalanceAsync()
        {
            if (!IsAuthorized)
                throw new InvalidOperationException();

            var request = CreateRequest(
               new Uri("https://lk.globusenergo.ru/personal/info/ "),
               "",
               "https://lk.globusenergo.ru/");

            var response = await SendAsync(request);
            if (response?.StatusCode != HttpStatusCode.OK)
            {
                _messenger.ShowError($"Сервер lk.globusenergo.ru вернул код ошибки {response?.StatusCode.ToString()}");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            if (!BalanceRetriever.TryGetBalance(content, out decimal result))
            {
                _messenger.ShowError("Ошибка при получении баланса с сервера lk.globusenergo.ru");
                return null;
            }

            return result;
        }
    }
}
