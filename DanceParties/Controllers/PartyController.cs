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
        private readonly IPartyService _partyService;
        private readonly ILocationService _locationService;
        private readonly ICityService _cityService;
        private readonly IDanceService _danceService;
        private readonly IMapper _mapper;

        public PartyController(IPartyService partyService, ILocationService locationService,
            ICityService cityService, IDanceService danceService, IMapper mapper)
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
            var model = await _partyService.GetParty(id);
            var dto = await ToDto(model);
            return dto;
        }

        [HttpGet]
        public async Task<IEnumerable<PartyResponse>> GetParties()
        {
            var models = await _partyService.GetParties();
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

            var createdModel = await _partyService.AddParty(model);
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
            await _partyService.EditParty(model.Id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _partyService.DeleteParty(id);
            return NoContent();
        }

        private async Task<ResponseDto> ToDto(BusinessModel model)
        {
            var dto = _mapper.Map<BusinessModel, ResponseDto>(model);
            var locationModel = await _locationService.GetLocation(model.LocationId);
            dto = _mapper.Map<LocationBusinessModel, ResponseDto>(locationModel, dto);
            var cityModel = await _cityService.GetCity(locationModel.CityId);
            dto = _mapper.Map<CityBusinessModel, ResponseDto>(cityModel, dto);
            var danceModel = await _danceService.GetDance(model.DanceId);
            return _mapper.Map<DanceBusinessModel, ResponseDto>(danceModel, dto);
        }
    }
}