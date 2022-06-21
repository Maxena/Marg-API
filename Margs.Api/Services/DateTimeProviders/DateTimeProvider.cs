using Margs.Api.Services.Interfaces;

namespace Margs.Api.Services.DateTimeProviders;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}