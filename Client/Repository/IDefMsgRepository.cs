using bdis_meistrija.Shared.DTOs;
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
        Task<PaginatedResponse<List<DefMsg>>> Fetch(PaginationDTO paginationDTO);
        Task Save(DefMsg defMsg);
    }
}
