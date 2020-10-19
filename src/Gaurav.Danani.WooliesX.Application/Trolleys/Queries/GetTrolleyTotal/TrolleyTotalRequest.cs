namespace Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal
{
    public class TrolleyTotalRequest
    {
        public TrolleyProduct[] Products { get; set; }
        public Special[] Specials { get; set; }
        public TrolleyQuantity[] Quantities { get; set; }
    }
}