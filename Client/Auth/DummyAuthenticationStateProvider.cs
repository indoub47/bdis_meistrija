using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;

namespace bdis_meistrija.Client.Auth
{
    public class DummyAuthenticationStateProvider: AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(1000);
            ClaimsIdentity anonymous = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("meistrijaid", "406"),
                new Claim(ClaimTypes.Name, "Kazys Vaičius"),
                new Claim(ClaimTypes.Role, "MeistrijosAtsakingas")
            }, "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
        
        
    }
}
