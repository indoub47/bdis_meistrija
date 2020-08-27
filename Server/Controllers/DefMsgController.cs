using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bdis_meistrija.Server.Data;
using bdis_meistrija.Shared.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using bdis_meistrija.Server.Helpers;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<DefRemovalMsg>> Post(DefRemovalMsg defRemovalMsg)
        {
            await _repo.SaveDefRemovalMsgAsync(defRemovalMsg);
            return Ok(defRemovalMsg);
        }


        [HttpGet] 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<DefWithMsg>>> Get([FromQuery]PaginationDTO paginationDTO)
        {
            
            var defMsgs = await _repo.GetMeistrijaDefMsgsAsync();
            var queryable = defMsgs.AsQueryable();
            HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return queryable.Paginate(paginationDTO).ToList();
        }
    }
}
