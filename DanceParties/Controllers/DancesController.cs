using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.Services;

namespace DanceParties.Controllers
{
    [Route("api/dances")]
    [ApiController]
    public class DanceController : ControllerBase
    {
        private readonly IDanceService _danceService;
        private readonly IMapper _mapper;

        public DanceController(IDanceService danceService, IMapper mapper)
        {
            _danceService = danceService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<Dance> Get(int id)
        {
            var model = await _danceService.GetDance(id);
            var dto = _mapper.Map<Dance>(model);
            return dto;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Dance city)
        {
            return new StatusCodeResult(501);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new StatusCodeResult(501);
        }
    }
}