using System.Collections.Generic;

namespace Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi.Dtos
{
    public class ShoppingHistoryDto
    {
        public string CustomerId { get; set; }
        public IEnumerable<ProductDto> Products{ get; set; }
    }
}