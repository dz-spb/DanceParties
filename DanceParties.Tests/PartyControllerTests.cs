using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using DanceParties.Controllers;
using DanceParties.Interfaces.DTO;
using DanceParties.Interfaces.Services;
using Models = DanceParties.Interfaces.BusinessModels;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace DanceParties.Tests
{    
    public class PartyControllerTests
    {
        private static readonly TimeSpan _mskTimezoneOffset = TimeSpan.FromHours(3);
        private static readonly Models.Party _party1 = GetParty1();
        private static readonly Models.Party _party2 = GetParty2();
        private static readonly Models.Party _party3 = GetParty3();
        private static readonly PartyResponse _response1 = GetPartyResponse1();
        private static readonly PartyResponse _response2 = GetPartyResponse2();
        private static readonly PartyResponse _response3 = GetPartyResponse3();

        /// <summary>
        /// Controller test example
        /// </summary>
        [Fact]
        public void GetPartiesTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            var partyService = new Mock<IService<Models.Party>>();
            partyService.Setup(ps => ps.GetAll()).Returns(GetPartiesFromService());

            var locationService = new Mock<IService<Models.Location>>();
            locationService.Setup(ls => ls.Get(It.IsAny<int>())).Returns(GetLocation1());

            var cityService = new Mock<IService<Models.City>>();
            cityService.Setup(ls => ls.Get(It.IsAny<int>())).Returns(GetCity1());

            var danceService = new Mock<IService<Models.Dance>>();

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

        private Task<List<Models.Party>> GetPartiesFromService()
        {
            return Task.FromResult(new List<Models.Party>
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

        private static Models.Party GetParty1()
        {
            return new Models.Party
            {
                Id = 1,
                DanceId = 1,
                Name = "party 1",
                LocationId = 1,
                Start = new DateTimeOffset(2019, 07, 05, 20, 00, 00, _mskTimezoneOffset)
            };
        }

        private static Models.Party GetParty2()
        {
            return new Models.Party
            {
                Id = 2,
                DanceId = 2,
                Name = "party 2",
                LocationId = 1,
                Start = new DateTimeOffset(2019, 07, 06, 20, 30, 00, _mskTimezoneOffset)
            };
        }

        private static Models.Party GetParty3()
        {
            return new Models.Party
            {
                Id = 3,
                DanceId = 3,
                Name = "party 3",
                LocationId = 1,
                Start = new DateTimeOffset(2019, 07, 06, 21, 00, 00, _mskTimezoneOffset)
            };
        }

        private static Task<Models.Location> GetLocation1()
        {
            return Task.FromResult(new Models.Location
            {
                Id = 1,            
                Name = "location 1",
                Address = "address 1",
                CityId = 1
            });
        }

        private static Task<Models.City> GetCity1()
        {
            return Task.FromResult(new Models.City
            {
                Id = 1,
                Name = "city 1"            
            });
        }

        private static Task<Models.Dance> GetDance1()
        {
            return Task.FromResult(new Models.Dance
            {
                Id = 1,
                Name = "dance 1"
            });
        }
    }
}
