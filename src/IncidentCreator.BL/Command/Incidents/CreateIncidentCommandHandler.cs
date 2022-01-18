namespace IncidentCreator.BL.Command.Incidents
{
    using IncidentCreator.Data.Database;
    using IncidentCreator.Data.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateIncidentCommandHandler : IRequestHandler<CreateIncidentCommand, Incident>
    {
        private readonly IncidentCreatorDbContext _context;

        public CreateIncidentCommandHandler(IncidentCreatorDbContext context)
        {
            _context = context;
        }
        public async Task<Incident> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
        {
            var incident = await _context.Incidents.AddAsync(request.Incident, cancellationToken);

            foreach (var productID in request.AffectedProductsIDs)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ID == productID);

                if (product != null)
                {
                    await _context.IncidentProductMaps.AddAsync(new IncidentProductMap { Incident = incident.Entity, Product = product });

                    product.IsUnderIncident = true;
                }
            }
            await _context.SaveChangesAsync(cancellationToken);

            return incident.Entity;
        }
    }
}
