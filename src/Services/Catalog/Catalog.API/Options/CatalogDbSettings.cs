namespace Catalog.API.Options;

public class CatalogDbSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ProductsCollectionName { get; set; } = null!;
}
