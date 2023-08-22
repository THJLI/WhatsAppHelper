using Newtonsoft.Json;

namespace WhatsAppHelper.Models.Send.Base
{
    internal abstract class WaMsgSendBase
    {
        public WaMsgSendBase(string messagingProduct, string recipientType, string to, string type)
        {
            MessagingProduct = messagingProduct;
            RecipientType = recipientType;
            To = to;
            Type = type;
        }

        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; }

        [JsonProperty("recipient_type")]
        public string RecipientType { get; }

        [JsonProperty("to")]
        public string To { get; }

        [JsonProperty("type")]
        public string Type { get; }
    }
}
