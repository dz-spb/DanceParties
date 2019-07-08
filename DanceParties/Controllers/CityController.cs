using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.Services;
using BusinessModel = DanceParties.Interfaces.BusinessModels.City;

namespace DanceParties.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : AbstractController
    {
        private readonly IService<BusinessModel> _cityService;
        private readonly IMapper _mapper;

        public CityController(IService<BusinessModel> cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<City> Get(int id)
        {
            var model = await _cityService.Get(id);
            var dto = _mapper.Map<City>(model);
            return dto;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> GetCities()
        {
            var models = await _cityService.GetAll();
            var dtos = models.Select(_mapper.Map<City>);
            return dtos;
        }

        [HttpPost]
        public IActionResult Post([FromBody]City city)
        {
            return NotImplemented();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]City value)
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