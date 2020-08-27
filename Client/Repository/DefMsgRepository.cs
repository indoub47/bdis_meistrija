using bdis_meistrija.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<PaginatedResponse<List<DefWithMsg>>> Fetch(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<DefWithMsg>>(url, paginationDTO);
        }

        public async Task<List<DefWithMsg>> Fetch()
        {
            await Task.Delay(3000); // for testing
            var response = await httpService.Get<List<DefWithMsg>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            } 
            else
            {
                return response.Response;
            }
        }

        public async Task Save(DefWithMsg defMsg)
        {
            await Task.Delay(3000); // for testing
            DefRemovalMsg defRemovalMsg = new DefRemovalMsg() { DefId = defMsg.Id, ActionDate = defMsg.ActionDate, ActionId = defMsg.ActionId };
            var response = await httpService.Post(url, defRemovalMsg);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
