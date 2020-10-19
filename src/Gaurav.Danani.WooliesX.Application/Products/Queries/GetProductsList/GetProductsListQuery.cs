using System.Collections.Generic;
using MediatR;

namespace Gaurav.Danani.WooliesX.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<List<ProductsListVm>>
    {
        public string SortOption { get; set; }
    }
}