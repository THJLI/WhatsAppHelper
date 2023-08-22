using Newtonsoft.Json;
using WhatsAppHelper.Models.Hook;

namespace WhatsAppHelper.Models.Result
{
    public class WaResultBase
    {
        internal WaResultBase(WaMsgHookBase waMsgHookBase)
        {
            Id = waMsgHookBase.Id;
        }

        public string Id { get; protected set; }
    }

    public class WaStatusResult : WaResultBase
    {
        private readonly WaMsgStatusHook _hook;
        public string IdWaBusiness { get; set; }
        public IEnumerable<WaStatusChanges> Changes { get; private set; }

        internal WaStatusResult(WaMsgStatusHook hook)
            : base(hook)
        {
            this._hook = hook;
            this.IdWaBusiness = hook.Id;
            
            PopulateChanges();
        }

        private void PopulateChanges()
        {
            Changes = _hook.Changes.Select(c => 
                                    new WaStatusChanges(c.Value.Metadata.PhoneNumberId, 
                                                            c.Value.Metadata.DisplayPhoneNumber,
                                                                c.Value.Statuses)).ToList();
        }
    }

    public class WaStatusChanges
    {
        internal WaStatusChanges(string idWaPhone, string toPhoneNumber, IEnumerable<MessageStatus> statuses)
        {
            IdWaPhone = idWaPhone;
            ToPhoneNumber = toPhoneNumber;
            Itens = statuses.Select(s => new WaStatusChangeItens(s)).ToList();
        }

        public string IdWaPhone { get; }
        public string ToPhoneNumber { get; }

        public IEnumerable<WaStatusChangeItens> Itens { get; set; }
    }

    public class WaStatusChangeItens
    {
        internal WaStatusChangeItens(MessageStatus statuses)
        {
            IdMessage = statuses.Id;
            Status = statuses.Status;
            CurrentDate = DateTimeOffset.FromUnixTimeMilliseconds(statuses.Timestamp).DateTime;
            FromPhoneNumber = statuses.RecipientId;

            if (statuses.Pricing is not null)
            {
                Billable = statuses.Pricing.Billable;
                PricingModel = statuses.Pricing.PricingModel;
                Category = statuses.Pricing.Category;
            }
        }

        public string IdMessage { get; }
        public enuWaStatusChange Status { get; set; }
        public string FromPhoneNumber { get; set; }
        public bool Billable { get; }
        public string PricingModel { get; set; }
        public string Category { get; set; }
        public DateTime CurrentDate { get; set; }
    }

    public enum enuWaStatusChange
    {
        sent = 1,
        delivered = 2,
        read = 3,
        failed = 4
    }



    public class WaQuestionResult : WaResultBase
    {
        internal WaQuestionResult(WaMsgHook hook)
            : base(hook)
        {
            FromPhoneNumber = hook.From;
            CurrentDate = DateTimeOffset.FromUnixTimeMilliseconds(hook.Timestamp).DateTime;
        }

        public string FromPhoneNumber { get; }
        public DateTime CurrentDate { get; }
        public string TextBody { get; }

    }

    public class WaAnswerResult : WaResultBase
    {
        public string IdMsgResponse { get; }
        public string FromPhoneNumber { get; }
        public string ToPhoneNumber { get; }
        public DateTime CurrentDate { get; }
        public string Response { get; }
        internal WaAnswerResult(WaMsgBtnHook hook)
            : base(hook)
        {
            IdMsgResponse = hook.Context.Id;
            ToPhoneNumber = hook.Context.From;
            FromPhoneNumber = hook.From;
            CurrentDate = DateTimeOffset.FromUnixTimeMilliseconds(hook.Timestamp).DateTime;
            Response = hook.Button.Text;
        }
    }

}
