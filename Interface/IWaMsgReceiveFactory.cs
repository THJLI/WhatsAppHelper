using WhatsAppHelper.Models.Result;

namespace WhatsAppHelper.Interface
{
    public interface IWaMsgReceiveFactory
    {

        IEnumerable<WaResultBase>? GetResult(string Json);

    }
}
