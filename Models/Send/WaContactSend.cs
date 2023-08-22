using WhatsAppHelper.Models.Send.Base;

namespace WhatsAppHelper.Models.Send
{
    public abstract class WaContactSendBase
    {
        public WaContactSendBase(string to, string? languageCode = null)
        {
            To = to;
            LanguageCode = languageCode;
        }

        public string To { get; }

        public string? LanguageCode { get; }

        internal abstract WaMsgSendBase GetWaMessage();

    }

    public class WaContactTplSend: WaContactSendBase
    {
        public WaContactTplSend(string to, string templateName, string languageCode, params Component[] components)
            : base(to, languageCode)
        {
            TemplateName = templateName;
            Components = components.ToList();
        }

        public string TemplateName { get; }

        internal List<Component> Components { get; }

        internal override WaMsgSendBase GetWaMessage()
        {
            var tpl = new Template(this.TemplateName, new Language(this.LanguageCode!), this.Components);
            return new WaMsgTplSend("whatsapp", "individual", this.To, "template", tpl);
        }
    }

    public class WaContactTextSend: WaContactSendBase
    {
        public WaContactTextSend(string to, bool previewUrl, string body)
            : base(to)
        {
            PreviewUrl = previewUrl;
            Body = body;
        }

        public bool PreviewUrl { get; }
        public string Body { get; }

        internal override WaMsgSendBase GetWaMessage()
        {
            return new WaMsgTextSend("whatsapp", "individual", this.To, "text", new TextContent(this.PreviewUrl, this.Body));
        }
    }

}
