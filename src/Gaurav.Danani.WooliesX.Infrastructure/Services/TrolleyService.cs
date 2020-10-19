using System.Threading.Tasks;
using AutoMapper;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal;
using Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi;
using Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi.Dtos;
using Microsoft.Extensions.Logging;
using Refit;

namespace Gaurav.Danani.WooliesX.Infrastructure.Services
{
    public class TrolleyService : ITrolleyService
    {
        private readonly IWooliesXDevApiProxy _wooliesXDevApiProxy;
        private readonly IMapper _mapper;
        private readonly ILogger<TrolleyService> _logger;
        private readonly string _token;

        public TrolleyService(
            IWooliesXDevApiProxy wooliesXDevApiProxy,
            IAppSettingsProvider appSettingsProvider,
            IMapper mapper,
            ILogger<TrolleyService> logger)
        {
            _wooliesXDevApiProxy = wooliesXDevApiProxy;
            _mapper = mapper;
            _logger = logger;
            _token = appSettingsProvider.AppSettings.Proxies.WooliesXDevApi.Token;
        }
        
        public async Task<double> GetTrolleyTotal(TrolleyTotalRequest trolleyTotalRequest)
        {
            try
            {
                var getTrolleyTotalDto = _mapper.Map<GetTrolleyTotalDto>(trolleyTotalRequest);
                return await _wooliesXDevApiProxy.GetTrolleyTotalAsync(_token, getTrolleyTotalDto);
            }
            catch (ApiException e)
            {
                _logger.LogError(e, "WooliesXDevApi: GetTrolleyTotalAsync operation failed.");
                throw;
            }
        }
    }
}