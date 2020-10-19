using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using MediatR;

namespace Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal
{
    public class GetTrolleyTotalQueryHandler : IRequestHandler<GetTrolleyTotalQuery, decimal>
    {
        private readonly ITrolleyService _trolleyService;

        public GetTrolleyTotalQueryHandler(ITrolleyService trolleyService)
        {
            _trolleyService = trolleyService;
        }
        
        public async Task<decimal> Handle(GetTrolleyTotalQuery request, CancellationToken cancellationToken)
        {
            return  await _trolleyService.GetTrolleyTotal(request.Trolley);
        }

        private decimal GetTrolleyTotalInternal(GetTrolleyTotalQuery request, CancellationToken cancellationToken)
        {
            decimal trolleyTotal = 0;
            var trolleyProductNames = request.Trolley.Quantities.Select(q => q.Name);
            var special = request.Trolley.Specials.FirstOrDefault(s =>
                s.Quantities.Select(q => q.Name).SequenceEqual(trolleyProductNames));

            int minQuantity = request.Trolley.Quantities.Min(q => q.Quantity);

            if (special != null)
            {
                foreach (var trolleyQuantity in request.Trolley.Quantities)
                {
                    var productPrice = request.Trolley.Products.First(p => p.Name == trolleyQuantity.Name).Price;
                    for (var i = 1; i <= trolleyQuantity.Quantity; i++)
                    {
                        if (i <= minQuantity)
                        {
                            var specialQty = special.Quantities.FirstOrDefault(sq => sq.Name == trolleyQuantity.Name);
                            var multiplier = trolleyQuantity.Quantity / specialQty.Quantity;

                            if (multiplier < 1)
                            {
                                trolleyTotal += i * productPrice;
                            }
                            else
                            {
                                //var remainder = specialQty.Quantity % trolleyQuantity.Quantity;
                                trolleyTotal += (special.Total / special.Quantities.Length);
                            }
                        }
                        else
                        {
                            trolleyTotal += i * productPrice;
                        }
                    }
                }
            }
            else
            {
                throw new Exception();
            }

            return trolleyTotal;
        }
    }
}