using System.Collections.Generic;
using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Application.Common.Models;

namespace Gaurav.Danani.WooliesX.Application.Services.Interfaces
{
    public interface IProductsSortStrategy
    {
        Task<IEnumerable<ProductModel>> Sort(IEnumerable<ProductModel> products);
    }
}