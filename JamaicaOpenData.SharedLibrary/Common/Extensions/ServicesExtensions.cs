using JamaicaOpenData.SharedLibrary.Common.Constants;
using JamaicaOpenData.SharedLibrary.Common.Helpers;
using JamaicaOpenData.SharedLibrary.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;

namespace JamaicaOpenData.SharedLibrary.Common.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterJamaicaOpenDataServices(
            this IServiceCollection services, WebProxy? proxy = null)
        {
            var builder = services.AddHttpClient(AppKeys.JamaicaOpenDataHttpClientName, httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://data.gov.jm/api/action/datastore/"); ;
            });

            if(proxy != null)
            {
                builder.ConfigureHttpMessageHandlerBuilder(builder => {
                    builder.PrimaryHandler = new HttpClientHandler
                    {
                        Proxy = proxy
                    };
                });
            }

            services.AddTransient<IJamaicaOpenDataService, JamaicaOpenDataService>();
            MappingHelper.ConfigureHttpJsonSerializerSettings();
            return services;
        }
    }
}
