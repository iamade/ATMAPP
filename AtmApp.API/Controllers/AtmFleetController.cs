using System.Collections.Generic;
using System.Threading.Tasks;
using AtmApp.API.Data;
using AtmApp.API.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public AtmFleetController(IAtmFleetRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [Route("GetAtms")]
        [HttpGet]
        public async Task<IActionResult> GetAtms()
        {
            var atms = await _repo.GetAtms();
            var atmToReturn = _mapper.Map<IEnumerable<AtmFleetDto>>(atms);
            return Ok(atmToReturn);
        }

        [Route("GetAtm")]
        [HttpGet]
        public async Task<IActionResult> GetAtm(int id)
        {
            var atm = await _repo.GetAtm(id);
            var atmToReturn = _mapper.Map<AtmFleetDto>(atm);
            return Ok(atmToReturn);
        }
    }
}