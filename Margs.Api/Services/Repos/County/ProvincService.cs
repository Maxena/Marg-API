using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.Interfaces.County;

namespace Margs.Api.Services.Repos.County;

public class ProvincService : GenericRepo<Province>, IProvinceService
{
    public ProvincService(PgDbContext context) : base(context)
    {
    }
}