using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.DateTimeProviders;

namespace Margs.Api.Database;

public static class Seeder
{
    public static async Task SeedRoles(DateTimeProvider dateTimeProvider, PgDbContext pg)
    {
        var roles = new List<Role>
        {
            new()
            {
                Name = "Admin",
                Description = "Admin Role",
                CreatedAt = dateTimeProvider.UtcNow,
            },
            new()
            {
                Name = "Mohandes",
                Description = "Mohandes Role just for Engineers",
                CreatedAt = dateTimeProvider.UtcNow,
            },
            new()
            {
                Name = "Samali",
                Description = "samali role just for amirhossein and mamali",
                CreatedAt = dateTimeProvider.UtcNow
            },
            new()
            {
                Name = "Seyed",
                Description = "seyed role just for amir marei",
                CreatedAt = dateTimeProvider.UtcNow
            },
            new()
            {
                Name = "Navid Abadi",
                Description = "navid abadi role just for soltan navid abadi",
                CreatedAt = dateTimeProvider.UtcNow
            }
        };

        // await pg.Roles.AddRangeAsync(roles);
        await pg.SaveChangesAsync();
    }
}