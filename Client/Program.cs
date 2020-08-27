using bdis_meistrija.Client.Auth;
using bdis_meistrija.Client.Data;
using bdis_meistrija.Client.Helpers;
using bdis_meistrija.Client.Repository;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace bdis_meistrija.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<bdis_meistrija.Client.App>("app");

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredModal();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IDefMsgRepository, DefMsgRepository>();
            services.AddAuthorizationCore();
            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<JWTAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());
            services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDisplayMessage, DisplayMessage>();
            services.AddScoped<TokenRenewer>();
        }
    }
}
