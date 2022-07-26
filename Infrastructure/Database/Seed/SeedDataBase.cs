namespace Infrastructure.Database.Seed;

public static class SeedDataBase 
{
    public static void Seed(ApplicationDbContext context)
    {
        Cities.Seed(context);
        Provinces.Seed(context);
        Roles.Seed(context);
    }
}