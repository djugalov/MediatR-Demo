namespace IncidentCreator.BL.Queries.Products
{
    using IncidentCreator.Data.Database;
    using IncidentCreator.Data.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IReadOnlyCollection<Product>>
    {
        private readonly IncidentCreatorDbContext _context;

        public GetProductsQueryHandler(IncidentCreatorDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken) =>
            await _context.Products.ToListAsync(cancellationToken: cancellationToken);
    }
}
