namespace IncidentCreator.Application.Infrastructure
{
    using AutoMapper;
    using IncidentCreator.Data.Models;
    using IncidentCreator.Models.DTOs;
    using System.Collections.Generic;
    using System.Linq;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<CreateIncidentDto, Incident>().ReverseMap();
            CreateMap<Incident, IncidentInformationDto>()
                .ForMember(x => x.Products, opt => opt.MapFrom(x=> new HashSet<Product>()))
                .ReverseMap();
            CreateMap<ProductInformationDto, Product>().ReverseMap();
        }
    }
}
