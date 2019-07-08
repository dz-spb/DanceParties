using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.BusinessModels;
using DanceParties.Interfaces.Services;
using ResponseDto = DanceParties.Interfaces.DTO.PartyResponse;
using BusinessModel = DanceParties.Interfaces.BusinessModels.Party;
using LocationBusinessModel = DanceParties.Interfaces.BusinessModels.Location;
using CityBusinessModel = DanceParties.Interfaces.BusinessModels.City;
using DanceBusinessModel = DanceParties.Interfaces.BusinessModels.Dance;

namespace DanceParties.Controllers
{
    [Route("api/parties")]
    [ApiController]
    public class PartyController : AbstractController
    {
        private readonly IService<BusinessModel> _partyService;
        private readonly IService<LocationBusinessModel> _locationService;
        private readonly IService<CityBusinessModel> _cityService;
        private readonly IService<DanceBusinessModel> _danceService;
        private readonly IMapper _mapper;

        public PartyController(IService<BusinessModel> partyService, IService<LocationBusinessModel> locationService,
            IService<CityBusinessModel> cityService, IService<DanceBusinessModel> danceService, IMapper mapper)
        {
            _partyService = partyService;
            _locationService = locationService;
            _cityService = cityService;
            _danceService = danceService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<PartyResponse> Get(int id)
        {
            var model = await _partyService.Get(id);
            var dto = await ToDto(model);
            return dto;
        }

        [HttpGet]
        public async Task<IEnumerable<PartyResponse>> GetParties()
        {
            var models = await _partyService.GetAll();
            var dtos = await Task.WhenAll(models.Select(m => ToDto(m)));
            return dtos;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PartyRequest dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var model = _mapper.Map<Party>(dto);

            var createdModel = await _partyService.Add(model);
            return CreatedAtAction(
                  "Get",
                  new { Id = createdModel.Id },
                  createdModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]PartyRequest dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var model = _mapper.Map<Party>(dto);
            await _partyService.Edit(model.Id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _partyService.Delete(id);
            return NoContent();
        }

        private async Task<ResponseDto> ToDto(BusinessModel model)
        {
            var dto = _mapper.Map<BusinessModel, ResponseDto>(model);
            var locationModel = await _locationService.Get(model.LocationId);
            dto = _mapper.Map<LocationBusinessModel, ResponseDto>(locationModel, dto);
            var cityModel = await _cityService.Get(locationModel.CityId);
            dto = _mapper.Map<CityBusinessModel, ResponseDto>(cityModel, dto);
            var danceModel = await _danceService.Get(model.DanceId);
            return _mapper.Map<DanceBusinessModel, ResponseDto>(danceModel, dto);
        }
    }
}