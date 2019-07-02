using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceParties.Interfaces.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanceParties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartiesController : ControllerBase
    {
        static readonly List<Party> data;
        static PartiesController()
        {
            data = new List<Party>
            {
                new Party { Id = 1, Dance = "Бачата", Place = "ресторан AnyDay", Address = "Херсонская ул., 12-14", City = "Санкт-Петербург" },
                new Party { Id = 2, Dance = "Хастл", Place = "Ростральные колонны, зимняя площадка", Address = "Стрелка В.О.", City = "Санкт-Петербург" }
            };
        }

        [HttpGet]
        public IEnumerable<Party> Get()
        {
            return data;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Party party)
        {
            party.Id = (new Random()).Next();
            data.Add(party);
            return Ok(party);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var party = data.FirstOrDefault(x => x.Id == id);
            if (party == null)
            {
                return NotFound();
            }
            data.Remove(party);
            return Ok(party);
        }
    }
}