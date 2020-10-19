using MediatR;

namespace Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal
{
    public class GetTrolleyTotalQuery : IRequest<double>
    {
        public TrolleyTotalRequest Trolley { get; set; }
    }
}