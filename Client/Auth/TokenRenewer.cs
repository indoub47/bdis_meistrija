using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace bdis_meistrija.Client.Auth
{
    public class TokenRenewer : IDisposable
    {
        Timer timer;
        private readonly ILoginService loginService;

        public TokenRenewer(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        
        public void Initiate()
        {
            timer = new Timer
            {
                Interval = 1000 * 60 * 4
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            loginService.TryRenewToken();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
