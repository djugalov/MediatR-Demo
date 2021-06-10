namespace IncidentCreator.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class IncidentProductMap
    {
        [Key]
        [Column("id")]
        public Guid ID { get; set; }
        [ForeignKey("product_id")]
        public virtual Product Product { get; set; }
        [ForeignKey("incident_id")]
        public virtual Incident Incident { get; set; }
    }
}
