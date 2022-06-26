using Margs.Api.Services.Interfaces;

namespace Margs.Api.Services.Repos;

public class CoreServices : ICoreServices
{
    public string GenerateImagePid(string imageName)
    {
        var guid = Guid.NewGuid().ToString();

        //7774cb6f-6fc4-4faa-ac00-40461cf62a91
        var splitedGuid = string.Join("", guid.Split("-").Take(2));

        return splitedGuid + "_" + imageName;
    }
}