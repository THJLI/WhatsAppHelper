using Newtonsoft.Json;

namespace WhatsAppHelper.Models.Hook
{
    internal class WaMsgBtnHook : WaMsgHookBase
    {
        [JsonProperty("context")]
        public Context Context { get; }

        [JsonProperty("from")]
        public string From { get; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; }

        [JsonProperty("type")]
        public string Type { get; }

        [JsonProperty("button")]
        [JsonRequired]
        public Button Button { get; }

        [JsonConstructor]
        public WaMsgBtnHook(Context context, string from, string id, long timestamp, string type, Button button)
        {
            Context = context;
            From = from;
            Id = id;
            Timestamp = timestamp;
            Type = type;
            Button = button;
        }

        public WaMsgBtnHook(string json) => JsonConvert.PopulateObject(json, this);
    }

    internal class Context
    {
        [JsonProperty("from")]
        public string From { get; }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonConstructor]
        public Context(string from, string id)
        {
            From = from;
            Id = id;
        }
    }

    internal class Button
    {
        [JsonProperty("payload")]
        public string Payload { get; }

        [JsonProperty("text")]
        public string Text { get; }

        [JsonConstructor]
        public Button(string payload, string text)
        {
            Payload = payload;
            Text = text;
        }
    }
}
