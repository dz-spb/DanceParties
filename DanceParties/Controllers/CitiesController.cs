using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanceParties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{id}")]
        public async Task<City> Get(int id)
        {
            return await _cityService.GetCity(id);
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