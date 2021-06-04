namespace IncidentCreator.BL.Command.Products
{
    using IncidentCreator.Data.Models;
    using MediatR;
    public class CreateProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
