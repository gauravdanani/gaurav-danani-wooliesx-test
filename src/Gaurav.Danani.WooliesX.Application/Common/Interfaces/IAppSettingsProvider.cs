using Gaurav.Danani.WooliesX.Application.ApplicationSettings;

namespace Gaurav.Danani.WooliesX.Application.Common.Interfaces
{
    public interface IAppSettingsProvider
    {
        AppSettings AppSettings { get; }
    }
}