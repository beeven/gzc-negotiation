using System;
using Microsoft.Extensions.DependencyInjection;

namespace GZCNegotiation.Services.EtgInfoLib
{
    public static class EtgInfoLibExtensions
    {
        public static IServiceCollection AddEtgInfo(this IServiceCollection services)
        {
            return services.AddEtgInfo(options => { });
        }
        public static IServiceCollection AddEtgInfo(this IServiceCollection services, Action<EtgOptions> optionsBuilder)
        {
            var options = new EtgOptions();
            optionsBuilder.Invoke(options);


            services.AddScoped<IRemoteInfoFetcher>(provider =>
            {
                return new RemoteInfoFetcher(options.EtgServiceUrl, options.AppId);
            });
            services.AddScoped<ISessionInfoHandler, SessionInfoHandler>();

            services.AddScoped<IEtgInfoService>(provider =>
            {
                var remoteInfoFetcher = provider.GetService<IRemoteInfoFetcher>();
                var sessionInfoHandler = provider.GetService<ISessionInfoHandler>();
                var service = new EtgInfoServiceImpl(remoteInfoFetcher, sessionInfoHandler);
                return service;
            });

            return services;
        }
    }
}