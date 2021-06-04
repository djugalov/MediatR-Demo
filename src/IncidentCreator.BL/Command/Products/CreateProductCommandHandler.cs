namespace IncidentCreator.BL.Command.Products
{
    using IncidentCreator.Data.Database;
    using IncidentCreator.Data.Models;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IncidentCreatorDbContext _context;
        public CreateProductCommandHandler(IncidentCreatorDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _context.Products.AddAsync(request.Product, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return product.Entity;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(request.Product)} could not be saved: {e.Message}");
            }
        }
    }
}
