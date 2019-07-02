using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.BusinessModels;
using DanceParties.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceParties.Controllers
{
    [Route("api/parties")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyService _partyService;
        private readonly IMapper _mapper;
        private readonly ILogger<PartyController> _logger;

        public PartyController(IPartyService partyService, IMapper mapper, ILogger<PartyController> logger)
        {
            _partyService = partyService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<PartyResponse> Get(int id)
        {
            var model = await _partyService.GetParty(id);
            var dto = _mapper.Map<PartyResponse>(model);
            return dto;
        }

        [HttpGet]
        public async Task<IEnumerable<PartyResponse>> GetAll()
        {
            var models = await _partyService.GetParties();
            var dtos = models.Select(_mapper.Map<PartyResponse>);
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
            return CreatedAtRoute(
                  "Get",
                  new { Id = model.Id },
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
        public IActionResult Delete(int id)
        {
            //var party = data.FirstOrDefault(x => x.Id == id);
            //if (party == null)
            //{
            //    return NotFound();
            //}
            //data.Remove(party);
            //return Ok(party);

            return Ok();
        }
    }
}