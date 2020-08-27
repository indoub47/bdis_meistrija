using bdis_meistrija.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Client.Repository
{
    public interface IDefMsgRepository
    {
        Task<List<DefWithMsg>> Fetch();
        Task<PaginatedResponse<List<DefWithMsg>>> Fetch(PaginationDTO paginationDTO);
        Task Save(DefWithMsg defMsg);
    }
}
