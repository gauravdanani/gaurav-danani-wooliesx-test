using System.Collections.Generic;

namespace Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi.Dtos
{
    public class SpecialDto
    {
        public IList<TrolleyQuantityDto> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}