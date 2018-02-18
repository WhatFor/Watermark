using System.Threading.Tasks;
using Watermark.Models;
using Watermark.Models.Admin.Configuration;
using Watermark.Repository.Contracts;
using Watermark.Services.Contracts;

namespace Watermark.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            this.configurationRepository = configurationRepository;
        }

        public Configuration GetSiteConfiguration()
        {
            var config =  configurationRepository.GetSiteConfiguration();

            if (config == null)
            {
                return new Configuration();
            }
            else
            {
                return config;
            }
        }

        public async Task<Configuration> UpdateConfigurationAsync(Configuration config)
        {
            return await configurationRepository.UpdateConfigurationAsync(config);
        }

        public bool GlobalCurrencySet => configurationRepository.GetGlobalCurrency() != null;

        public Currency? GetGlobalCurrency()
        {
            return configurationRepository.GetGlobalCurrency();
        }

        public bool DefaultLanguageSet => configurationRepository.GetDefaultLanguage() != null;

        public Language? GetDefaultLanguage()
        {
            return configurationRepository.GetDefaultLanguage();
        }
    }
}