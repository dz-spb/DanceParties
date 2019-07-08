using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using DanceParties.Controllers;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.Services;
using DanceParties.Interfaces.BusinessModels;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace DanceParties.Tests
{    
    public class PartyControllerTests
    {
        private static readonly TimeSpan _mskTimezoneOffset = TimeSpan.FromHours(3);
        private static readonly Party _party1 = GetParty1();
        private static readonly Party _party2 = GetParty2();
        private static readonly Party _party3 = GetParty3();
        private static readonly PartyResponse _response1 = GetPartyResponse1();
        private static readonly PartyResponse _response2 = GetPartyResponse2();
        private static readonly PartyResponse _response3 = GetPartyResponse3();

        [Fact]
        public void GetPartiesTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            var partyService = new Mock<IService<Party>>();
            partyService.Setup(ps => ps.GetAll()).Returns(GetPartiesFromService());

            var locationService = new Mock<IService<Interfaces.BusinessModels.Location>>();

            var cityService = new Mock<IService<Interfaces.BusinessModels.City>>();

            var danceService = new Mock<IService<Interfaces.BusinessModels.Dance>>();

            // Arrange
            var partyController = new PartyController(partyService.Object, locationService.Object, 
                cityService.Object, danceService.Object, mapper);

            // Act
            IEnumerable<PartyResponse> response = partyController.GetParties().Result;

            // Assert
            Assert.Equal(GetPartiesResponse().Count(), response.Count());
        }
    
        private IEnumerable<PartyResponse> GetPartiesResponse()
        {
            return new List<PartyResponse>
            {
                _response1,
                _response2,
                _response3
            };
        }

        private Task<List<Party>> GetPartiesFromService()
        {
            return Task.FromResult(new List<Party>
            {
                _party1,
                _party2,
                _party3
            });
        }

        private static PartyResponse GetPartyResponse1()
        {
            return new PartyResponse
            {
                Id = 1,
                Dance = "Сальса",
                DanceId = 1,
                Name = "вечеринка 1",
                Address = "Невский 71",
                Location = "Tropikana",
                LocationId = 1,
                City = "Санкт-Петербург",
                CityId = 1,
                Start = new DateTimeOffset(2019, 07, 05, 20, 00, 00, _mskTimezoneOffset)
            };
        }

        private static PartyResponse GetPartyResponse2()
        {
            return new PartyResponse
            {
                Id = 2,
                Dance = "Бачата",
                DanceId = 2,
                Name = "вечеринка 2",
                Address = "Херсонская 12-14",
                Location = "AnyDay",
                LocationId = 2,
                City = "Санкт-Петербург",
                CityId = 1,
                Start = new DateTimeOffset(2019, 07, 06, 20, 30, 00, _mskTimezoneOffset)
            };
        }

        private static PartyResponse GetPartyResponse3()
        {
            return new PartyResponse
            {
                Id = 3,
                Dance = "Хастл",
                DanceId = 3,
                Name = "вечеринка 3",
                Address = "Стрелка В.О.",
                Location = "Ростральные колонны, зимняя площадка",
                LocationId = 3,
                City = "Санкт-Петербург",
                CityId = 1,
                Start = new DateTimeOffset(2019, 07, 06, 21, 00, 00, _mskTimezoneOffset)
            };
        }

        private static Party GetParty1()
        {
            return new Party
            {
                Id = 1,
                DanceId = 1,
                Name = "вечеринка 1",
                LocationId = 1,
                Start = new DateTimeOffset(2019, 07, 05, 20, 00, 00, _mskTimezoneOffset)
            };
        }

        private static Party GetParty2()
        {
            return new Party
            {
                Id = 2,
                DanceId = 2,
                Name = "вечеринка 2",
                LocationId = 2,
                Start = new DateTimeOffset(2019, 07, 06, 20, 30, 00, _mskTimezoneOffset)
            };
        }

        private static Party GetParty3()
        {
            return new Party
            {
                Id = 3,
                DanceId = 3,
                Name = "вечеринка 3",
                LocationId = 3,
                Start = new DateTimeOffset(2019, 07, 06, 21, 00, 00, _mskTimezoneOffset)
            };
        }
    }
}
