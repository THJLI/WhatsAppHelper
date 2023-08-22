using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using WhatsAppHelper.Interface;
using WhatsAppHelper.Models.Response;
using WhatsAppHelper.Models.Send;
using WhatsAppHelper.Models.Token;

namespace WhatsAppHelper.Clients
{
    internal class HttpWaClient: IHttpWaClient
    {
        private readonly HttpClient _httpClient;
        private WaConfig _waConfig = null!;

        public HttpWaClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        private void CheckWaConfig()
        {
            if (this._waConfig is null)
                throw new ArgumentNullException("Invalid WaConfig, 'SetToken' is required!");
        }

        private async Task CheckTokenValidity()
        {
            var respToken = await GetDebugTokenAsync();
            if (respToken is null || !respToken.IsValid)
            {
                var refreshToken = await RefreshTokenAsync();
                this._waConfig.Token = refreshToken!.AccessToken;
            }
        }

        private void AddBearerAuthenticate()
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _waConfig.Token);
        }

        public void SetToken(WaConfig waConfig)
        {
            this._waConfig = waConfig;
            if (this._httpClient.BaseAddress is null) this._httpClient.BaseAddress = waConfig.WaApiUrl;
        }

        public async Task<WaDebugToken?> GetDebugTokenAsync()
        {
            CheckWaConfig();
            var endpoint = $"/debug_token?input_token={_waConfig?.Token}&access_token={_waConfig?.Token}";
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var respJson = await response.Content.ReadAsStringAsync();
                var objData = JsonConvert.DeserializeObject<JObject>(respJson)["data"];
                var oJson = objData.ToObject<WaDebugToken>();
                return oJson;
            }

            return null;
        }

        public async Task<WaRefreshToken?> RefreshTokenAsync()
        {
            CheckWaConfig();

            var endpoint = $"/oauth/access_token?grant_type=fb_exchange_token&client_id={_waConfig?.ClientId}&client_secret={_waConfig?.ClientSecret}&set_token_expires_in_60_days=true&fb_exchange_token={_waConfig.Token}";
            var response = await _httpClient.PostAsync(endpoint, null);

            if (response.IsSuccessStatusCode)
            {
                var respJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WaRefreshToken>(respJson);
            }

            return null;
        }

        private HttpContent GetJsonContent(object message)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.None
            };
            var obj = JsonConvert.SerializeObject(message, settings);
            return new StringContent(obj, Encoding.UTF8, "application/json");
        }

        private async Task<WaMsgTplResponse?> SendOneContactByBaseAsync(WaContactSendBase waContactSendBase)
        {
            CheckWaConfig();
            await CheckTokenValidity();
            AddBearerAuthenticate();

            var endpoint = $"/{_waConfig?.IdPhoneNumber}/messages";
            var waMessage = waContactSendBase.GetWaMessage();
            var content = GetJsonContent(waMessage);

            var response = await _httpClient.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<WaMsgTplResponse>();
            else
                throw new InvalidDataException(await response.Content.ReadAsStringAsync());

        }

        public async Task<WaMsgTplResponse?> SendOneContactByTplAsync(WaContactTplSend waContactTplSend)
        {
            return await SendOneContactByBaseAsync(waContactTplSend);
        }

        public async Task<WaMsgTplResponse?> SendOneContactByTextAsync(WaContactTextSend waContactTextSend)
        {
            return await SendOneContactByBaseAsync(waContactTextSend);
        }

        
    }
}
