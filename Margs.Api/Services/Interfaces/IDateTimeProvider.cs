namespace Margs.Api.Services.Interfaces;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}