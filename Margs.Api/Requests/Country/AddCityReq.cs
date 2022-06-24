namespace Margs.Api.Requests.Country;

public class AddCityReq
{
    public string Name { get; set; }
    public Guid ProvinceId { get; set; }
}