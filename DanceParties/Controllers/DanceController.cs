using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.Services;
using BusinessModel = DanceParties.Interfaces.BusinessModels.Dance;

namespace DanceParties.Controllers
{
    [Route("api/dances")]
    [ApiController]
    public class DanceController : AbstractController
    {
        private readonly IService<BusinessModel> _danceService;
        private readonly IMapper _mapper;

        public DanceController(IService<BusinessModel> danceService, IMapper mapper)
        {
            _danceService = danceService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<Dance> Get(int id)
        {
            var model = await _danceService.Get(id);
            var dto = _mapper.Map<Dance>(model);
            return dto;
        }

        [HttpGet]
        public async Task<IEnumerable<Dance>> GetDances()
        {
            var models = await _danceService.GetAll();
            var dtos = models.Select(_mapper.Map<Dance>);
            return dtos;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Dance city)
        {
            return NotImplemented();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Dance value)
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