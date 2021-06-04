namespace IncidentCreator.BL.Queries.Products
{
    using IncidentCreator.Data.Models;
    using MediatR;
    using System.Collections.Generic;

    public class GetProductsQuery : IRequest<IReadOnlyCollection<Product>>
    {
    }
}
