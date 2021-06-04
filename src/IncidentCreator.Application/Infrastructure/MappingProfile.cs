namespace IncidentCreator.Application.Infrastructure
{
    using AutoMapper;
    using IncidentCreator.Data.Models;
    using IncidentCreator.Models.DTOs;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<CreateIncidentDto, Incident>().ReverseMap();
        }
    }
}
