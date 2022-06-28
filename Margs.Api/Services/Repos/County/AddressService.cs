using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.Interfaces.County;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services.Repos.County;

public class AddressService : GenericRepo<Address>, IAddressService
{
    public AddressService(PgDbContext context, ILogger logger) : base(context, logger)
    {
    }
}