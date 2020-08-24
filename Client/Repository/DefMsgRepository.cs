using bdis_meistrija.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bdis_meistrija.Shared.Entities;
using System.Text.Json.Serialization;
using bdis_meistrija.Shared.DTOs;

namespace bdis_meistrija.Client.Repository
{
    public class DefMsgRepository: IDefMsgRepository
    {
        private readonly IHttpService httpService;
        private readonly string url = "defmsg";
        public DefMsgRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<PaginatedResponse<List<DefMsg>>> Fetch(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<DefMsg>>(url, paginationDTO);
        }

        public async Task<List<DefMsg>> Fetch()
        {
            await Task.Delay(3000); // for testing
            var response = await httpService.Get<List<DefMsg>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            } 
            else
            {
                return response.Response;
            }
        }

        public async Task Save(DefMsg defMsg)
        {
            await Task.Delay(3000); // for testing
            Message message = new Message(defMsg.Id, defMsg.ActionDate, defMsg.ActionId);
            var response = await httpService.Post(url, message);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
