using WhatsAppHelper.Models.Response;
using WhatsAppHelper.Models.Send;
using WhatsAppHelper.Models.Token;

namespace WhatsAppHelper.Interface
{
    public interface IHttpWaClient
    {
        void SetToken(WaConfig waConfig);
        Task<WaDebugToken?> GetDebugTokenAsync();
        Task<WaRefreshToken?> RefreshTokenAsync();
        Task<WaMsgTplResponse?> SendOneContactByTplAsync(WaContactTplSend waContactTplSend);
        Task<WaMsgTplResponse?> SendOneContactByTextAsync(WaContactTextSend waContactTextSend);
    }
}
