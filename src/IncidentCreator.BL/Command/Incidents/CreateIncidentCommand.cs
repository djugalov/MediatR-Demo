namespace IncidentCreator.BL.Command.Incidents
{
    using IncidentCreator.Data.Models;
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class CreateIncidentCommand : IRequest<Incident>
    {
        public Incident Incident { get; set; }
        public IReadOnlyCollection<Guid> AffectedProductsIDs { get; set; }
    }
}
