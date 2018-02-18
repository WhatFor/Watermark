using System.Threading.Tasks;
using Watermark.Models;
using Watermark.Models.Admin.Configuration;

namespace Watermark.Repository.Contracts
{
    public interface IConfigurationRepository
    {
        Configuration GetSiteConfiguration();

        Task<Configuration> UpdateConfigurationAsync(Configuration config);

        Currency? GetGlobalCurrency();

        Language? GetDefaultLanguage();
    }
}