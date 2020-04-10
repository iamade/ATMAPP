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
    [Authorize]
    [Route("api/[controller]")]
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
            var faultLogToReturn = _mapper.Map<IEnumerable<FaultLogForListDto>>(faultLogs);
            return Ok(faultLogs);
        }

        [HttpGet("{id}", Name = "GetFaultLog")]
        public async Task<IActionResult> GetFaultLog(int id)
        {
            var faultLog = await _repo.GetFaultLog(id);

            var faultLogToReturn = _mapper.Map<FaultLogForListDto>(faultLog);

            return Ok(faultLogToReturn);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(FaultLogForCreateDto faultLogForCreateDto) {

            var atmFaultToCreate = new FaultLog
            {
                TerminalId = faultLogForCreateDto.TerminalId,
                TerminalName = faultLogForCreateDto.TerminalName,
                AtmFleetId = faultLogForCreateDto.AtmFleetId,
                Vendor = faultLogForCreateDto.Vendor,
                Brand = faultLogForCreateDto.Brand,
                NatureOfFault = faultLogForCreateDto.NatureOfFault,
                CustodianName = faultLogForCreateDto.CustodianName,
                CustodianNumber = faultLogForCreateDto.CustodianNumber,
                DateLogged = faultLogForCreateDto.DateLogged,
                DateResolved = faultLogForCreateDto.DateResolved,
                DefaultDays = (faultLogForCreateDto.DateResolved - faultLogForCreateDto.DateLogged)


            };

            _repo.Add(atmFaultToCreate);
            if(await _repo.SaveAll()) {
                var atmFaultToReturn = _mapper.Map<FaultLogForListDto>(atmFaultToCreate);
                return CreatedAtRoute("GetFaultLog", new FaultLogForListDto{Id=atmFaultToCreate.Id}, atmFaultToReturn);
            }

            return StatusCode(201);
        }

        [HttpPut("{id}", Name = "UpdateFault")]
        public async Task<IActionResult> Update(int id, FaultLogForUpdateDto faultLogForUpdateDto)
        {
            var faultLogFromRepo = await _repo.GetFaultLog(id);

            _mapper.Map(faultLogForUpdateDto, faultLogFromRepo);

            if(await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating Fault Log {id} failed on save");
        }


        [HttpDelete("{id}", Name = "DeleteFault")]
        public async Task<IActionResult> Delete(int id) 
        {
            var faultLogFromRepo = await _repo.GetFaultLog(id);

            _repo.Delete(faultLogFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Error deleting the Fault Log");
        }

    }
}