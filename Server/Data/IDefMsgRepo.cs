using bdis_meistrija.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Server.Data
{
    public interface IDefMsgRepo
    {
        //IEnumerable<DefMsg> GetMeistrijaDefMsgs();
        Task<IEnumerable<DefWithMsg>> GetMeistrijaDefMsgsAsync();
        Task<ActionResult<DefRemovalMsg>> SaveDefRemovalMsgAsync(DefRemovalMsg defRemovalMsg);
    }
}
