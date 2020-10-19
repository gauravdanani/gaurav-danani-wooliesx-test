using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace Gaurav.Danani.WooliesX.Application.ApplicationSettings
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        public AppSettingsProvider(IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
        }
        
        public AppSettings AppSettings { get; }
    }
}