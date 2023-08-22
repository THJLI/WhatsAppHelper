using Newtonsoft.Json;

namespace WhatsAppHelper.Models.Response
{
    internal class WaPhoneNumberResponse
    {
        [JsonConstructor]
        public WaPhoneNumberResponse(string verifiedName, string codeVerificationStatus, string displayPhoneNumber, string qualityRating, string id)
        {
            VerifiedName = verifiedName;
            CodeVerificationStatus = codeVerificationStatus;
            DisplayPhoneNumber = displayPhoneNumber;
            QualityRating = qualityRating;
            Id = id;
        }

        [JsonProperty("verified_name")]
        public string VerifiedName { get; }

        [JsonProperty("code_verification_status")]
        public string CodeVerificationStatus { get; }

        [JsonProperty("display_phone_number")]
        public string DisplayPhoneNumber { get; }

        [JsonProperty("quality_rating")]
        public string QualityRating { get; }

        [JsonProperty("id")]
        public string Id { get; }

    }
}
