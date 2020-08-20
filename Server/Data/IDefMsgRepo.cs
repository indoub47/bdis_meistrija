using bdis_meistrija.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Server.Data
{
    public interface IDefMsgRepo
    {
        IEnumerable<DefMsg> GetMeistrijaDefMsgs();
        Task<ActionResult<Message>> SaveMeistrijaMessageAsync(Message message);
    }
}
