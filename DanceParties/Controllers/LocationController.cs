using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Dto = DanceParties.Interfaces.DTO.Location;
using BusinessModel = DanceParties.Interfaces.BusinessModels.Location;
using CityBusinessModel = DanceParties.Interfaces.BusinessModels.City;
using DanceParties.Interfaces.Services;

namespace DanceParties.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : AbstractController
    {
        private readonly IService<BusinessModel> _locationService;
        private readonly IService<CityBusinessModel> _cityService;
        private readonly IMapper _mapper;

        public LocationController(IService<BusinessModel> locationService, IService<CityBusinessModel> cityService, IMapper mapper)
        {
            _locationService = locationService;
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<Dto> Get(int id)
        {
            var model = await _locationService.Get(id);
            var dto = await ToDto(model);
            return dto;
        }

        [HttpGet]
        public async Task<IEnumerable<Dto>> GetLocations()
        {
            var models = await _locationService.GetAll();
            var dtos = await Task.WhenAll(models.Select(m => ToDto(m)));
            return dtos;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Dto city)
        {
            return NotImplemented();
        }
       
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Dto value)
        {
            return NotImplemented();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NotImplemented();
        }

        private async Task<Dto> ToDto(BusinessModel model)
        {
            var dto = _mapper.Map<BusinessModel, Dto>(model);
            var cityModel = await _cityService.Get(model.CityId);
            return _mapper.Map<CityBusinessModel, Dto>(cityModel, dto);
        }
    }  
}