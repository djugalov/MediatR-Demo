namespace IncidentCreator.BL.Queries.Incidents
{
    using IncidentCreator.Data.Models;
    using MediatR;
    using System.Collections.Generic;
    public class GetIncidentsQuery : IRequest<IReadOnlyCollection<Incident>>
    {
    }
}
