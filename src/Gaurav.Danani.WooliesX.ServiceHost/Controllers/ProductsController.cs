using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Gaurav.Danani.WooliesX.Application.Products.Queries.GetProductsList;
using Gaurav.Danani.WooliesX.ServiceHost.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gaurav.Danani.WooliesX.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<GetProductsListRequest> _validator;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            IMediator mediator,
            IValidator<GetProductsListRequest> validator,
            ILogger<ProductsController> logger)
        {
            _mediator = mediator;
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        [Route("sort")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductsListVm>>> Get([FromQuery] GetProductsListRequest request)
        {
            try
            {
                var validationResults = await _validator.ValidateAsync(request);
                if (!validationResults.IsValid)
                {
                    _logger.LogInformation(
                        "GetProductsList: Validation failures, Validation Results {@ValidationResults}",
                        validationResults);
                   
                    return Problem(title: "Validation Errors", statusCode: 400,
                        detail: string.Join(Environment.NewLine, validationResults.Errors.Select(e => e.ErrorMessage)));
                }

                return Ok(await _mediator.Send(new GetProductsListQuery {SortOption = request.SortOption}));
            }
            catch (Exception)
            {
                return Problem(title:"An unhandled error occured.", statusCode: 500);
            }
        }
    }
}