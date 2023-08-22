using Newtonsoft.Json;
using WhatsAppHelper.Models.Send.Base;

namespace WhatsAppHelper.Models.Send
{
    internal class WaMsgTextSend: WaMsgSendBase
    { 
        [JsonProperty("text")]
        public TextContent TextContent { get; }

        [JsonConstructor]
        internal WaMsgTextSend(string messagingProduct, string recipientType, string to, string type, TextContent textContent)
            :base(messagingProduct, recipientType, to, type)
        {
            TextContent = textContent;
        }
    }

    internal class TextContent
    {
        [JsonProperty("preview_url")]
        public bool PreviewUrl { get; }

        [JsonProperty("body")]
        public string Body { get; }

        [JsonConstructor]
        public TextContent(bool previewUrl, string body)
        {
            PreviewUrl = previewUrl;
            Body = body;
        }
    }

}
