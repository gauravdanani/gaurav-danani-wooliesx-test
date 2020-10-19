using System.Threading;
using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using MediatR;

namespace Gaurav.Danani.WooliesX.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailModel>
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetUserDetailQueryHandler(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<UserDetailModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var proxySettings = _appSettingsProvider.AppSettings.Proxies.WooliesXDevApi;
            var response = new UserDetailModel
            {
                Name = "Gaurav Danani",
                Token = proxySettings.Token
            };

            return await Task.FromResult(response);
        }
    }
}