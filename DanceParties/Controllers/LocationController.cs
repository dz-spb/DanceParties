using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.Services;
using System.Net;

namespace DanceParties.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : AbstractController
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
            return NotImplemented();
        }
       
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Location value)
        {
            return NotImplemented();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NotImplemented();
        }     
    }
}