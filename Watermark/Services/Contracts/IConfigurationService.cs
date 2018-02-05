using System.Threading.Tasks;
using Watermark.Models;
using Watermark.Models.Admin.Configuration;

namespace Watermark.Services.Contracts
{
    public interface IConfigurationService
    {
        Configuration GetSiteConfiguration();

        Task<Configuration> UpdateConfigurationAsync(Configuration config);

        Currency GetGlobalCurrency();

        Language GetDefaultLanguage();
    }
}