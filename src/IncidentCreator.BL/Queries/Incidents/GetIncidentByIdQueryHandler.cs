namespace IncidentCreator.BL.Queries.Incidents
{
    using AutoMapper;
    using IncidentCreator.Data.Database;
    using IncidentCreator.Models.DTOs;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetIncidentByIdQueryHandler : IRequestHandler<GetIncidentByIdQuery, IncidentInformationDto>
    {
        private readonly IncidentCreatorDbContext _context;
        private readonly IMapper _mapper;
        public GetIncidentByIdQueryHandler(IncidentCreatorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IncidentInformationDto> Handle(GetIncidentByIdQuery request, CancellationToken cancellationToken)
        {
            var incident = await _context.Incidents.FirstOrDefaultAsync(x => x.ID == request.ID);
            var incidentProductMaps = _context.IncidentProductMaps.Where(x => x.Incident.ID == incident.ID);
            var incidentInformation = _mapper.Map<IncidentInformationDto>(incident);
            incidentInformation.Products = _mapper.Map<IReadOnlyCollection<ProductInformationDto>>(incidentProductMaps.Select(x => x.Product));

            return incidentInformation ?? throw new ArgumentException("No item matches the given ID");
        }
    }
}
