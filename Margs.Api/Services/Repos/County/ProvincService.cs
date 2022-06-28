using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.Interfaces.County;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services.Repos.County;

public class ProvincService : GenericRepo<Province>, IProvinceService
{
    public ProvincService(PgDbContext context, ILogger logger) : base(context, logger)
    {
    }
}