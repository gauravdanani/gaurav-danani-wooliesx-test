using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Gaurav.Danani.WooliesX.Application.Products.Queries.GetProductsList;
using Gaurav.Danani.WooliesX.ServiceHost.Controllers;
using Gaurav.Danani.WooliesX.ServiceHost.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Gaurav.Danani.WooliesX.ServiceHost.Unit.Controllers
{
    public class ProductsControllerTests
    {
        private readonly IFixture _fixture;
        private readonly IMediator _mediator;
        private readonly IValidator<GetProductsListRequest> _validator;
        private readonly ProductsController _productsController;
        
        public ProductsControllerTests()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization() {ConfigureMembers = true});
            _mediator = _fixture.Freeze<IMediator>();
            _validator = _fixture.Freeze<IValidator<GetProductsListRequest>>();
            var logger = _fixture.Freeze<ILogger<ProductsController>>();
            _productsController = new ProductsController(_mediator, _validator, logger)
            {
                ProblemDetailsFactory = new MockProblemDetailsFactory()
            };
        }

        [Fact]
        public async Task Get_Should_Return_BadRequest_When_RequestValidation_Fails()
        {
            // Arrange
            var request = _fixture.Create<GetProductsListRequest>();
            
            var validationErrors = _fixture.CreateMany<ValidationFailure>();
            var invalidResult = new ValidationResult(validationErrors);
            _validator.ValidateAsync(request).Returns(invalidResult);

            // Act
            var response = await _productsController.Get(request);

            // Assert
            response.Result.Should().BeOfType<ObjectResult>();
            ((ObjectResult) response.Result).StatusCode.Should().Be(400);
        }
        
        [Fact]
        public async Task Get_Should_Return_500ServerError_When_UnhandledException_Occurs()
        {
            // Arrange
            var request = _fixture.Create<GetProductsListRequest>();
            
            var invalidResult = new ValidationResult(new List<ValidationFailure>());
            _validator.ValidateAsync(request).Returns(invalidResult);

            _mediator.Send(Arg.Is<GetProductsListQuery>(q => q.SortOption == request.SortOption))
                .Throws(_fixture.Create<Exception>());

            // Act
            var response = await _productsController.Get(request);

            // Assert
            response.Result.Should().BeOfType<ObjectResult>();
            ((ObjectResult) response.Result).StatusCode.Should().Be(500);
        }
        
        [Fact]
        public async Task Get_Should_Return_Ok_With_ProductsList_When_Success()
        {
            // Arrange
            var request = _fixture.Create<GetProductsListRequest>();
            
            var invalidResult = new ValidationResult(new List<ValidationFailure>());
            _validator.ValidateAsync(request).Returns(invalidResult);

            var expectedProductListVms = _fixture.CreateMany<ProductsListVm>().ToList();
            _mediator.Send(Arg.Is<GetProductsListQuery>(q => q.SortOption == request.SortOption))
                .Returns(expectedProductListVms);

            // Act
            var response = await _productsController.Get(request);

            // Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult) response.Result).Value.Should().Be(expectedProductListVms);
        }
    }
}