using System.Threading.Tasks;
using AtmApp.API.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtmApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FaultLogsController : ControllerBase
    {
        private readonly IFaultLogRepository _repo;
        private readonly IMapper _mapper;
        public FaultLogsController(IFaultLogRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetFaultLogs()
        {
            var faultLogs = await _repo.GetFaultLogs();
            return Ok(faultLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaultLog(int id)
        {
            var faultLog = await _repo.GetFaultLog(id);

            return Ok(faultLog);
        }
    }
}