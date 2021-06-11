namespace IncidentCreator.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Product
    {
        [Key]
        [Column("id")]
        public Guid ID { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("is_under_incident")]
        public bool IsUnderIncident { get; set; }
    }
}
