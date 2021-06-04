namespace IncidentCreator.Data.Models
{
    using IncidentCreator.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class Incident
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Impact Impact { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public virtual IReadOnlyCollection<Product> Products { get; set; }
    }
}
