using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using Gaurav.Danani.WooliesX.Application.Services.Interfaces;
using MediatR;

namespace Gaurav.Danani.WooliesX.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductsListVm>>
    {
        private readonly IProductService _productService;
        private readonly IProductsSortFactory _productsSortFactory;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(
            IProductService productService,
            IProductsSortFactory productsSortFactory,
            IMapper mapper)
        {
            _productService = productService;
            _productsSortFactory = productsSortFactory;
            _mapper = mapper;
        }
        
        public async Task<List<ProductsListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var sortStrategy = _productsSortFactory.GetProductsSortStrategy(request.SortOption);
            var products = await _productService.GetAllProductsAsync();

            return products == null ? new List<ProductsListVm>() : _mapper.Map<List<ProductsListVm>>((await sortStrategy.Sort(products)).ToList());
        }
    }
}