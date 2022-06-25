using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Requests.Country;
using Margs.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly PgDbContext _db;
    private readonly IDateTimeProvider _date;

    public CountryController(ILogger logger, PgDbContext db, IDateTimeProvider date)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _db = db ?? throw new ArgumentNullException(nameof(db));
        _date = date ?? throw new ArgumentNullException(nameof(date));
    }

    [HttpGet("Province/List")]
    public async Task<IActionResult> ProvinceList()
    {
        try
        {
            var provinceList = await (from
                    provinces in _db.Provinces
                join cities in _db.Cities
                    on provinces.Id equals cities.ProvinceId
                select new
                {
                    ProvinceName = provinces.Name,
                    ProvinceId = provinces.Id,
                    CityName = cities.Name,
                    CityId = cities.Id
                }).AsNoTracking().Distinct().ToListAsync();
            return Ok(provinceList);
        }
        catch (Exception e)
        {
            _logger.Error("Get Province List Failed with Exception {E}", e.ToString());
            throw;
        }
    }
}