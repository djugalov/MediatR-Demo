namespace IncidentCreator.Data.Extensions
{
    using IncidentCreator.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "TestProduct-1",
                    IsUnderIncident = false,
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "TestProduct-2",
                    IsUnderIncident = false
                },
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "TestProduct-3",
                    IsUnderIncident = false
                });
        }
    }
}
