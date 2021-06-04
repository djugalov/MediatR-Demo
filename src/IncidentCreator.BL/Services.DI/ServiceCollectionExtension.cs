namespace Microsoft.Extensions.DependencyInjection
{
    using IncidentCreator.BL.Command.Incidents;
    using IncidentCreator.BL.Command.Products;
    using IncidentCreator.BL.Queries.Incidents;
    using IncidentCreator.BL.Queries.Products;
    using IncidentCreator.Data.Models;
    using MediatR;
    using System.Collections.Generic;
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateIncidentCommand, Incident>, CreateIncidentCommandHandler>();
            services.AddTransient<IRequestHandler<GetIncidentsQuery, IReadOnlyCollection<Incident>>, GetIncidentsQueryHandler>();
            services.AddTransient<IRequestHandler<CreateProductCommand, Product>, CreateProductCommandHandler>();
            services.AddTransient<IRequestHandler<GetProductsQuery, IReadOnlyCollection<Product>>, GetProductsQueryHandler>();

            return services;
        }
    }
}
