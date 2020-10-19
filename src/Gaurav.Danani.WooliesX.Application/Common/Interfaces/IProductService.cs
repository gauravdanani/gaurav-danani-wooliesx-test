using System.Collections.Generic;
using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Application.Common.Models;

namespace Gaurav.Danani.WooliesX.Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<IEnumerable<ProductHistoryModel>> GetProductsShoppingHistoryAsync();
    }
}