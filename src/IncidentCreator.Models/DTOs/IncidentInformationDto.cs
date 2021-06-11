namespace IncidentCreator.Models.DTOs
{
    using IncidentCreator.Models.Enums;
    using System;
    using System.Collections.Generic;
    public class IncidentInformationDto
    {
        public string Name { get; set; }
        public Impact Impact { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IReadOnlyCollection<ProductInformationDto> Products { get; set; }
    }
}
