using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Watermark.Models;
using Watermark.Models.Admin.Configuration;
using Watermark.Repository.Contracts;

namespace Watermark.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly WatermarkDbContext dbContext;

        public ConfigurationRepository(WatermarkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Configuration GetSiteConfiguration()
        {
            return dbContext.Configuration
                .Include(m => m.CurrencyConfiguration)
                .FirstOrDefault();
        }

        public Currency GetGlobalCurrency()
        {
            return dbContext.Configuration
                .Include(m => m.CurrencyConfiguration)
                .FirstOrDefault().CurrencyConfiguration?.GlobalCurrency ?? Currency.NIL;
        }

        public Language GetDefaultLanguage()
        {
            return dbContext.Configuration
                .Include(m => m.LanguageConfiguration)
                .FirstOrDefault().LanguageConfiguration?.DefaultLanguage ?? Language.NotSet;
        }

        public async Task<Configuration> UpdateConfigurationAsync(Configuration config)
        {
            if (config.Id == 0)
            {
                await dbContext.Configuration.AddAsync(config);
                await dbContext.SaveChangesAsync();

                return config;
            }
            else
            {
                var existingConfig = await dbContext.Configuration
                    .Include(m => m.CurrencyConfiguration)
                    .SingleOrDefaultAsync(m => m.Id == config.Id);

                existingConfig.CurrencyConfiguration.GlobalCurrency = config.CurrencyConfiguration.GlobalCurrency;

                dbContext.Configuration.Update(existingConfig);
                await dbContext.SaveChangesAsync();

                return existingConfig;
            }
        }
    }
}