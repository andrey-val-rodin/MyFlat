using MyFlat.Common;
using MyFlat.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace MyFlat.Services
{
    public class MosOblEircService
    {
        private readonly IMessenger _messenger;
        private readonly HttpClient _httpClient = new HttpClient();
        private string _sessionId;
        private int _accountId;
        private int _abonentId;

        public bool IsAuthorized
        {
            get
            {
                return !string.IsNullOrEmpty(_sessionId);
            }
        }

        public MosOblEircService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public async Task<bool> AuthorizeAsync(string login, string password)
        {
            if (IsAuthorized)
                return true;

            var request = CreateRequest(
                new Uri("https://my.mosenergosbyt.ru/gate_lkcomu?action=auth&query=login"),
                $"login={HttpUtility.UrlEncode(login)}&psw={HttpUtility.UrlEncode(password)}&vl_device_info=%7B%22appver%22%3A%221.25.0%22%2C%22type%22%3A%22browser%22%2C%22userAgent%22%3A%22Mozilla%2F5.0%20%28Windows%20NT%206.1%3B%20Win64%3B%20x64%29%20AppleWebKit%2F537.36%20%28KHTML%2C%20like%20Gecko%29%20Chrome%2F92.0.4515.107%20Safari%2F537.36%22%7D",
                "https://my.mosenergosbyt.ru/auth"
                );

            var response = await SendAsync(request);
            if (response?.StatusCode != HttpStatusCode.OK)
            {
                _messenger.ShowError(
                    $"МосОблЕирц вернул код ошибки {response?.StatusCode.ToString()}");
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthorizationDto>(content);
            var data = result.Data.FirstOrDefault();
            if (data == null || data.Nm_result != "Ошибок нет")
            {
                _messenger.ShowError("МосОблЕирц:" + data.Nm_result);
                return false;
            }

            _sessionId = data.Session;
            if (!await RetrieveAccountInfoAsync())
                _sessionId = null;

            return IsAuthorized;
        }

        private async Task<bool> RetrieveAccountInfoAsync()
        {
            var request = CreateRequest(
                new Uri($"https://my.mosenergosbyt.ru/gate_lkcomu?action=sql&query=LSList&session={_sessionId}"),
                "",
                "https://my.mosenergosbyt.ru/accounts/0"
                );

            var response = await SendAsync(request);
            if (response?.StatusCode != HttpStatusCode.OK)
            {
                _messenger.ShowError(
                    $"МосОблЕирц вернул код ошибки {response?.StatusCode.ToString()}");
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AccountDto>(content);
            var data = result.Data.FirstOrDefault();
            if (!result.Success || data == null)
            {
                _messenger.ShowError(
                    $"МосОблЕирц: ошибка при получении учётной записи");
            }

            _accountId = data.Id_service;
            var abonent = JsonConvert.DeserializeObject<AbonentDto>(data.Vl_provider);
            _abonentId = abonent.Id_abonent;

            return true;
        }

        public async Task<bool> LogoffAsync()
        {
            if (!IsAuthorized)
                throw new InvalidOperationException();

            var request = CreateRequest(
                new Uri($"https://my.mosenergosbyt.ru/gate_lkcomu?action=invalidate&query=ProfileExit&session={_sessionId}"),
                "vl_token=",
                $"https://my.mosenergosbyt.ru/accounts/{_accountId}/events/payment-doc");

            var response = await SendAsync(request);
            if (response?.StatusCode != HttpStatusCode.OK)
            {
                _messenger.ShowError(
                    $"МосОблЕирц вернул код ошибки {response?.StatusCode.ToString()}");
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthorizationDto>(content);
            var data = result.Data.FirstOrDefault();
            if (data == null || data.Nm_result != "Ошибок нет")
            {
                _messenger.ShowError(data.Nm_result);
                return false;
            }

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
            request.Headers.Add("Origin", "https://my.mosenergosbyt.ru");
            request.Headers.Add("Sec-Fetch-Site", "same-origin");
            request.Headers.Add("Sec-Fetch-Mode", "cors");
            request.Headers.Add("Sec-Fetch-Dest", "empty");
            request.Headers.Add("Referer", referrer);
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Cookie", "_ym_uid=1583333991421670844; _ym_d=1626976476; session-cookie=1696490294bc5bb36452b75f7e477b290f5353a23208f17c6bdd7f9dce13a9cf30d2819eacec82ea0f3eb3a05451737f; _ym_isad=2; _ym_visorc=w; BITRIX_SM_GUEST_ID=13787575; BITRIX_SM_LAST_VISIT=30.07.2021+11%3A19%3A41");

            return request;
        }

        public async Task<Tuple<string, decimal>> GetBalanceAsync()
        {
            if (!IsAuthorized)
                throw new InvalidOperationException();

            var request = CreateRequest(
               new Uri($"https://my.mosenergosbyt.ru/gate_lkcomu?action=sql&query=smorodinaTransProxy&session={_sessionId}"),
               $"plugin=smorodinaTransProxy&proxyquery=AbonentCurrentBalance&vl_provider=%7B%22id_abonent%22%3A%20{_abonentId}%7D",
               $"https://my.mosenergosbyt.ru/accounts/{_accountId}/events/payment-doc");

            var response = await SendAsync(request);
            if (response?.StatusCode != HttpStatusCode.OK)
            {
                _messenger.ShowError(
                    $"МосОблЕирц вернул код ошибки {response?.StatusCode.ToString()}");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BalanceDto>(content);
            if (result == null || !result.Success)
            {
                _messenger.ShowError("Ошибка при попытке получить баланс из МосОблЕирц");
                return null;
            }

            var child = result.Data?.FirstOrDefault();
            if (child == null)
            {
                _messenger.ShowError(
                    "Ошибка при попытке получить баланс из МосОблЕирц. Похоже, структура данных ответа изменилась");
                return null;
            }

            return new Tuple<string, decimal>(
                child.Dt_period_balance.Replace(" 00:00:00", ""),
                child.Sm_insurance - child.Sm_balance);
        }

        public async Task<IList<MeterChildDto>> GetMetersAsync()
        {
            if (!IsAuthorized)
                throw new InvalidOperationException();

            var request = CreateRequest(
               new Uri($"https://my.mosenergosbyt.ru/gate_lkcomu?action=sql&query=smorodinaTransProxy&session={_sessionId}"),
               $"plugin=smorodinaTransProxy&proxyquery=AbonentEquipment&vl_provider=%7B%22id_abonent%22%3A%20{_abonentId}%7D",
               $"https://my.mosenergosbyt.ru/accounts/{_accountId}/events/readings");

            var response = await SendAsync(request);
            if (response?.StatusCode != HttpStatusCode.OK)
            {
                _messenger.ShowError(
                    $"МосОблЕирц вернул код ошибки {response?.StatusCode.ToString()}");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MeterDto>(content);
            if (result?.Data.Count == 0)
            {
                _messenger.ShowError(
                    "Ошибка при попытке получить показания счётчиков из личного кабинета");
                return null;
            }

            return result.Data;
        }

        public async Task<bool> SendMeterAsync(int meterId, int value)
        {
            if (!IsAuthorized)
                throw new InvalidOperationException();

            var date = HttpUtility.UrlEncode(DateTime.Now.ToString("o"));
            var request = CreateRequest(
               new Uri($"https://my.mosenergosbyt.ru/gate_lkcomu?action=sql&query=AbonentSaveIndication&session={_sessionId}"),
               $"dt_indication={date}&id_counter={meterId}&id_counter_zn=1&id_source=15418&plugin=propagateMoeInd&pr_skip_anomaly=0&pr_skip_err=0&vl_indication={value}&vl_provider=%7B%22id_abonent%22%3A%20{_abonentId}%7D",
               $"https://my.mosenergosbyt.ru/accounts/{_accountId}/transfer-indications");

            var response = await SendAsync(request);
            if (response?.StatusCode != HttpStatusCode.OK)
            {
                _messenger.ShowError(
                    $"МосОблЕирц вернул код ошибки {response?.StatusCode.ToString()}");
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthorizationDto>(content);
            if (result?.Success != true ||
                result.Data?.FirstOrDefault()?.Nm_result != "Показания успешно переданы")
            {
                _messenger.ShowError(
                    $"Ошибка во время передачи показаний в МосОблЕирц");
                return false;
            }

            return true;
        }
    }
}
