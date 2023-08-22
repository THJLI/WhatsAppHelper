using Microsoft.Extensions.DependencyInjection;
using WhatsAppHelper.Clients;
using WhatsAppHelper.Factory;
using WhatsAppHelper.Interface;

namespace WhatsAppHelper
{
    public static class Dependecy
    {

        public static void AddWaHelper(this IServiceCollection services)
        {
            services.AddHttpClient<IHttpWaClient, HttpWaClient>();
            services.AddTransient<IWaMsgReceiveFactory, WaMsgReceiveFactory>();
        }

    }
}
