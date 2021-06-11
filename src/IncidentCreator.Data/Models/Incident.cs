namespace IncidentCreator.Data.Models
{
    using IncidentCreator.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Incident
    {
        [Key]
        [Column("id")]
        public Guid ID { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("impact")]
        public Impact Impact { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
    }
}
