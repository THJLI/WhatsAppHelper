using Newtonsoft.Json;

namespace WhatsAppHelper.Models.Response
{
    public class WaMsgTplResponse
    {

        [JsonConstructor]
        public WaMsgTplResponse(string messagingProduct, List<Contact> contacts, List<Message> messages)
        {
            MessagingProduct = messagingProduct;
            Contacts = contacts;
            Messages = messages;
        }

        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; }

        [JsonProperty("contacts")]
        public List<Contact> Contacts { get; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; }

    }

    public class Contact
    {
        [JsonProperty("input")]
        public string Input { get; }

        [JsonProperty("wa_id")]
        public string WaId { get; }

        [JsonConstructor]
        public Contact(string input, string waId)
        {
            Input = input;
            WaId = waId;
        }
    }

    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; }

        [JsonConstructor]
        public Message(string id)
        {
            Id = id;
        }
    }
}
