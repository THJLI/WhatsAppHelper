using Newtonsoft.Json;
using WhatsAppHelper.Models.Result;

namespace WhatsAppHelper.Models.Hook
{
    internal class WaMsgStatusHook : WaMsgHookBase
    {
        [JsonProperty("changes")]
        [JsonRequired]
        public List<MessageChange> Changes { get; }

        [JsonConstructor]
        public WaMsgStatusHook(string id, List<MessageChange> changes)
        {
            Id = id;
            Changes = changes;
        }

    }

    internal class MessageChange
    {
        [JsonProperty("value")]
        public MessageValue Value { get; }

        [JsonProperty("field")]
        public string Field { get; }

        [JsonConstructor]
        public MessageChange(MessageValue value, string field)
        {
            Value = value;
            Field = field;
        }
    }

    internal class MessageValue
    {
        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; }

        [JsonProperty("metadata")]
        public MessageMetadata Metadata { get; }

        [JsonProperty("statuses")]
        public List<MessageStatus> Statuses { get; }

        [JsonConstructor]
        public MessageValue(string messagingProduct, MessageMetadata metadata, List<MessageStatus> statuses)
        {
            MessagingProduct = messagingProduct;
            Metadata = metadata;
            Statuses = statuses;
        }
    }

    internal class MessageMetadata
    {
        [JsonProperty("display_phone_number")]
        public string DisplayPhoneNumber { get; }

        [JsonProperty("phone_number_id")]
        public string PhoneNumberId { get; }

        [JsonConstructor]
        public MessageMetadata(string displayPhoneNumber, string phoneNumberId)
        {
            DisplayPhoneNumber = displayPhoneNumber;
            PhoneNumberId = phoneNumberId;
        }
    }

    internal class MessageStatus
    {
        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("status")]
        public enuWaStatusChange Status { get; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; }

        [JsonProperty("recipient_id")]
        public string RecipientId { get; }

        [JsonProperty("conversation")]
        public Conversation Conversation { get; }

        [JsonProperty("pricing")]
        public MessagePricing? Pricing { get; }

        [JsonConstructor]
        public MessageStatus(string id, enuWaStatusChange status, long timestamp, string recipientId, Conversation conversation, MessagePricing pricing)
        {
            Id = id;
            Status = status;
            Timestamp = timestamp;
            RecipientId = recipientId;
            Conversation = conversation;
            Pricing = pricing;
        }
    }

    internal class Conversation
    {
        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("expiration_timestamp")]
        public string ExpirationTimestamp { get; }

        [JsonProperty("origin")]
        public Origin Origin { get; }

        [JsonConstructor]
        public Conversation(string id, string expirationTimestamp, Origin origin)
        {
            Id = id;
            ExpirationTimestamp = expirationTimestamp;
            Origin = origin;
        }
    }

    internal class Origin
    {
        [JsonProperty("type")]
        public string Type { get; }

        [JsonConstructor]
        public Origin(string type)
        {
            Type = type;
        }
    }

    internal class MessagePricing
    {
        [JsonProperty("billable")]
        public bool Billable { get; }

        [JsonProperty("pricing_model")]
        public string PricingModel { get; }

        [JsonProperty("category")]
        public string Category { get; }

        [JsonConstructor]
        public MessagePricing(bool billable, string pricingModel, string category)
        {
            Billable = billable;
            PricingModel = pricingModel;
            Category = category;
        }
    }
}
