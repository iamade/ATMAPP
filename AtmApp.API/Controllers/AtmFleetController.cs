using System;
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
    
    [Route("api/[controller]/[action]")]
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

        
        [HttpGet("{id}", Name = "GetAtm")]
        public async Task<IActionResult> GetAtm(int id)
        {
            var atm = await _repo.GetAtm(id);
            var atmToReturn = _mapper.Map<AtmFleetDto>(atm);
            return Ok(atmToReturn);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AtmForCreateDto atmForCreateDto) {
            //validate request

            atmForCreateDto.TerminalId = atmForCreateDto.TerminalId;
            atmForCreateDto.Ip = atmForCreateDto.Ip;

            if(await _repo.AtmExists(atmForCreateDto.TerminalId))
                return BadRequest("Terminal Id already exists");

            if(await _repo.AtmExists(atmForCreateDto.Ip))
                return BadRequest("Ip Address already exists");

            var atmToCreate = new AtmFleet 
            {
                TerminalId = atmForCreateDto.TerminalId,
                TerminalName = atmForCreateDto.TerminalName,
                Ip = atmForCreateDto.Ip,
                Gateway = atmForCreateDto.Gateway, 
                Brand = atmForCreateDto.Brand, 
                Vendor = atmForCreateDto.Vendor, 
                Region = atmForCreateDto.Region, 
                Location = atmForCreateDto.Location, 
                BranchCode = atmForCreateDto.BranchCode,
                RegionalPersonnel = atmForCreateDto.RegionalPersonnel,
                CustodianName = atmForCreateDto.CustodianName,
                CustodianNumber = atmForCreateDto.CustodianNumber

                
            };

            _repo.Add(atmToCreate);
            if(await _repo.SaveAll()) {
                var atmToReturn = _mapper.Map<AtmFleetDto>(atmToCreate);
                return CreatedAtRoute("GetAtm", new AtmFleetDto{Id=atmToCreate.Id}, atmToReturn);
            }

            return StatusCode(201);
            
        
        }

        [HttpPut("{id}", Name = "UpdateAtm")]
        public async Task<IActionResult> Update(int id, AtmForUpdateDto atmForUpdateDto)
        {
            var atmFromRepo = await _repo.GetAtm(id);

            _mapper.Map(atmForUpdateDto, atmFromRepo);

            if(await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating ATM {id} failed on save");
        }


        [HttpDelete("{id}", Name = "DeleteAtm")]
        public async Task<IActionResult> Delete(int id) 
        {
            var atmFromRepo = await _repo.GetAtm(id);

            _repo.Delete(atmFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Error deleting the Atm");
        }


    }
}