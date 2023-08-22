namespace WhatsAppHelper
{
    public class WaConfig
    {
        private string token;
        private bool _isChangeToken;

        public Uri WaApiUrl => new Uri("https://graph.facebook.com/v17.0/");
        public string WaApiVersion => "v17.0";

        public WaConfig(string clientId, string clientSecret, string idPhoneNumber, string idWaBusiness, string token)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            IdPhoneNumber = idPhoneNumber;
            IdWaBusiness = idWaBusiness;
            Token = token;
        }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public string IdPhoneNumber { get; }

        public string IdWaBusiness { get; }

        public string Token
        {
            get => token; 
            set
            {
                token = value; 
                _isChangeToken = !string.IsNullOrEmpty(token) && token != value;
            }
        }

        public bool IsChangeToken { get => _isChangeToken; }
    }
}
