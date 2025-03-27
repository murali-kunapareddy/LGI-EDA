using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Data
{
    public static class SeedService
    {
        public static async Task SeedMasterDataAsync(AppDBContext context, ILogger logger)
        {
            try
            {
                await SeedCountriesAsync(context, logger);
                await SeedMenusAsync(context, logger);
                await SeedConfigurationItemsAsync(context, logger);
                await SeedMasterItemsAsync(context, logger);
                await SeedCompaniesAsync(context, logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error seeding master data");
                throw; // Re-throw to ensure startup fails if seeding fails
            }
        }

        private static async Task SeedCountriesAsync(AppDBContext context, ILogger logger)
        {
            if (await context.Countries.AnyAsync())
            {
                logger.LogInformation("Countries table already has data - skipping seeding");
                return;
            }

            try
            {
                var countries = JsonSeedLoader.LoadFromJson<Country>("Data/SeedData/Countries.json");
                if (countries?.Any() == true)
                {
                    await context.Countries.AddRangeAsync(countries);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Seeded {Count} countries", countries.Count);
                }
                else
                {
                    logger.LogWarning("No countries found in seed data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error seeding countries");
                throw;
            }
        }

        private static async Task SeedMenusAsync(AppDBContext context, ILogger logger)
        {
            if (await context.Menus.AnyAsync())
            {
                logger.LogInformation("Menus table already has data - skipping seeding");
                return;
            }

            var menus = JsonSeedLoader.LoadFromJson<Menu>("Data/SeedData/Menus.json");
            if (menus?.Any() == true)
            {
                await context.Menus.AddRangeAsync(menus);
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded {Count} menus", menus.Count);
            }
            else
            {
                logger.LogWarning("No menus found in seed data");
            }
        }

        private static async Task SeedConfigurationItemsAsync(AppDBContext context, ILogger logger)
        {
            if (await context.ConfigurationItems.AnyAsync())
            {
                logger.LogInformation("ConfigurationItems table already has data - skipping seeding");
                return;
            }

            var configurationItems = JsonSeedLoader.LoadFromJson<ConfigurationItem>("Data/SeedData/ConfigurationItems.json");
            if (configurationItems?.Any() == true)
            {
                await context.ConfigurationItems.AddRangeAsync(configurationItems);
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded {Count} configuration items", configurationItems.Count);
            }
            else
            {
                logger.LogWarning("No configuration items found in seed data");
            }
        }

        private static async Task SeedMasterItemsAsync(AppDBContext context, ILogger logger)
        {
            if (await context.MasterItems.AnyAsync())
            {
                logger.LogInformation("MasterItems table already has data - skipping seeding");
                return;
            }

            var masterItems = JsonSeedLoader.LoadFromJson<MasterItem>("Data/SeedData/MasterItems.json");
            if (masterItems?.Any() == true)
            {
                await context.MasterItems.AddRangeAsync(masterItems);
                await context.SaveChangesAsync();
                logger.LogInformation("Seeded {Count} master items", masterItems.Count);
            }
            else
            {
                logger.LogWarning("No master items found in seed data");
            }
        }

        private static async Task SeedCompaniesAsync(AppDBContext context, ILogger logger)
        {

            try
            {
                if (await context.Companies.AnyAsync())
                {
                    logger.LogInformation("Companies table already has data - skipping seeding");
                    return;
                }

                List<Company>? companies = JsonSeedLoader.LoadFromJson<Company>("Data/SeedData/Companies.json");
                if (companies?.Any() == true)
                {
                    await context.Companies.AddRangeAsync(companies);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Seeded {Count} companies", companies.Count);
                }
                else
                {
                    logger.LogWarning("No companies found in seed data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error seeding companies");
                throw;
            }
        }
    }
}