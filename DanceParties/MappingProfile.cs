using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessModels = DanceParties.Interfaces.BusinessModels;
using Dto = DanceParties.Interfaces.DTO;

namespace DanceParties
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusinessModels.City, Dto.City>();
            CreateMap<Dto.City, BusinessModels.City>();
            CreateMap<BusinessModels.Dance, Dto.Dance>();
            CreateMap<Dto.Dance, BusinessModels.Dance>();
            CreateMap<BusinessModels.Location, Dto.Location>();
            CreateMap<Dto.Location, BusinessModels.Location>();
            CreateMap<BusinessModels.Party, Dto.Party>();
            CreateMap<Dto.Party, BusinessModels.Party>();
        }
    }
}
