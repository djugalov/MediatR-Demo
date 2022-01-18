namespace IncidentCreator.BL.Command.Products
{
    using IncidentCreator.Data.Database;
    using IncidentCreator.Data.Models;
    using MediatR;
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
            var product = await _context.Products.AddAsync(request.Product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Entity;
        }
    }
}
