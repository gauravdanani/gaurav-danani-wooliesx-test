using MediatR;

namespace Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal
{
    public class GetTrolleyTotalQuery : IRequest<decimal>
    {
        public TrolleyTotalRequest Trolley { get; set; }
    }
}