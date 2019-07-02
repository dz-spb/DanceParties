using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.Services;

namespace LocationParties.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationService danceService, IMapper mapper)
        {
            _locationService = danceService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<Location> Get(int id)
        {
            var model = await _locationService.GetLocation(id);
            var dto = _mapper.Map<Location>(model);
            return dto;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Location city)
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