using Newtonsoft.Json;
using WhatsAppHelper.Models.Send.Base;

namespace WhatsAppHelper.Models.Send
{
    internal class WaMsgTplSend: WaMsgSendBase
    {
        [JsonProperty("template")]
        public Template Template { get; }

        [JsonConstructor]
        public WaMsgTplSend(string messagingProduct, string recipientType, string to, string type, Template template)
            :base(messagingProduct, recipientType, to, type)
        {
            Template = template;
        }
    }

    internal class Template
    {
        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("language")]
        public Language Language { get; }

        [JsonProperty("components")]
        public List<Component> Components { get; }

        [JsonConstructor]
        public Template(string name, Language language, List<Component> components)
        {
            Name = name;
            Language = language;
            Components = components;
        }
    }

    internal class Language
    {
        [JsonProperty("code")]
        public string Code { get; }

        [JsonConstructor]
        public Language(string code)
        {
            Code = code;
        }
    }

    public class Component
    {
        [JsonProperty("type")]
        public string Type { get; }

        [JsonProperty("parameters")]
        public Parameter[] Parameters { get; }

        [JsonConstructor]
        public Component(string type, params Parameter[] parameters)
        {
            Type = type;
            Parameters = parameters;
        }
    }

    public class Parameter
    {
        [JsonProperty("type")]
        public string Type { get; }

        [JsonProperty("text")]
        public string Text { get; }

        [JsonConstructor]
        public Parameter(string type, string text)
        {
            Type = type;
            Text = text;
        }
    }

    public class BodyComponent : Component
    {
        public BodyComponent(params Parameter[] parameters)
            : base("body", parameters)
        {
            
        }
    }

    public class ButtonComponent : Component
    {
        [JsonProperty("sub_type")]
        public string SubType { get; } = "url";

        [JsonProperty("index")]
        public string Index { get; } = "0";

        public ButtonComponent(params Parameter[] parameters)
            : base("button", parameters)
        {
            
        }
    }

}
