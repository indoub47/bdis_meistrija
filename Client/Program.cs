using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.Modal;
using bdis_meistrija.Client.Helpers;
using bdis_meistrija.Client.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using bdis_meistrija.Client.Auth;

namespace bdis_meistrija.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddBlazoredModal();
            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<IDefMsgRepository, DefMsgRepository>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, DummyAuthenticationStateProvider>();

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
