using Newtonsoft.Json;

namespace WhatsAppHelper.Models.Hook
{
    internal abstract class WaMsgHookBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

    }
}
