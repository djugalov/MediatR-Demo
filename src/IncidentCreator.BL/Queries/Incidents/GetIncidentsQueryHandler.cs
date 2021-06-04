namespace IncidentCreator.BL.Queries.Incidents
{
    using IncidentCreator.Data.Database;
    using IncidentCreator.Data.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetIncidentsQueryHandler : IRequestHandler<GetIncidentsQuery, IReadOnlyCollection<Incident>>
    {
        private readonly IncidentCreatorDbContext _context;
        public GetIncidentsQueryHandler(IncidentCreatorDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<Incident>> Handle(GetIncidentsQuery request, CancellationToken cancellationToken) =>
            await _context.Incidents.ToListAsync(cancellationToken: cancellationToken);
    }
}
