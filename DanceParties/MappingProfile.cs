using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities = DanceParties.DataEntities;
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
            CreateMap<BusinessModels.City, Dto.Location>()
                .ForMember(d => d.Id, m => m.Ignore())
                .ForMember(d => d.Name, m => m.Ignore())
                .ForMember(d => d.City, m => m.MapFrom(s => s.Name));
            CreateMap<Dto.Location, BusinessModels.Location>();

            CreateMap<BusinessModels.Party, Dto.PartyResponse>();
            CreateMap<BusinessModels.Location, Dto.PartyResponse>()
                .ForMember(d => d.Id, m => m.Ignore())
                .ForMember(d => d.Name, m => m.Ignore())
                .ForMember(d => d.Location, m => m.MapFrom(s => s.Name))
                .ForMember(d => d.Address, m => m.MapFrom(s => s.Address));
            CreateMap<BusinessModels.City, Dto.PartyResponse>()
                .ForMember(d => d.Id, m => m.Ignore())
                .ForMember(d => d.Name, m => m.Ignore())
                .ForMember(d => d.City, m => m.MapFrom(s => s.Name));
            CreateMap<BusinessModels.Dance, Dto.PartyResponse>()
                .ForMember(d => d.Id, m => m.Ignore())
                .ForMember(d => d.Name, m => m.Ignore())
                .ForMember(d => d.Dance, m => m.MapFrom(s => s.Name));

            CreateMap<Dto.PartyRequest, BusinessModels.Party>();

            CreateMap<BusinessModels.Party, Entities.Party>();
            CreateMap<Entities.Party, BusinessModels.Party>();
        }
    }
}
