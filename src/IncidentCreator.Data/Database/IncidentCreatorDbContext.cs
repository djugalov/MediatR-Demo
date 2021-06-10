namespace IncidentCreator.Data.Database
{
    using IncidentCreator.Data.Extensions;
    using IncidentCreator.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class IncidentCreatorDbContext : DbContext
    {
        public IncidentCreatorDbContext(DbContextOptions<IncidentCreatorDbContext> options) : base(options)
        {
        }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<IncidentProductMap> IncidentProductMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
