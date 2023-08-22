using Newtonsoft.Json;
using WhatsAppHelper.Interface;
using WhatsAppHelper.Models.Hook;
using WhatsAppHelper.Models.Result;

namespace WhatsAppHelper.Factory
{
    internal class WaMsgReceiveFactory : IWaMsgReceiveFactory
    {
        public IEnumerable<WaResultBase>? GetResult(string Json)
        {
            var hook = GetHookObjByJson(Json);
            if (hook != null)
            {
                if (hook is IEnumerable<WaMsgStatusHook>)
                    return hook.Select(h => new WaStatusResult((WaMsgStatusHook)h));
                else if (hook is IEnumerable<WaMsgHook>)
                    return hook.Select(h => new WaQuestionResult((WaMsgHook)h));
                else if (hook is IEnumerable<WaMsgBtnHook>)
                    return hook.Select(h => new WaAnswerResult((WaMsgBtnHook)h));
            }

            return null;
        }

        private IEnumerable<WaMsgHookBase>? GetHookObjByJson(string Json)
        {
            if (!string.IsNullOrEmpty(Json))
            {
                if (Json.Contains("\"changes\""))
                    return JsonConvert.DeserializeObject<List<WaMsgStatusHook>>(Json);
                else if (Json.Contains("\"type\": \"text\""))
                    return JsonConvert.DeserializeObject<List<WaMsgHook>>(Json);
                else if (Json.Contains("\"type\": \"button\""))
                    return JsonConvert.DeserializeObject<List<WaMsgBtnHook>>(Json);
            }
            return null;
        }



    }
}
