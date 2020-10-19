using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using MediatR;

namespace Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal
{
    public class GetTrolleyTotalQueryHandler : IRequestHandler<GetTrolleyTotalQuery, double>
    {
        private readonly ITrolleyService _trolleyService;

        public GetTrolleyTotalQueryHandler(ITrolleyService trolleyService)
        {
            _trolleyService = trolleyService;
        }
        
        public async Task<double> Handle(GetTrolleyTotalQuery request, CancellationToken cancellationToken)
        {
            return  await _trolleyService.GetTrolleyTotal(request.Trolley);
        }
    }
}