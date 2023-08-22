using Newtonsoft.Json;
using System.Net.Http.Json;

namespace WhatsAppHelper.Models.Token
{
    public class WaRefreshToken
    {
        [JsonConstructor]
        public WaRefreshToken(string accessToken, string tokenType, int expiresIn)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; }

        [JsonProperty("token_type")]
        public string TokenType { get; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; }

    }
}
