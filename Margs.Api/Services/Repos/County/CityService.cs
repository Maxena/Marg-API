using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.Interfaces.County;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services.Repos.County;

public class CityService : GenericRepo<City>, ICityService
{
    public CityService(PgDbContext context, ILogger logger) : base(context, logger)
    {
    }
}