using bdis_meistrija.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Client.Repository
{
    public interface IAccountsRepository
    {
        Task<UserToken> Register(UserInfo userInfo);
        Task<UserToken> Login(UserInfo userInfo);
        Task<UserToken> RenewToken();
    }
}
