using Newtonsoft.Json;

namespace WhatsAppHelper.Models.Token
{
    [JsonObject("data")]
    public class WaDebugToken
    {
        [JsonConstructor]
        public WaDebugToken(string appId, string type, string application, long dataAccessExpiresAt, 
                                long expiresAt, bool isValid, long issuedAt, List<string> scopes, 
                                    List<GranularScope> granularScopes, string userId)
        {
            AppId = appId;
            Type = type;
            Application = application;
            DataAccessExpiresAt = dataAccessExpiresAt;
            ExpiresAt = expiresAt;
            IsValid = isValid;
            IssuedAt = issuedAt;
            Scopes = scopes;
            GranularScopes = granularScopes;
            UserId = userId;
        }

        [JsonProperty("app_id")]
        public string AppId { get; }

        [JsonProperty("type")]
        public string Type { get; }

        [JsonProperty("application")]
        public string Application { get; }

        [JsonProperty("data_access_expires_at")]
        public long DataAccessExpiresAt { get; }

        [JsonProperty("expires_at")]
        public long ExpiresAt { get; }

        [JsonProperty("is_valid")]
        public bool IsValid { get; }

        [JsonProperty("issued_at")]
        public long IssuedAt { get; }

        [JsonProperty("scopes")]
        public List<string> Scopes { get; }

        [JsonProperty("granular_scopes")]
        public List<GranularScope> GranularScopes { get; }

        [JsonProperty("user_id")]
        public string UserId { get; }

    }

    public class GranularScope
    {
        [JsonProperty("scope")]
        public string Scope { get; }

        [JsonProperty("target_ids")]
        public List<string> TargetIds { get; }
        
    }
}
