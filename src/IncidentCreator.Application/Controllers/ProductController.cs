namespace IncidentCreator.Application.Controllers
{
    using AutoMapper;
    using IncidentCreator.BL.Command.Products;
    using IncidentCreator.BL.Queries.Products;
    using IncidentCreator.Data.Models;
    using IncidentCreator.Models.DTOs;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Product>>> GetProducts() => Ok(await _mediator.Send(new GetProductsQuery { }));

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct(CreateProductDto createProductDto)
        {
            var product = await _mediator.Send(new CreateProductCommand { Product = _mapper.Map<Product>(createProductDto) });
            return product.ID;
        }
    }
}
