using bdis_meistrija.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Client.Repository
{
    public interface IDefMsgRepository
    {
        Task<List<DefMsg>> Fetch();
        Task Save(DefMsg defMsg);
    }
}
