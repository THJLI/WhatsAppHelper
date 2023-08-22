using Newtonsoft.Json;

namespace WhatsAppHelper.Models.Hook
{
    internal class WaMsgHook : WaMsgHookBase
    {
        [JsonProperty("from")]
        public string From { get; }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; }

        [JsonProperty("text")]
        public TextContent TextContent { get; }

        [JsonProperty("type")]
        [JsonRequired]
        public string Type { get; }

        [JsonConstructor]
        public WaMsgHook(string from, string id, long timestamp, TextContent textContent, string type)
        {
            From = from;
            Id = id;
            Timestamp = timestamp;
            TextContent = textContent;
            Type = type;
        }
    }

    internal class TextContent
    {
        [JsonProperty("body")]
        public string Body { get; }

        [JsonConstructor]
        public TextContent(string body)
        {
            Body = body;
        }
    }
}
