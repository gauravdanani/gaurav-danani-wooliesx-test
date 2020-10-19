using System.Collections.Generic;

namespace Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi.Dtos
{
    public class GetTrolleyTotalDto
    {
        public IList<TrolleyProductDto> Products { get; set; }
        public IList<SpecialDto> Specials { get; set; }
        public IList<TrolleyQuantityDto> Quantities { get; set; }
    }
}