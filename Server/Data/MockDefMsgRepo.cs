using bdis_meistrija.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Server.Data
{
    public class MockDefMsgRepo : IDefMsgRepo
    {
        public IEnumerable<DefMsg> GetMeistrijaDefMsgs()
        {
            var defMsgs = new List<DefMsg>()
            {
                new DefMsg(100125, 1, "1", 346, 5, 26, "0", "PC.17.2", "D3", "R65", new DateTime(2020, 1, 3), new DateTime(2020, 6, 20), null, ""),
                new DefMsg(19875, 17, "1", 108, 3, 22, "9", "53.1", "ID", "R65", new DateTime(2020, 2, 18), null, null, ""),
                new DefMsg(412, 23, "2", 42, 4, 50, "0", "31.2", "DP", "UIC60", new DateTime(2020, 7, 28), new DateTime(2020, 8, 28), null, ""),
                new DefMsg(1, 1, "1", 279, 2, 17, "9", "27.3", "D2", "R65", new DateTime(2019, 7, 28), null, null, ""),
                new DefMsg(589, 1, "8", 289, 1, 1, "9", "PC.17.2", "D3", "R50", new DateTime(2020, 4, 15), null, null, ""),
            };
            return defMsgs;
        }

        public async Task<ActionResult<Message>> SaveMeistrijaMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
