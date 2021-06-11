namespace IncidentCreator.BL.Queries.Incidents
{
    using IncidentCreator.Models.DTOs;
    using MediatR;
    using System;
    public class GetIncidentByIdQuery : IRequest<IncidentInformationDto>
    {
        public Guid ID { get; set; }
    }
}
