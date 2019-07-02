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
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<City> Get(int id)
        {
            var model = await _cityService.GetCity(id);
            var dto = _mapper.Map<City>(model);
            return dto;
        }

        [HttpPost]
        public IActionResult Post([FromBody]City city)
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