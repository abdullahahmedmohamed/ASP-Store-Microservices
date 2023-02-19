using Catalog.API.Data.Interfaces;
using Catalog.API.Options;

namespace Catalog.API.Data;

public static class ServiceCollectionExtensions
{
    public static void AddCatalogDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CatalogDbSettings>( configuration.GetSection("CatalogDbSettings"));
        services.AddSingleton<ICatalogContext, CatalogContext>();
    }
}
