namespace IncidentCreator.Application.Controllers
{
    using AutoMapper;
    using IncidentCreator.BL.Command.Incidents;
    using IncidentCreator.BL.Queries.Incidents;
    using IncidentCreator.Data.Models;
    using IncidentCreator.Models.DTOs;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IncidentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Incident>>> GetIncidents() => Ok(await _mediator.Send(new GetIncidentsQuery { }));

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct(CreateIncidentDto createIncidentDto)
        {
            try
            {
                var incident = await _mediator.Send(new CreateIncidentCommand
                {
                    Incident = _mapper.Map<Incident>(createIncidentDto),
                    AffectedProductsIDs = createIncidentDto.AffectedProductsIDs
                });
                return incident.ID;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
