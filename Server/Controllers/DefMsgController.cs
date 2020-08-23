using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bdis_meistrija.Server.Data;
using bdis_meistrija.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bdis_meistrija.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DefMsgController : ControllerBase
    {
        private readonly IDefMsgRepo _repo;

        public DefMsgController(IDefMsgRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message message)
        {
            await _repo.SaveMeistrijaMessageAsync(message);
            return Ok(message);
        }


        [HttpGet] 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public List<DefMsg> Get()
        {
            var defMsgs = _repo.GetMeistrijaDefMsgs();
            return defMsgs.ToList();
        }
    }
}
