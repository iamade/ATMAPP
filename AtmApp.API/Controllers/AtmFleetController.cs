using System.Threading.Tasks;
using AtmApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtmApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AtmFleetController : ControllerBase
    {
        private readonly IAtmFleetRepository _repo;
        public AtmFleetController(IAtmFleetRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetAtms()
        {
            var atms = await _repo.GetAtms();
            return Ok(atms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAtm(int id)
        {
            var atm = await _repo.GetAtm(id);
            return Ok(atm);
        }
    }
}