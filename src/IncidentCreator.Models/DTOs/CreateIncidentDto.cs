namespace IncidentCreator.Models.DTOs
{
    using IncidentCreator.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class CreateIncidentDto
    {
        public string Name { get; set; }
        public Impact Impact { get; set; }
        public DateTime StartDate { get; set; }
        public IReadOnlyCollection<Guid> AffectedProductsIDs { get; set; }
    }
}
