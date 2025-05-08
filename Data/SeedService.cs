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
                //await SeedMenusAsync(context, logger);
                await SeedConfigurationItemsAsync(context, logger);
                await SeedMasterItemsAsync(context, logger);
                await SeedCompaniesAsync(context, logger);
                await SeedRolesAsync(context, logger);
                await SeedUsersAsync(context, logger);
                await SeedAddressesAsync(context, logger);
                await SeedUserRolesAsync(context, logger);
                await SeedUserProfilesAsync(context, logger);
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

        /*
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
        */

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

        private static async Task SeedRolesAsync(AppDBContext context, ILogger logger)
        {

            try
            {
                if (await context.Roles.AnyAsync())
                {
                    logger.LogInformation("Roles table already has data - skipping seeding");
                    return;
                }

                List<Role>? roles = JsonSeedLoader.LoadFromJson<Role>("Data/SeedData/Roles.json");
                if (roles?.Any() == true)
                {
                    await context.Roles.AddRangeAsync(roles);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Seeded {Count} roles", roles.Count);
                }
                else
                {
                    logger.LogWarning("No roles found in seed data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error seeding roles");
                throw;
            }
        }

        private static async Task SeedUsersAsync(AppDBContext context, ILogger logger)
        {

            try
            {
                if (await context.Users.AnyAsync())
                {
                    logger.LogInformation("Users table already has data - skipping seeding");
                    return;
                }

                List<User>? users = JsonSeedLoader.LoadFromJson<User>("Data/SeedData/Users.json");
                if (users?.Any() == true)
                {
                    await context.Users.AddRangeAsync(users);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Seeded {Count} users", users.Count);
                }
                else
                {
                    logger.LogWarning("No user found in seed data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error seeding users");
                throw;
            }
        }

        private static async Task SeedAddressesAsync(AppDBContext context, ILogger logger)
        {

            try
            {
                if (await context.Addresses.AnyAsync())
                {
                    logger.LogInformation("Addresses table already has data - skipping seeding");
                    return;
                }

                List<Address>? addresses = JsonSeedLoader.LoadFromJson<Address>("Data/SeedData/Addresses.json");
                if (addresses?.Any() == true)
                {
                    await context.Addresses.AddRangeAsync(addresses);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Seeded {Count} addresses", addresses.Count);
                }
                else
                {
                    logger.LogWarning("No address found in seed data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error seeding addresses");
                throw;
            }
        }

        private static async Task SeedUserRolesAsync(AppDBContext context, ILogger logger)
        {

            try
            {
                if (await context.UserRoles.AnyAsync())
                {
                    logger.LogInformation("UserRoles table already has data - skipping seeding");
                    return;
                }

                List<UserRole>? userRoles = JsonSeedLoader.LoadFromJson<UserRole>("Data/SeedData/UserRoles.json");
                if (userRoles?.Any() == true)
                {
                    await context.UserRoles.AddRangeAsync(userRoles);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Seeded {Count} user roles", userRoles.Count);
                }
                else
                {
                    logger.LogWarning("No user roles found in seed data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error seeding user roles");
                throw;
            }
        }

        private static async Task SeedUserProfilesAsync(AppDBContext context, ILogger logger)
        {

            try
            {
                if (await context.UserProfiles.AnyAsync())
                {
                    logger.LogInformation("UserProfiles table already has data - skipping seeding");
                    return;
                }

                List<UserProfile>? userProfiles = JsonSeedLoader.LoadFromJson<UserProfile>("Data/SeedData/UserProfiles.json");
                if (userProfiles?.Any() == true)
                {
                    await context.UserProfiles.AddRangeAsync(userProfiles);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Seeded {Count} user profiles", userProfiles.Count);
                }
                else
                {
                    logger.LogWarning("No user profiles found in seed data");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error seeding user profiles");
                throw;
            }
        }
    }
}