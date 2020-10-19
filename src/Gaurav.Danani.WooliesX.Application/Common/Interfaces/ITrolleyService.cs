using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal;

namespace Gaurav.Danani.WooliesX.Application.Common.Interfaces
{
    public interface ITrolleyService
    {
        Task<decimal> GetTrolleyTotal(TrolleyTotalRequest trolleyTotalRequest);
    }
}