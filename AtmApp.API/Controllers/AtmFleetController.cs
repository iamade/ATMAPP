using System.Collections.Generic;
using System.Threading.Tasks;
using AtmApp.API.Data;
using AtmApp.API.Dtos;
using AtmApp.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtmApp.API.Controllers
{
    
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
       
        [HttpGet]
        public async Task<IActionResult> GetAtms()
        {
            var atms = await _repo.GetAtms();
            var atmsToReturn = _mapper.Map<IEnumerable<AtmFleetDto>>(atms);
            return Ok(atms);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAtm(int id)
        {
            var atm = await _repo.GetAtm(id);
            var atmToReturn = _mapper.Map<AtmFleetDto>(atm);
            return Ok(atmToReturn);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAtm(AtmForCreateDto atmForCreateDto) {
            //validate request

            atmForCreateDto.TerminalId = atmForCreateDto.TerminalId;

            if(await _repo.AtmExists(atmForCreateDto.TerminalId))
                return BadRequest("Terminal Id already exists");

            var atmToCreate = new AtmFleet 
            {
                TerminalId = atmForCreateDto.TerminalId
            };

            _repo.Add(atmToCreate);
            if(await _repo.SaveAll()) {
                var atmToReturn = _mapper.Map<AtmFleetDto>(atmToCreate);
                return CreatedAtRoute("GetAtm", new AtmFleetDto{Id=atmToCreate.Id}, atmToReturn);
            }

            return StatusCode(201);
            
        
        }


    }
}