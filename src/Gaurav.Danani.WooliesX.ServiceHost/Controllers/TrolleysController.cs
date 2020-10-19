using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gaurav.Danani.WooliesX.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrolleysController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<TrolleyTotalRequest> _validator;
        private readonly ILogger<TrolleysController> _logger;

        public TrolleysController(
            IMediator mediator,
            IValidator<TrolleyTotalRequest> validator,
            ILogger<TrolleysController> logger)
        {
            _mediator = mediator;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        [Route("trolleyTotal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> TrolleyTotal([FromBody] TrolleyTotalRequest request)
        {
            try
            {
                var validationResults = await _validator.ValidateAsync(request);
                if (!validationResults.IsValid)
                {
                    _logger.LogInformation(
                        "TrolleyTotal: Validation failures, Validation Results {@ValidationResults}",
                        validationResults);
                    
                    return Problem(title: "Validation Errors", statusCode: 400,
                        detail: string.Join(Environment.NewLine, validationResults.Errors.Select(e => e.ErrorMessage)));
                }

                return Ok(await _mediator.Send(new GetTrolleyTotalQuery {Trolley = request}));
            }
            catch (Exception)
            {
                return Problem(title:"An unhandled error occured.", statusCode: 500);
            }
        }
    }
}